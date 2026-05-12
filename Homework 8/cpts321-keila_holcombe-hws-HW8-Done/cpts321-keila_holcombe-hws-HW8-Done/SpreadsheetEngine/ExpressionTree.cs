// <copyright file="ExpressionTree.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with the expression tree by creating, storing, and evaluating the expression that the user declared.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Stores the root of the expression trees.
        /// </summary>
        private Node? root;

        /// <summary>
        /// Stores each variable names and the value into a dictionary.
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Stores each name of the cell that is referencing.
        /// </summary>
        private List<string> referencedCells = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Initializes the root by building the tree from the new expression.
        /// </summary>
        /// <param name="expression"> a string of math expression.</param>
        public ExpressionTree(string expression)
        {
            Node? current = this.BuildExpressionTree(expression);
            this.root = current;
        }

        /// <summary>
        /// Gets the list of cell references that are used by this cell.
        /// </summary>
        /// <returns> The current string list of the referenced cell of variable.</returns>
        public List<string> GetVariableNames()
        {
            List<string> list = new List<string>(this.referencedCells);
            return list;
        }

        /// <summary>
        /// Checks if tree is valid and evaluates the tree by calling the evaluate method.
        /// </summary>
        /// <returns> Value of the evaluated expression.</returns>
        public double? Evaluate()
        {
            if (this.root == null)
            {
                return null;
            }

            return this.root.Evaluate();
        }

        /// <summary>
        /// Gets the current vairiable to allow access.
        /// </summary>
        /// <returns> THe current dictionary variable.</returns>
        public Dictionary<string, double> GetVariable()
        {
            return this.variables;
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName"> Name of the variable location.</param>
        /// <param name="variableValue"> Value of the variable.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
        }

        /// <summary>
        /// Builds the expression tree from the expression that is inputted.
        /// Referenced the below link to learn how to create expression tree:
        /// https://www.geeksforgeeks.org/dsa/expression-tree/.
        /// </summary>
        /// <param name="expression"> The string of expression that the tree is based on.</param>
        /// <returns> Root of the expression tree.</returns>
        public Node? BuildExpressionTree(string expression)
        {
            // Converting the expression to a postfix expression
            string postfix = this.ConvertToPostfix(expression);

            // Check if the expression is empty or not
            if (string.IsNullOrEmpty(postfix))
            {
                return null;
            }

            // Clear all old variables from the dictionary.
            this.ClearDictionary();

            // Clear all old references
            this.referencedCells.Clear();

            // Get the operation that is used in the expression
            char operation = this.GetOperator(expression);

            // Store the node to the root first and then return the root
            OperatorNodeFactory nodeFactory = new OperatorNodeFactory();

            // If there is no operator, return the current expression as a node
            if (operation == '\0')
            {
                this.root = this.CreateNode(postfix.Replace(" ", string.Empty));
                return this.root;
            }

            Stack<Node> st = new Stack<Node>();

            // Split the postfix by the spaces and delete any empty entries because it can create them and cause errors
            string[] splittedPostfix = postfix.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidPostfix(splittedPostfix))
            {
                return null;
            }

            // Foreach token in splittedPostfix, check if they are operator or value/variable and create a tree
            foreach (string token in splittedPostfix)
            {
                // Check if current token is a operator
                if (token.Length == 1 && this.IsOperator(token[0].ToString()))
                {
                    // Make that operator into a node
                    OperatorNode temp = nodeFactory.CreateOperatorNode(token[0]);

                    // Get the right and left node of this operator from the stack
                    Node right = st.Pop();
                    Node left = st.Pop();

                    // Store these right and left nodes to temp's right and left child.
                    temp.Left = left;
                    temp.Right = right;

                    // Add the operator node to the stack
                    st.Push(temp);
                }
                else
                {
                    // If the current token is value/variable, convert it to a node and add it to the stack
                    Node temp = this.CreateNode(token);
                    st.Push(temp);
                }
            }

            // Return the tree
            this.root = st.Pop();
            return this.root;
        }

        /// <summary>
        /// Determines if the current postfix is valid or not.
        /// </summary>
        /// <param name="postfix"> list of strings that stores each token of postfix.</param>
        /// <returns> true or false of if it's valid or not.</returns>
        public bool IsValidPostfix(string[] postfix)
        {
            int operatorNum = 0;
            int operandNum = 0;
            foreach (string token in postfix)
            {
                if (this.IsOperator(token))
                {
                    operatorNum++;
                }
                else if (this.IsOperand(token))
                {
                    operandNum++;
                }
                else
                {
                    return false;
                }
            }

            if (operatorNum == operandNum - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the current expression has valid parenthasis. Meaning for every (, there is a ). Or if there is )(.
        /// </summary>
        /// <param name="expression"> Current expression that it's checking.</param>
        /// <returns> The bool condition that tells if the current expression is valid or not.</returns>
        public bool IsValidExpression(string expression)
        {
            int num = 0;

            // loop for all the letters in the expression
            for (int i = 0; i < expression.Length; i++)
            {
                // Check if the current letter is a (, if yes, increase num by one
                if (expression[i] == '(')
                {
                    num++;
                }

                // Check if the current letter is a ), if yes, decrease num by one
                else if (expression[i] == ')')
                {
                    num--;
                }

                // If the current number ever goes below 0, that means ) came before ( so return false
                if (num < 0)
                {
                    return false;
                }
            }

            // At the end, if the num is 0, that mean there was a start and end parenthasis for all
            if (num == 0)
            {
                return true;
            }

            // Meaning it was not valid so return false
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Clears the dictionary when new expression is created.
        /// I have referenced the following website to learn how to clear a dictionary:
        /// https://stackoverflow.com/questions/1978821/how-to-reset-a-dictionary.
        /// </summary>
        public void ClearDictionary()
        {
            this.variables.Clear();
        }

        /// <summary>
        /// Searches what operator the current string expression is using and returns that operator.
        /// </summary>
        /// <param name="expression"> string of expression.</param>
        /// <returns> the operator that is used in the expression.</returns>
        public char GetOperator(string expression)
        {
            // Parse through the string letter by letter to find which operation is happening
            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                // Check if the current char is an operation
                if (current == '+' || current == '-' || current == '*' || current == '/' || current == '^')
                {
                    return current;
                }
            }

            // If there was no operation, return null
            return '\0';
        }

        /// <summary>
        /// Converts the infix to a postfix string.
        /// Referenced the below link to learn how to convert the infix string to postfix:
        /// https://www.rameshfadatare.com/c-programming/c-program-to-convert-infix-to-postfix-expression/.
        /// </summary>
        /// <param name="infix"> string of expression in infix form.</param>
        /// <returns> expression in postfix form.</returns>
        public string ConvertToPostfix(string infix)
        {
            // Check if the current infix expresion is valid or not
            if (!this.IsValidExpression(infix))
            {
                return string.Empty;
            }

            Stack<string> operators = new Stack<string>();
            string postfix = string.Empty;

            // Parse through the token and make a postfix string
            for (int i = 0; i < infix.Length; i++)
            {
                if (infix[i] == ' ')
                {
                    continue;
                }

                // Check if the current letter is a (
                if (infix[i] == '(')
                {
                    operators.Push(infix[i].ToString());
                }

                // Check if the current letter is )
                else if (infix[i] == ')')
                {
                    // pop the letters from the operators until reaching the ( for this bracket and add it to postfix
                    while (operators.Peek() != "(")
                    {
                        postfix += operators.Pop() + " ";
                    }

                    // Pop the ( out from the operators and discard it
                    operators.Pop();
                }

                // Check if the current character is a operator
                else if (this.IsOperator(infix[i].ToString()))
                {
                    while (operators.Count > 0 && this.Precedence(operators.Peek()[0]) >= this.Precedence(infix[i]))
                    {
                        postfix += operators.Pop() + " ";
                    }

                    operators.Push(infix[i].ToString());
                }

                // This means that the current letter is a operand
                else if (this.IsOperand(infix[i].ToString()))
                {
                    string operand = string.Empty;

                    // If operand, get the whole operand from start to end
                    while (i < infix.Length && char.IsLetterOrDigit(infix[i]))
                    {
                        operand += infix[i].ToString();
                        i++;
                    }

                    // Add that operand to the postfix
                    postfix += operand + " ";
                    i--;
                }
                else
                {
                    // Unhandled operation
                    return string.Empty;
                }
            }

            // Get all the rest of the characters from operators and add it to postfix
            while (operators.Count > 0)
            {
                postfix += operators.Pop() + " ";
            }

            // Check if there are any invalid parenthasis, if there is, return empty string to indicate that it is invalid
            if (postfix.Contains('(') || postfix.Contains(')'))
            {
                return string.Empty;
            }

            return postfix;
        }

        /// <summary>
        /// Checks which operator op is and return the level of precedence.
        /// This was from Venera's example code.
        /// </summary>
        /// <param name="op"> The current operator that we are checking.</param>
        /// <returns> The level of precedence.</returns>
        public int Precedence(char op)
        {
            // Check which level precedence the current operand is
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Checks if the current char is a operator or not.
        /// </summary>
        /// <param name="current"> current character of the operator.</param>
        /// <returns> bool of if the current char is a operator.</returns>
        public bool IsOperator(string current)
        {
            char[] currentChars = current.ToCharArray();
            foreach (char c in currentChars)
            {
                // Check if the current character is one of the operator
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    // return true if the current char is a operator
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// It will check if the current string is a operand and returns the bool.
        /// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.
        /// </summary>
        /// <param name="current"> The current string we are checking for.</param>
        /// <returns> True or false about if the current string is an operand.</returns>
        public bool IsOperand(string current)
        {
            char[] currentChars = current.ToCharArray();

            if (double.TryParse(current, out double doubleValue))
            {
                return true;
            }

            bool check = true;
            foreach (char c in currentChars)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    check = false;
                }
            }

            return check;
        }

        /// <summary>
        /// Checks if the char current is a parentheses.
        /// </summary>
        /// <param name="current"> The current character that it's checking.</param>
        /// <returns> true or false of if current is parentheses.</returns>
        public bool IsParentheses(char current)
        {
            // Check if current char is a parenthasis
            if (current == '(' || current == ')')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the string inputted to a variable node or a constantnode.
        /// Referenced the following to check how to see if a string is a number or not.
        /// https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number.
        /// </summary>
        /// <param name="expression"> Expression of the part where it will be converted to node.</param>
        /// <returns> The converted node.</returns>
        public Node CreateNode(string expression)
        {
            // If we are able to make the expression as double, it's a number so convert it to constantNode, otherwise, variableNOde
            if (double.TryParse(expression, out double doubleValue))
            {
                return new ConstantNode(doubleValue);
            }
            else
            {
                // Check if it starts with a letter valid variable name
                if (char.IsLetter(expression[0]))
                {
                    this.referencedCells.Add(expression);
                }

                return new VariableNode(expression, this);
            }
        }
    }
}