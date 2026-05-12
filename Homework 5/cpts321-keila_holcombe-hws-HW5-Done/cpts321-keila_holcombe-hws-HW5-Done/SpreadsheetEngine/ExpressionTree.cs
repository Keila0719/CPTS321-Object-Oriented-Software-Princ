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
        /// <returns> current dictionary variable.</returns>
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
            // Check if the expression is empty or not
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }

            // Get the operation that is used in the expression
            char operation = this.GetOperator(expression);

            // If there is no operator, return the current expression as a node
            if (operation == '\0')
            {
                // Store the node to the root first and then return the root
                this.root = this.ConvertToNode(expression);
                return this.root;
            }

            Stack<Node> st = new Stack<Node>();
            string postfix = this.ConvertToPostfix(expression);

            // Split the postfix by the spaces and delete any empty entries because it can create them and cause errors
            string[] splittedPostfix = postfix.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Foreach token in splittedPostfix, check if they are operator or value/variable and create a tree
            foreach (string token in splittedPostfix)
            {
                // Check if current token is a operator
                if (token.Length == 1 && this.IsOperator(token[0]))
                {
                    // Make that operator into a node
                    OperatorNode temp = this.CreateOperatorNode(token[0]);

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
                    Node temp = this.ConvertToNode(token);
                    st.Push(temp);
                }
            }

            // Return the tree
            this.root = st.Pop();
            return this.root;
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
            Stack<string> operators = new Stack<string>();
            string postfix = string.Empty;

            // Get the operation that is used in this expression
            char operation = this.GetOperator(infix);

            // Seprate the expression by the operation
            string[] token = infix.Split(operation);

            // Parse through the token and make a postfix string
            for (int i = 0; i < token.Length - 1; i++)
            {
                // If operand, add to postfix
                postfix += token[i] + " ";

                // If operator
                while (operators.Count > 0)
                {
                    postfix += operators.Pop() + " ";
                }

                operators.Push(operation.ToString());
            }

            // Adding the last operand to the postfix
            postfix += token[token.Length - 1] + " ";

            // Pop the operators and add it to postfix
            while (operators.Count > 0)
            {
                postfix += operators.Pop() + " ";
            }

            return postfix.ToString();
        }

        /// <summary>
        /// Checks if the current char is a operator or not.
        /// </summary>
        /// <param name="current"> current character of the operator.</param>
        /// <returns> bool of if the current char is a operator.</returns>
        public bool IsOperator(char current)
        {
            // Check if the current character is one of the operator
            if (current == '+' || current == '-' || current == '*' || current == '/')
            {
                // return true if the current char is a operator
                return true;
            }

            return false;
        }

        /// <summary>
        /// Create a operator node for each type of operator.
        /// </summary>
        /// <param name="operators"> character of operator.</param>
        /// <returns>The node of the new created node for that operator.</returns>
        /// <exception cref="NotSupportedException"> If there are other operator, return a exception.</exception>
        public OperatorNode CreateOperatorNode(char operators)
        {
            // Check which operator it is and create a node for it.
            switch (operators)
            {
                case '+':
                    return new AdditionNode(operators);
                case '-':
                    return new SubtractionNode(operators);
                case '*':
                    return new MultiplicationNode(operators);
                case '/':
                    return new DivisionNode(operators);
                default: // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException(
                        "Operator " + operators.ToString() + " not supported.");
            }
        }

        /// <summary>
        /// Converts the string inputted to a variable node or a constantnode.
        /// Referenced the following to check how to see if a string is a number or not.
        /// https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number.
        /// </summary>
        /// <param name="expression"> Expression of the part where it will be converted to node.</param>
        /// <returns> The converted node.</returns>
        public Node ConvertToNode(string expression)
        {
            if (double.TryParse(expression, out double doubleValue))
            {
                return new ConstantNode(doubleValue);
            }
            else
            {
                return new VariableNode(expression, this);
            }
        }
    }
}