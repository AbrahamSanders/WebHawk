using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class GetValueStepExecutor : ElementStepExecutor<GetValueStep>
    {
        protected override void OnElementLocated(HtmlElement element)
        {
            string value = AutomationUtils.GetValueFromHtmlElement(element, m_Step.Mode, m_Step.AttributeName);
            value = zApplyNormalizationRules(value);

            CurrentScope.DataScope.SetStateVariable(m_Step.StateVariable, 
                new StateVariable<string>(DataUtils.GetUnscopedVariableName(m_Step.StateVariable), 
                    DataType.String, 
                    m_Step.XMLFieldOutputMode,
                    m_Step.PersistenceMode,
                    value));

            zCompleteStep(StepResult.Success);
        }

        private string zApplyNormalizationRules(string value)
        {
            if (value == null)
            {
                value = String.Empty;
            }

            //Run whole replacement rules
            foreach (GetValueNormalizationRule normalizationRule in m_Step.NormalizationRules.Where(r => r.ReplaceWholeOriginalValue))
            {
                bool isMatch = zEvaluateMatch(value, normalizationRule);
                if (isMatch)
                {
                    return normalizationRule.ReplacementValue;
                }
            }

            //Run find-replace rules
            bool matchFound = false;
            foreach (GetValueNormalizationRule normalizationRule in m_Step.NormalizationRules.Where(r => !r.ReplaceWholeOriginalValue))
            {
                bool isMatch = zEvaluateMatch(value, normalizationRule);
                if (isMatch)
                {
                    matchFound = true;
                    value = zFindReplace(value, normalizationRule);
                }
            }

            if (!matchFound && m_Step.UseNormalizationDefault)
            {
                return m_Step.NormalizationDefault;
            }
            else
            {
                return value;
            }
        }

        private bool zEvaluateMatch(string originalValue, GetValueNormalizationRule normalizationRule)
        {
            if (normalizationRule.Trim)
            {
                originalValue = originalValue.Trim();
            }
            string regex = zBuildRegex(normalizationRule);
            return Regex.IsMatch(originalValue, regex, normalizationRule.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
        }

        private string zFindReplace(string originalValue, GetValueNormalizationRule normalizationRule)
        {
            if (normalizationRule.Trim)
            {
                originalValue = originalValue.Trim();
            }
            string regex = zBuildRegex(normalizationRule);
            return Regex.Replace(originalValue, 
                regex, 
                normalizationRule.ReplacementValue, 
                normalizationRule.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
        }

        private string zBuildRegex(GetValueNormalizationRule normalizationRule)
        {
            switch (normalizationRule.Comparative)
            {
                case Comparative.Equals:
                    return String.Format(@"\A{0}\Z", Regex.Escape(normalizationRule.OriginalValue));
                case Comparative.BeginsWith:
                    return String.Format(@"\A{0}", Regex.Escape(normalizationRule.OriginalValue));
                case Comparative.EndsWith:
                    return String.Format(@"{0}\Z", Regex.Escape(normalizationRule.OriginalValue));
                case Comparative.Contains:
                    return Regex.Escape(normalizationRule.OriginalValue);
                case Comparative.RegexMatch:
                    return normalizationRule.OriginalValue;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
