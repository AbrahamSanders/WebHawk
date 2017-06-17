using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Data
{
    public static class DataUtils
    {
        public static void ParseStateVariableName(string currentScopeName, string stateVariableName, out string scopeNamePart, out string variableNamePart)
        {
            string[] variableNameParts = stateVariableName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (variableNameParts.Length > 1)
            {
                scopeNamePart = variableNameParts[0];
                variableNamePart = variableNameParts[1];
            }
            else
            {
                scopeNamePart = currentScopeName;
                variableNamePart = variableNameParts[0];
            }
        }

        public static string GetUnscopedVariableName(string stateVariableName)
        {
            int scopeSeparatorIndex = stateVariableName.IndexOf('.');
            if (scopeSeparatorIndex > -1)
            {
                if (scopeSeparatorIndex < (stateVariableName.Length - 1))
                {
                    stateVariableName = stateVariableName.Substring(scopeSeparatorIndex + 1);
                }
                else
                {
                    stateVariableName = String.Empty;
                }
            }
            return stateVariableName;
        }

        public static string GetVariableNameScope(string stateVariableName)
        {
            int scopeSeparatorIndex = stateVariableName.IndexOf('.');
            if (scopeSeparatorIndex > 0)
            {
                return stateVariableName.Substring(0, scopeSeparatorIndex);
            }
            return String.Empty;
        }

        public static string ApplyStateVariablesToString(string str, DataScope dataScope, bool trimVariableValueWhitespace)
        {
            if (str == null)
            {
                return String.Empty;
            }
            return Regex.Replace(str, 
                "{(.+?)}",
                match => zGetVariableReplacement(match, dataScope, ref trimVariableValueWhitespace), 
                RegexOptions.None);
        }

        private static string zGetVariableReplacement(Match regexMatch, DataScope dataScope, ref bool trimVariableValueWhitespace)
        {
            if (regexMatch.Success && regexMatch.Groups.Count > 1)
            {
                Group matchGroup = regexMatch.Groups[1];
                if (matchGroup.Success)
                {
                    string variableName = matchGroup.Value;
                    Data.IStateVariable variable = dataScope.GetStateVariable(variableName);
                    if (variable != null)
                    {
                        string variableValue = variable.ValueAsString();
                        if (trimVariableValueWhitespace)
                        {
                            variableValue = variableValue.Trim();
                        }
                        return variableValue;
                    }
                }
            }
            return String.Empty;
        }
    }
}
