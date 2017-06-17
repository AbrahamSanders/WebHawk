using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public abstract class Step
    {
        public ConditionNode Condition { get; set; }
        public StepFailureScope FailureScope { get; set; }

        public string DisplayName
        {
            get
            {
                return get_DisplayNameImpl();
            }
            private set
            {
                //Serialization sucks.
            }
        }

        protected Step()
        {
            this.FailureScope = StepFailureScope.Step;
        }

        protected abstract string get_DisplayNameImpl();

        public override string ToString()
        {
            return this.DisplayName;
        }

        public static List<Step> GetAvailableStepList(bool includeElementSteps)
        {
            Assembly assm = Assembly.GetAssembly(typeof(Step));
            List<Type> stepTypes = assm.GetTypes()
                .Where(t => t.IsPublic && !t.IsAbstract && t.IsSubclassOf(typeof(Step)) 
                    && (includeElementSteps || !t.IsSubclassOf(typeof(ElementStep))))
                .ToList();

            List<Step> availableSteps = new List<Step>();
            foreach (Type stepType in stepTypes)
            {
                Step instance = (Step)assm.CreateInstance(stepType.FullName);
                availableSteps.Add(instance);
            }

            return availableSteps;
        }

        public static Step CreateInstance(Type stepType)
        {
            Assembly assm = Assembly.GetAssembly(stepType);
            return (Step)assm.CreateInstance(stepType.FullName);
        }
    }
}
