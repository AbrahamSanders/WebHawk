using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Automation.Iterators;

namespace UBoat.WebHawk.Controller.Tests.Automation
{
    [TestClass]
    public class ExecutionStackTests
    {
        [TestMethod]
        public void SetSequenceTest()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep()
            };
            ExecutionStack executionStack = new ExecutionStack();
            executionStack.SetSequence(sequence);

            Assert.IsNotNull(executionStack.CurrentBranch);
        }

        [TestMethod]
        public void SetNewBranchTest1()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new GroupStep()
                {
                     Steps = new List<Step>()
                     {
                         new GetValueStep(),
                         new GetValueStep()
                     }
                }
            };
            ExecutionStack executionStack = new ExecutionStack();
            executionStack.SetSequence(sequence);

            List<Step> newBranch = ((GroupStep)sequence[1]).Steps;
            executionStack.SetNewBranch(newBranch);
            PrivateObject m_PendingBranch = new PrivateObject(executionStack, "m_PendingBranch");

            Assert.IsTrue(m_PendingBranch
                .GetProperty("Steps", null)
                .Equals(newBranch));
        }

        [TestMethod]
        public void SetNewBranchTest2()
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep(),
                new GroupStep()
                {
                     Steps = new List<Step>()
                     {
                         new GetValueStep(),
                         new GetValueStep()
                     }
                }
            };
            ExecutionStack executionStack = new ExecutionStack();
            executionStack.SetSequence(sequence);

            List<Step> newBranch = ((GroupStep)sequence[1]).Steps;
            FixedIterator iterator = new FixedIterator(new FixedIteration());
            executionStack.SetNewBranch(newBranch, iterator);
            
            PrivateObject m_PendingBranch = new PrivateObject(executionStack, "m_PendingBranch");
            
            Assert.IsTrue(m_PendingBranch
                .GetProperty("Steps", null)
                .Equals(newBranch));
            
            Assert.IsTrue(m_PendingBranch
                .GetProperty("IterationContext", null)
                .Equals(iterator));
        }

        [TestMethod]
        public void BreakBranchTest()
        {
            ExecutionStack executionStack = new ExecutionStack();
            executionStack.BreakBranch();

            PrivateObject m_BreakBranch = new PrivateObject(executionStack, "m_BreakBranch");

            Assert.IsTrue((bool)m_BreakBranch.Target);
        }

        [TestMethod]
        public void SkipIterationTest()
        {
            ExecutionStack executionStack = new ExecutionStack();
            executionStack.SkipIteration();

            PrivateObject m_SkipIteration = new PrivateObject(executionStack, "m_SkipIteration");

            Assert.IsTrue((bool)m_SkipIteration.Target);
        }
    }
}
