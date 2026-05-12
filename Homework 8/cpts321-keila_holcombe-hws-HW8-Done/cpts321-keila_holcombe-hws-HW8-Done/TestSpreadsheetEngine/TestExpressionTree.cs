// <copyright file="TestExpressionTree.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using SpreadsheetEngine;

namespace TestSpreadsheetEngine
{
    /// <summary>
    /// Testing methods in ExpressionTree class such as evaluate() and SetVariable() to make sure they are working correctly.
    /// </summary>
    internal class TestExpressionTree
    {
        /// <summary>
        /// Testing a normal case for evaluate() if it is able to evaluate a single number.
        /// </summary>
        [Test]
        public void TestEvaluateNumeric()
        {
            string expression = "1";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            double? testValue = expressionTree.Evaluate();
            double expectedValue = 1;
            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(expectedValue));
            }
        }

        /// <summary>
        /// Testing a normal case for evaluate() to see if it's able to return a correct value when evaluating a single variable.
        /// </summary>
        [Test]
        public void TestEvaluateVariable()
        {
            string expression = "A1";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A1", 5.3);
            double? testValue = expressionTree.Evaluate();
            double expectedValue = 5.3;

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(expectedValue));
            }
        }

        /// <summary>
        /// Testing a normal case for evaluate() method to see if it's able to return 0 when evaluating a unsetted variable.
        /// </summary>
        [Test]
        public void TestUnsetVariable()
        {
            string expression = "A5";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(testValue, Is.EqualTo(0));
            }
        }

        /// <summary>
        /// Testing a normal case for evaluate() to see if it's able add numbers and variables together.
        /// </summary>
        [Test]
        public void TestEvaluateAddition()
        {
            string expression = "1+A1+4";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A1", 5.3);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(10.3));
            }
        }

        /// <summary>
        /// Testing a normal case for evaluate() to see if it's able to accept parenthasis, numbers and variables together.
        /// </summary>
        [Test]
        public void TestEvaluateSubtraction()
        {
            string expression = "(10-(((A1-3)+4)))";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A1", 5);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(4));
            }
        }

        /// <summary>
        /// Testing a normal case for evaluate() tp see of it's able to multiply and subtract numbers and variables together.
        /// </summary>
        [Test]
        public void TestEvaluateMultiplication()
        {
            string expression = "5*(A1-3)";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A1", 4);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(5));
            }
        }

        /// <summary>
        /// Testing a normal case for evaluate() to see if it's able to divide numbers and variables together and also in order.
        /// </summary>
        [Test]
        public void TestEvaluateDivision()
        {
            string expression = "3+2/A1";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A1", 2);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(4));
            }
        }

        /// <summary>
        /// Testing a boundary case for evaluate() to see if it's able to handle zero divisions.
        /// </summary>
        [Test]
        public void TestEvaluateZeroDivision()
        {
            string expression = "0/0";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(double.NaN));
            }
        }

        /// <summary>
        /// Testing a edge case for evaluate() to see if it's able to handle empty strings.
        /// </summary>
        [Test]
        public void TestEvaluateEmpty()
        {
            string expression = string.Empty;
            ExpressionTree expressionTree = new ExpressionTree(expression);
            double? testValue = expressionTree.Evaluate();

            Assert.That(testValue, Is.Null);
        }

        /// <summary>
        /// Testing an edge case for evaluate() to see if it's able to handle un recognize operators.
        /// </summary>
        [Test]
        public void TestEvaluateUnHandleOperator()
        {
            string expression = "4^2";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            double? testValue = expressionTree.Evaluate();

            Assert.That(testValue, Is.Null);
        }

        /// <summary>
        /// Testing a normal case for SetVariable() to see if it's able to make a single character variable.
        /// </summary>
        [Test]
        public void TestSetVariableSingleChar()
        {
            string expression = "A";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A", 5);
            double? testValue = expressionTree.Evaluate();
            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(5));
            }
        }

        /// <summary>
        /// Testing a normal case for SetVariable() to see if it's able to make a variable with more characters.
        /// </summary>
        [Test]
        public void TestSetVariableMoreChar()
        {
            string expression = "A123weas";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A123weas", 5);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(5));
            }
        }

        /// <summary>
        /// Testing a boundary case for SetVariable() to see if it's able to override the variable value.
        /// </summary>
        [Test]
        public void TestSetVariableOverWrite()
        {
            string expression = "A1";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable("A1", 5);
            expressionTree.SetVariable("A1", 3);
            double? testValue = expressionTree.Evaluate();

            if (testValue != null)
            {
                Assert.That(Math.Round((double)testValue, 4), Is.EqualTo(3));
            }
        }

        /// <summary>
        /// Testing a edge case for SetVariable() to see if it's able to handle empty string variables.
        /// </summary>
        [Test]
        public void TestSetVariableEmptyVariable()
        {
            string expression = string.Empty;
            ExpressionTree expressionTree = new ExpressionTree(expression);
            expressionTree.SetVariable(string.Empty, 6);
            double? testValue = expressionTree.Evaluate();

            Assert.That(testValue, Is.Null);
        }

        /// <summary>
        /// Testing a normal case for ToPostfix() method to see if it's able to handle multiple operand with different precedence.
        /// </summary>
        [Test]
        public void TestConvertToPostfixMultipleOperator()
        {
            string expression = "2+A1*1-7/7";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            string postfix = expressionTree.ConvertToPostfix(expression);

            Assert.That(postfix, Is.EqualTo("2 A1 1 * + 7 7 / - "));
        }

        /// <summary>
        /// Testing a normal case for ToPostfix() method to see if it's able to handle parenthacis.
        /// </summary>
        [Test]
        public void TestConvertToPostfixParenthacis()
        {
            string expression = "2+5*(9-3)/3";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            string postfix = expressionTree.ConvertToPostfix(expression);

            Assert.That(postfix, Is.EqualTo("2 5 9 3 - * 3 / + "));
        }

        /// <summary>
        /// Testing a boundary case for ToPostfix() method to see if it's able to deal with nested parenthacis.
        /// </summary>
        [Test]
        public void TestConvertToPostfixNestedParenthacis()
        {
            string expression = "2*(A1+(3*6))";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            string postfix = expressionTree.ConvertToPostfix(expression);

            Assert.That(postfix, Is.EqualTo("2 A1 3 6 * + * "));
        }

        /// <summary>
        /// Testing edge case for ToPostfix() method to see if it's able to deal with invalid parenthacis.
        /// </summary>
        [Test]
        public void TestConvertToPostfixMultipleParenthacis()
        {
            string expression = "()((((1+5)";
            ExpressionTree expressionTree = new ExpressionTree(expression);
            string postfix = expressionTree.ConvertToPostfix(expression);

            Assert.That(postfix, Is.EqualTo(string.Empty));
        }
    }
}
