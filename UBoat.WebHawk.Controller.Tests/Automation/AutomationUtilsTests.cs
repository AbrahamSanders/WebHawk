using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Tests.Automation
{
    [TestClass]
    public class AutomationUtilsTests
    {
        #region GetVariablesInStepScope Tests

        /// <summary>
        /// A basic single-level usage.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest1()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new SetValueStep()
            };

            Step step = sequence.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2"));
        }

        /// <summary>
        /// One group with no iteration.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest2()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Steps = new List<Step>()
                    {
                        new ClickStep(),
                        new GetValueStep() { StateVariable = "Variable3" },
                        new ClickStep()
                    }
                },
                new SetValueStep()
            };

            Step step = sequence.OfType<GroupStep>().First().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3"));

            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3"));
        }

        /// <summary>
        /// Two nested group levels with no iteration.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest3()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Steps = new List<Step>()
                    {
                        new ClickStep(),
                        new GetValueStep() { StateVariable = "Variable3" },
                        new GroupStep()
                        {
                            Steps = new List<Step>()
                            {
                                new GetValueStep() { StateVariable = "Variable4" },
                                new ClickStep()
                            }
                        },
                        new GroupStep()
                        {
                            Steps = new List<Step>()
                            {
                                new SetValueStep(),
                                new SetValueStep()
                            }
                        },
                        new ClickStep()
                    }
                },
                new SetValueStep()
            };

            Step step = sequence.OfType<GroupStep>().First().Steps.OfType<GroupStep>().First().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable4"));

            step = sequence.OfType<GroupStep>().First().Steps.OfType<GroupStep>().Last().Steps.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable4"));
        }

        /// <summary>
        /// One group with Fixed iteration.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest4()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new FixedIteration(),
                    Steps = new List<Step>()
                    {
                        new ClickStep(),
                        new GetValueStep() { StateVariable = "Variable3" },
                        new ClickStep()
                    }
                },
                new SetValueStep()
            };

            Step step = sequence.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3"));
        }

        /// <summary>
        /// One group with ElementSet iteration.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest5A()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope",
                    },
                    Steps = new List<Step>()
                    {
                        new ClickStep(),
                        new GetValueStep() { StateVariable = "Variable3" },
                        new ClickStep()
                    }
                },
                new SetValueStep()
            };

            Step step = sequence.OfType<GroupStep>().First().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3"));

            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3"));
        }

        /// <summary>
        /// One group with ElementSet iteration and no ObjectSetClassName.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest5B()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration(),
                    Steps = new List<Step>()
                    {
                        new ClickStep(),
                        new GetValueStep() { StateVariable = "Variable3" },
                        new ClickStep()
                    }
                },
                new SetValueStep()
            };

            Step step = sequence.OfType<GroupStep>().First().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3"));

            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable3"));
        }

        /// <summary>
        /// One group with ElementSet iteration and GetValueStep targeting root scope
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest5C()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope",
                    },
                    Steps = new List<Step>()
                    {
                        new ClickStep(),
                        new GetValueStep() { StateVariable = "Variable3" },
                        new GetValueStep() { StateVariable = "Root.Variable4" },
                        new ClickStep()
                    }
                },
                new SetValueStep()
            };

            Step step = sequence.OfType<GroupStep>().First().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3"));

            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3"));
        }

        /// <summary>
        /// One group with ElementSet and DataSet iterations, where DataSet has a ClassName.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest6A()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope"
                    },
                    Steps = new List<Step>()
                    {
                        new GetValueStep() { StateVariable = "Variable3" },
                        new GetValueStep() { StateVariable = "Variable4" },
                        new GetValueStep() { StateVariable = "Variable5" }
                    }
                },
                new NavigateStep(),
                new ClickStep(),
                new GroupStep()
                {
                    Iteration = new DataSetIteration()
                    {
                        ObjectSetListName = "Root.ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScopeAgain"
                    },
                    Steps = new List<Step>()
                    {
                        new SetValueStep(),
                        new SetValueStep(),
                        new SetValueStep()
                    }
                },
                new ClickStep()
            };

            Step step = sequence.OfType<GroupStep>().Last().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable5"));

            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3"));
        }

        /// <summary>
        /// One group with ElementSet and DataSet iterations, where DataSet has no ClassName.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest6B()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope"
                    },
                    Steps = new List<Step>()
                    {
                        new GetValueStep() { StateVariable = "Variable3" },
                        new GetValueStep() { StateVariable = "Variable4" },
                        new GetValueStep() { StateVariable = "Variable5" }
                    }
                },
                new NavigateStep(),
                new ClickStep(),
                new GroupStep()
                {
                    Iteration = new DataSetIteration()
                    {
                        ObjectSetListName = "Root.ObjectList",
                        ObjectSetScopeName = "objectScopeAgain"
                    },
                    Steps = new List<Step>()
                    {
                        new SetValueStep(),
                        new SetValueStep(),
                        new SetValueStep()
                    }
                },
                new ClickStep()
            };

            Step step = sequence.OfType<GroupStep>().Last().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable5"));

            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3"));
        }

        /// <summary>
        /// Two nested group levels with ElementSet and DataSet iterations, where DataSets have ClassNames.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest7A()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope"
                    },
                    Steps = new List<Step>()
                    {
                        new GetValueStep() { StateVariable = "Variable3" },
                        new GetValueStep() { StateVariable = "Variable4" },
                        new GetValueStep() { StateVariable = "Variable5" },
                        new GroupStep()
                        {
                            Iteration = new ElementSetIteration()
                            {
                                ObjectSetListName = "ObjectList2",
                                ObjectSetClassName = "Object2",
                                ObjectSetScopeName = "objectScope2",
                            },
                            Steps = new List<Step>()
                            {
                                new GetValueStep() { StateVariable = "Variable6" },
                                new GetValueStep() { StateVariable = "Variable7" },
                                new GetValueStep() { StateVariable = "Variable8" },
                                new ClickStep()
                            }
                        },
                        new ClickStep()
                    }
                },
                new NavigateStep(),
                new ClickStep(),
                new GroupStep()
                {
                    Iteration = new DataSetIteration()
                    {
                        ObjectSetListName = "Root.ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScopeAgain"
                    },
                    Steps = new List<Step>()
                    {
                        new SetValueStep(),
                        new SetValueStep(),
                        new SetValueStep(),
                        new GroupStep()
                        {
                            Iteration = new DataSetIteration()
                            {
                                ObjectSetListName = "objectScopeAgain.ObjectList2",
                                ObjectSetClassName = "Object2",
                                ObjectSetScopeName = "objectScope2Again"
                            },
                            Steps = new List<Step>()
                            {
                                new SetValueStep(),
                                new SetValueStep(),
                                new SetValueStep()
                            }
                        }
                    }
                },
                new ClickStep()
            };

            //Test1: First level ElementSet
            Step step = sequence.OfType<GroupStep>().First().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable5")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.ObjectList2"));

            //Test2: Second level ElementSet
            step = sequence.OfType<GroupStep>().First().Steps.OfType<GroupStep>().First().Steps.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable5")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope.ObjectList2")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2.Variable6")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2.Variable7")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2.Variable8"));

            //Test3: First level DataSet
            step = sequence.OfType<GroupStep>().Last().Steps.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable5")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.ObjectList2"));

            //Test4: Second level DataSet
            step = sequence.OfType<GroupStep>().Last().Steps.OfType<GroupStep>().First().Steps.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable5")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.ObjectList2")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2Again.Variable6")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2Again.Variable7")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2Again.Variable8"));

            //Test5: Base level last step
            step = sequence.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScope.Variable3")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3"));
        }

        /// <summary>
        /// Two nested group levels with ElementSet and DataSet iterations, where DataSets have no ClassNames.
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest7B()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope"
                    },
                    Steps = new List<Step>()
                    {
                        new GetValueStep() { StateVariable = "Variable3" },
                        new GetValueStep() { StateVariable = "Variable4" },
                        new GetValueStep() { StateVariable = "Variable5" },
                        new GroupStep()
                        {
                            Iteration = new ElementSetIteration()
                            {
                                ObjectSetListName = "ObjectList2",
                                ObjectSetClassName = "Object2",
                                ObjectSetScopeName = "objectScope2",
                            },
                            Steps = new List<Step>()
                            {
                                new GetValueStep() { StateVariable = "Variable6" },
                                new GetValueStep() { StateVariable = "Variable7" },
                                new GetValueStep() { StateVariable = "Variable8" },
                                new ClickStep()
                            }
                        },
                        new ClickStep()
                    }
                },
                new NavigateStep(),
                new ClickStep(),
                new GroupStep()
                {
                    Iteration = new DataSetIteration()
                    {
                        ObjectSetListName = "Root.ObjectList",
                        ObjectSetScopeName = "objectScopeAgain"
                    },
                    Steps = new List<Step>()
                    {
                        new SetValueStep(),
                        new SetValueStep(),
                        new SetValueStep(),
                        new GroupStep()
                        {
                            Iteration = new DataSetIteration()
                            {
                                ObjectSetListName = "objectScopeAgain.ObjectList2",
                                ObjectSetScopeName = "objectScope2Again"
                            },
                            Steps = new List<Step>()
                            {
                                new SetValueStep(),
                                new SetValueStep(),
                                new SetValueStep()
                            }
                        }
                    }
                },
                new ClickStep()
            };

            //Test1: First level DataSet
            Step step = sequence.OfType<GroupStep>().Last().Steps.Last();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable5")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.ObjectList2"));

            //Test2: Second level DataSet
            step = sequence.OfType<GroupStep>().Last().Steps.OfType<GroupStep>().First().Steps.Last();
            variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "Root.Variable2")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable4")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable5")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.ObjectList2")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2Again.Variable6")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2Again.Variable7")
                && variablesInScope.Any(v => v.StateVariableName == "objectScope2Again.Variable8"));
        }

        /// <summary>
        /// Step not in sequence
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest8()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new SetValueStep()
            };

            Step step = new ClickStep();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null && variablesInScope.Count == 0);
        }

        /// <summary>
        /// No variables in step scope
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest9()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new ClickStep(),
                new GetValueStep() { StateVariable = "Variable1" },
                new GetValueStep() { StateVariable = "Variable2" },
                new SetValueStep()
            };

            Step step = sequence[2];
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);
            Assert.IsTrue(variablesInScope != null && variablesInScope.Count == 0);
        }

        /// <summary>
        /// ObjectSetIteration on a persisted list before the list is declared
        /// </summary>
        [TestMethod]
        public void GetVariablesInStepScopeTest10()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new GroupStep()
                {
                    Iteration = new DataSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetScopeName = "objectScopeAgain"
                    },
                    Steps = new List<Step>()
                    {
                        new SetValueStep()
                    }
                },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScope",
                        PersistenceMode = PersistenceMode.Persisted
                    },
                    Steps = new List<Step>()
                    {
                        new GetValueStep() { StateVariable = "Variable1", PersistenceMode = PersistenceMode.Persisted },
                        new GetValueStep() { StateVariable = "Variable2", PersistenceMode = PersistenceMode.Persisted },
                        new GetValueStep() { StateVariable = "Variable3" }
                    }
                },
                new GroupStep()
                {
                    Iteration = new ElementSetIteration()
                    {
                        ObjectSetListName = "ObjectList2",
                        ObjectSetClassName = "Object",
                        ObjectSetScopeName = "objectScopeAgain",
                        PersistenceMode = PersistenceMode.Persisted
                    },
                    Steps = new List<Step>()
                    {
                        new GetValueStep() { StateVariable = "Variable6", PersistenceMode = PersistenceMode.Persisted }
                    }
                }
            };

            Step step = sequence.OfType<GroupStep>().First().Steps.First();
            List<StateVariableInfo> variablesInScope = AutomationUtils.GetVariablesInStepScope(sequence, step);

            Assert.IsTrue(variablesInScope != null
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList")
                && variablesInScope.Any(v => v.StateVariableName == "Root.ObjectList2")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable1")
                && variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable2")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable3")
                && !variablesInScope.Any(v => v.StateVariableName == "objectScopeAgain.Variable6"));
        }

        #endregion
    }
}
