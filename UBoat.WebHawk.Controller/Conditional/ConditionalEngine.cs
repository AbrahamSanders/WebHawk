using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Data;
using model = UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    public class ConditionalEngine
    {
        public bool CheckCondition(model.ConditionNode condition, DataScope dataScope)
        {
            if (condition == null)
            {
                return true;
            }
            if (condition is model.LogicalNode)
            {
                model.LogicalNode logicalNode = (model.LogicalNode)condition;
                bool? aggregateResult = null;
                foreach (model.ConditionNode node in logicalNode.Nodes)
                {
                    bool nodeResult = CheckCondition(node, dataScope);
                    if (aggregateResult == null)
                    {
                        aggregateResult = nodeResult;
                        continue;
                    }
                    if (logicalNode.ConditionalOperator == model.Conditional.And)
                    {
                        aggregateResult = aggregateResult.Value && nodeResult;
                        if (!aggregateResult.Value)
                        {
                            break;
                        }
                    }
                    else if (logicalNode.ConditionalOperator == model.Conditional.Or)
                    {
                        aggregateResult = aggregateResult.Value || nodeResult;
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
                return aggregateResult.Value;
            }
            else
            {
                model.ExpressionNode expressionNode = (model.ExpressionNode)condition;
                IExpressionEvaluator evaluator = ExpressionEvaluatorFactory.GetExpressionEvaulator(expressionNode.DataType);
                return evaluator.EvaulateExpression(expressionNode, dataScope);
            }
        }
    }
}
