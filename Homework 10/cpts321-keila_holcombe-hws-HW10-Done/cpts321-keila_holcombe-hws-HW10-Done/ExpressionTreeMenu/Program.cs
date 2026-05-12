// <copyright file="Program.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using SpreadsheetEngine;

namespace ExpressionTreeMenu
{
    /// <summary>
    /// Class where it will store the main to start the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Calls the menu and allow the user to interact with the program.
        /// </summary>
        public static void Main()
        {
            // Shows the menu to the user
            Menu menu = new Menu();
            menu.ShowMenu();
        }
    }
}