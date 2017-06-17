using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using UBoat.Utils;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Conditional;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Integration.SequenceTranslators
{
    public class XSLTSequenceTranslator : ISequenceTranslator
    {
        private XNamespace xsl = "http://www.w3.org/1999/XSL/Transform";
        private XNamespace msxsl = "urn:schemas-microsoft-com:xslt";

        private object m_Lock = new object();
        private XElement m_Stylesheet;
        private bool m_CaseTranslationRequired;

        public object Translate(List<Step> sequence)
        {
            lock (m_Lock) //Only one call at a time. For concurrent use, get another instance from the factory.
            {
                XDocument output = new XDocument();
                m_CaseTranslationRequired = false;

                m_Stylesheet = new XElement(xsl + "stylesheet",
                    new XAttribute("version", "1.0"),
                    new XAttribute(XNamespace.Xmlns + "xsl", xsl),
                    new XAttribute(XNamespace.Xmlns + "msxsl", msxsl),
                    new XAttribute("exclude-result-prefixes", "msxsl"));
                output.Add(m_Stylesheet);

                m_Stylesheet.Add(new XElement(xsl + "output",
                    new XAttribute("method", "xml"),
                    new XAttribute("indent", "yes")));

                XElement rootTemplate = new XElement(xsl + "template",
                    new XAttribute("name", "root"),
                    new XAttribute("match", "/"));
                m_Stylesheet.Add(rootTemplate);

                XElement rootElement = new XElement(DataScope.RootScopeName);
                rootTemplate.Add(rootElement);

                zTranslateRecursive(rootElement, sequence, "root", null);

                if (m_CaseTranslationRequired)
                {
                    m_Stylesheet.Add(new XElement(xsl + "variable",
                        new XAttribute("name", "lowerCase"),
                        new XAttribute("select", "'abcdefghijklmnopqrstuvwxyz'")));
                    m_Stylesheet.Add(new XElement(xsl + "variable",
                        new XAttribute("name", "upperCase"),
                        new XAttribute("select", "'ABCDEFGHIJKLMNOPQRSTUVWXYZ'")));
                }

                StringBuilder sb = new StringBuilder();
                using (TextWriter writer = new UTF8StringWriter(sb))
                {
                    output.Save(writer);
                }
                return sb.ToString();
            }
        }

        private void zTranslateRecursive(XElement containerElement, List<Step> steps, string templateName, ElementIdentifier templateSelectorIdentifier)
        {
            foreach (GetValueStep getValueStep in steps.OfType<GetValueStep>())
            {
                if (getValueStep.XMLFieldOutputMode != XMLFieldOutputMode.None)
                {
                    string elementName = getValueStep.StateVariable;

                    XElement dataElement;
                    if (getValueStep.XMLFieldOutputMode == XMLFieldOutputMode.Element)
                    {
                        dataElement = new XElement(elementName);
                    }
                    else
                    {
                        dataElement = new XElement(xsl + "attribute",
                            new XAttribute("name", elementName));

                    }
                    dataElement.Add(zGetNormalizedDataSelector(getValueStep, templateSelectorIdentifier));
                    containerElement.Add(dataElement);
                }
            }
            foreach (GroupStep groupStep in steps.OfType<GroupStep>())
            {
                if (groupStep.Iteration is ElementSetIteration 
                    && groupStep.Iteration.IsSetIteration 
                    && ((ElementSetIteration)groupStep.Iteration).IncludeInXML)
                {
                    ElementSetIteration iteration = (ElementSetIteration)groupStep.Iteration;

                    string childTemplateName = String.Format("{0}.{1}", templateName, iteration.ObjectSetClassName.ToLower());
                    string childTemplateSelectPath = zGetRelativeSelectorPathForXSLT(templateSelectorIdentifier, iteration.ElementSetContainer);
                    XElement listDataElement = new XElement(iteration.ObjectSetListName,
                        new XElement(xsl + "for-each",
                            new XAttribute("select", childTemplateSelectPath),
                            new XElement(xsl + "call-template",
                                new XAttribute("name", childTemplateName))));
                    containerElement.Add(listDataElement);

                    XElement childTemplate = new XElement(xsl + "template",
                        new XAttribute("name", childTemplateName));
                    m_Stylesheet.Add(childTemplate);
                    XElement childContainerElement = new XElement(iteration.ObjectSetClassName);
                    XElement childTemplateConditional = zGetTemplateConditional(groupStep.Steps, iteration.ElementSetContainer);
                    if (childTemplateConditional != null)
                    {
                        childTemplate.Add(childTemplateConditional);
                        childTemplateConditional.Add(childContainerElement);
                    }
                    else
                    {
                        childTemplate.Add(childContainerElement);
                    }
                    zTranslateRecursive(childContainerElement, groupStep.Steps, childTemplateName, iteration.ElementSetContainer);
                }
                else
                {
                    zTranslateRecursive(containerElement, groupStep.Steps, templateName, templateSelectorIdentifier);
                }
            }
        }

        private XElement zGetNormalizedDataSelector(GetValueStep getValueStep, ElementIdentifier templateSelectorIdentifier)
        {
            string selectPath = zGetSelectPathForGetValueStep(getValueStep, templateSelectorIdentifier);
            XElement defaultSelector = getValueStep.UseNormalizationDefault 
                ? new XElement(xsl + "text", getValueStep.NormalizationDefault)
                : new XElement(xsl + "value-of", 
                    new XAttribute("select", selectPath));

            if (getValueStep.NormalizationRules.Count > 0)
            {
                XElement choose = new XElement(xsl + "choose");
                foreach (GetValueNormalizationRule normalizationRule in getValueStep.NormalizationRules)
                {
                    choose.Add(new XElement(xsl + "when",
                        new XAttribute("test", zGetNormalizationRuleTestCondition(normalizationRule, selectPath)),
                        new XElement(xsl + "text", normalizationRule.ReplacementValue)));
                }
                choose.Add(new XElement(xsl + "otherwise", defaultSelector));
                return choose;
            }
            else
            {
                return defaultSelector;
            }
        }

        private string zGetNormalizationRuleTestCondition(GetValueNormalizationRule normalizationRule, string selectPath)
        {
            string testCondition = selectPath;
            if (normalizationRule.Trim)
            {
                testCondition = String.Format("normalize-space({0})", testCondition);
            }
            if (!normalizationRule.CaseSensitive)
            {
                testCondition = String.Format("translate({0}, $upperCase, $lowerCase)", testCondition);
                m_CaseTranslationRequired = true;
            }
            string ruleOriginalValue = normalizationRule.CaseSensitive ? normalizationRule.OriginalValue : normalizationRule.OriginalValue.ToLower();
            
            switch (normalizationRule.Comparative)
            {
                case Comparative.Equals:
                    testCondition = String.Format("{0} = '{1}'", testCondition, ruleOriginalValue);
                    break;
                case Comparative.Contains:
                    testCondition = String.Format("contains({0}, '{1}')", testCondition, ruleOriginalValue);
                    break;
                case Comparative.BeginsWith:
                    testCondition = String.Format("starts-with({0}, '{1}')", testCondition, ruleOriginalValue);
                    break;
                case Comparative.EndsWith:
                    testCondition = String.Format("'{1}' = substring({0}, string-length({0}) - string-length('{1}') + 1)", testCondition, ruleOriginalValue);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return testCondition;
        }

        private XElement zGetTemplateConditional(List<Step> steps, ElementIdentifier templateSelectorIdentifier)
        {
            List<GetValueStep> requiredGetValueSteps = steps.OfType<GetValueStep>()
                .Where(gvs => gvs.FailureScope != StepFailureScope.Step)
                .ToList();
            if (requiredGetValueSteps.Count > 0)
            {
                StringBuilder conditionBuilder = new StringBuilder();
                for (int x = 0; x < requiredGetValueSteps.Count; x++)
                {
                    string selectPath = zGetSelectPathForGetValueStep(requiredGetValueSteps[x], templateSelectorIdentifier);
                    conditionBuilder.Append(selectPath);
                    if (x < requiredGetValueSteps.Count - 1)
                    {
                        conditionBuilder.Append(" and ");
                    }
                }
                XElement conditionalElement = new XElement(xsl + "if",
                    new XAttribute("test", conditionBuilder.ToString()));
                return conditionalElement;
            }
            return null;
        }

        private string zGetSelectPathForGetValueStep(GetValueStep getValueStep, ElementIdentifier templateSelectorIdentifier)
        {
            string selectPath = zGetRelativeSelectorPathForXSLT(templateSelectorIdentifier, getValueStep.Element);
            if (getValueStep.Mode == ElementValueMode.Attribute && !String.IsNullOrEmpty(getValueStep.AttributeName))
            {
                selectPath = String.Format("{0}/@{1}", selectPath, getValueStep.AttributeName);
            }
            return selectPath;
        }

        private string zGetRelativeSelectorPathForXSLT(ElementIdentifier baseIdentifier, ElementIdentifier targetIdentifier)
        {
            string selectPath = String.Empty;
            if (targetIdentifier != null)
            {
                if (baseIdentifier != null)
                {
                    targetIdentifier = targetIdentifier.RelativeTo(baseIdentifier);
                }
                if (targetIdentifier.PrimaryIdentifier != null)
                {
                    selectPath = targetIdentifier.PrimaryIdentifier.Replace('"', '\'');

                    //Strip out tbody tags from path... they are not supported in the XML transformation of the DOM.
                    selectPath = Regex.Replace(selectPath, "/?/?tbody[^/]*", String.Empty, RegexOptions.IgnoreCase);
                    
                    if (baseIdentifier != null && selectPath.StartsWith("/"))
                    {
                        selectPath = selectPath.Remove(0, 1);
                    }
                }
            }
            return selectPath;
        }
    }
}
