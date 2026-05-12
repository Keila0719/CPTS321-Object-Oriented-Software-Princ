// <copyright file="Menu.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using SpreadsheetEngine;

namespace ExpressionTreeMenu
{
    /// <summary>
    /// Creates a menu so that the users create expressions and variables and evaluate them.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Reference to the object of the ExpressionTree.
        /// </summary>
        private ExpressionTree expressionTree;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// Initializes the expression and the expressionTree.
        /// </summary>
        public Menu()
        {
            this.Expression = "A1+B1+C1"; // Setting default expression
            this.expressionTree = new ExpressionTree(this.Expression);
        }

        /// <summary>
        /// Gets or sets stores the string of expression and allows a getter and setter for it.
        /// </summary>
        private string? Expression { get; set; }

        /// <summary>
        /// Gets or sets stores the name of the variable and allow access bu getters and setters.
        /// </summary>
        private string? VariableName { get; set; }

        /// <summary>
        /// Gets or sets stores the value of the variable and allow access by getters and setters.
        /// </summary>
        private double VariableValue { get; set; }

        /// <summary>
        /// Displays the menu to the user and allow them to create expression, variable, and evaluate expressions.
        /// </summary>
        public void ShowMenu()
        {
            int input = 0;
            do
            {
                // Display the menu to the user
                Console.WriteLine("Menu (current expression = \"" + this.Expression + "\")");
                Console.WriteLine("\t1 = Enter a new expression");
                Console.WriteLine("\t2 = Set a variable value");
                Console.WriteLine("\t3 = Evaluate tree");
                Console.WriteLine("\t4 = Quit");

                // Stores user's answer to what they want to do
                string? answer = Console.ReadLine();

                // Check which choice the user decided
                switch (answer)
                {
                    // If the user choose if they want to create expression
                    case "1":
                        // Get the user's expression
                        string? current = this.Expression;
                        Console.WriteLine("Enter new expression: ");
                        string? expression = Console.ReadLine();

                        this.Expression = expression;

                        if (string.IsNullOrEmpty(this.expressionTree.ConvertToPostfix(this.Expression ?? string.Empty)))
                        {
                            // If it returns null, ask them to re-enter
                            Console.WriteLine("Invalid expression, please re-enter\n");
                            this.Expression = current;
                        }
                        else
                        {
                            // If not invalid, create the tree
                            this.expressionTree.BuildExpressionTree(this.Expression ?? string.Empty);
                        }

                        break;

                    // If the user choose if they want to create variable
                    case "2":
                        // Get the variable name
                        Console.WriteLine("Enter variable name: ");
                        string? variableName = Console.ReadLine();
                        if (variableName != null)
                        {
                            this.VariableName = variableName;
                        }

                        // Get the value for that variable
                        Console.WriteLine("Enter variable value: ");
                        string? valueString = Console.ReadLine();
                        if (valueString != null)
                        {
                            // Convert the variable value to a double number
                            this.VariableValue = double.Parse(valueString);
                        }

                        if (this.VariableName != null)
                        {
                            // Store variable name to the dictionary by calling SetVariable method()
                            this.expressionTree.SetVariable(this.VariableName, this.VariableValue);
                        }

                        break;

                    // If the user choose if they want to evaluate the expression
                    case "3":
                        // This will later store the evaluated value
                        double? evaluateTree = 0;

                        // Evaluate the tree
                        evaluateTree = this.expressionTree.Evaluate();

                        // Check if the value of evaluating tree is not null
                        if (evaluateTree == null)
                        {
                            Console.WriteLine("Invalid expression");
                            break;
                        }

                        // Print the result as well as rounding the answer to the 4th decimal place so it won't be too long
                        Console.WriteLine("Evaluated answer: " + Math.Round((double)evaluateTree, 4));
                        break;

                    case "4":
                        // Exit the program
                        input = 4;
                        Console.WriteLine("Done");
                        break;

                    default:
                        // ignore invalid input
                        break;
                }
            }
            while (input != 4);
        }
    }
}
