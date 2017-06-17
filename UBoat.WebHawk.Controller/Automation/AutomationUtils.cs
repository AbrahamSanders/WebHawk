using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Automation
{
    public static class AutomationUtils
    {
        public static string GetValueFromHtmlElement(HtmlElement element, ElementValueMode mode, string attributeName)
        {
            string value;
            if (mode == ElementValueMode.Attribute)
            {
                string attr = attributeName != null ? attributeName.ToLower() : String.Empty;
                if (attr == "style")
                {
                    value = element.Style != null ? element.Style.ToLower() : String.Empty;
                }
                else
                {
                    if (attr == "class")
                    {
                        //IE uses className instead of class in its DOM model. Yup I know, it's bullshit.
                        attr = "classname";
                    }
                    value = element.GetAttribute(attr);
                }
            }
            else
            {
                value = element.InnerText ?? String.Empty;
            }
            return value;
        }

        public static void SetValueToHtmlElement(HtmlElement element, ElementValueMode mode, string attributeName, string value)
        {
            if (mode == ElementValueMode.Attribute)
            {
                if (!string.IsNullOrEmpty(attributeName))
                {
                    string attr = attributeName.ToLower();
                    if (attr == "style")
                    {
                        element.Style = value;
                    }
                    else
                    {
                        if (attr == "class")
                        {
                            //IE uses className instead of class in its DOM model. Yup I know, it's bullshit.
                            attr = "classname";
                        }
                        element.SetAttribute(attr, value);
                    }
                }
            }
            else
            {
                element.InnerText = value;
            }
        }

        public static List<Step> GetStepParent(List<Step> container, Step step)
        {
            if (container.Contains(step))
            {
                return container;
            }
            foreach (GroupStep iStep in container.OfType<GroupStep>())
            {
                List<Step> stepParent = GetStepParent(iStep.Steps, step);
                if (stepParent != null)
                {
                    return stepParent;
                }
            }
            return null;
        }

        public static GroupStep GetParentGroupStep(List<Step> container, Step step)
        {
            foreach (GroupStep iStep in container.OfType<GroupStep>())
            {
                if (iStep.Steps.Contains(step))
                {
                    return iStep;
                }
                GroupStep parentGroupStep = GetParentGroupStep(iStep.Steps, step);
                if (parentGroupStep != null)
                {
                    return parentGroupStep;
                }
            }
            return null;
        }

        public static int RecursiveStepCount(List<Step> container)
        {
            int count = container.Count;
            foreach (GroupStep groupStep in container.OfType<GroupStep>())
            {
                count += RecursiveStepCount(groupStep.Steps);
            }
            return count;
        }

        public static T FindStep<T>(List<Step> container, Predicate<T> predicate) where T : Step
        {
            foreach (T step in container.OfType<T>())
            {
                if (predicate(step))
                {
                    return step;
                }
            }
            foreach (GroupStep groupStep in container.OfType<GroupStep>())
            {
                T result = FindStep<T>(groupStep.Steps, predicate);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public static List<StateVariableInfo> GetVariablesInStepScope(List<Step> sequence, Step step)
        {
            SequenceAnalyzer sequenceAnalyzer = new SequenceAnalyzer();
            return sequenceAnalyzer.GetVariablesInStepScope(sequence, step);
        }

        public static List<string> GetListClassNamesInStepScope(List<Step> sequence, Step step, string objectSetListName)
        {
            SequenceAnalyzer sequenceAnalyzer = new SequenceAnalyzer();
            return sequenceAnalyzer.GetListClassNamesInStepScope(sequence, step, objectSetListName);
        }
    }
}
