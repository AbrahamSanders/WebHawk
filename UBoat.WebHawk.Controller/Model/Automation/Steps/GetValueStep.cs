using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class GetValueStep : ElementValueStep
    {
        public string StateVariable { get; set; }
        public XMLFieldOutputMode XMLFieldOutputMode { get; set; }
        public PersistenceMode PersistenceMode { get; set; }
        public List<GetValueNormalizationRule> NormalizationRules { get; private set; }
        public bool UseNormalizationDefault { get; set; }
        public string NormalizationDefault { get; set; }

        public GetValueStep()
        {
            this.NormalizationRules = new List<GetValueNormalizationRule>();
        }

        protected override string get_DisplayNameImpl()
        {
            return "Get Element Value";
        }
    }

    [Serializable]
    public class GetValueNormalizationRule
    {
        public Comparative Comparative { get; set; }
        public string OriginalValue { get; set; }
        public string ReplacementValue { get; set; }
        public bool CaseSensitive { get; set; }
        public bool Trim { get; set; }
        public bool ReplaceWholeOriginalValue { get; set; }

        public GetValueNormalizationRule Clone()
        {
            return (GetValueNormalizationRule)this.MemberwiseClone();
        }
    }
}
