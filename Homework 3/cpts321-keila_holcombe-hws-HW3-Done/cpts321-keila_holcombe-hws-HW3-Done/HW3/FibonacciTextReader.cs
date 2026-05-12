// <copyright file="FibonacciTextReader.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;

namespace HW3
{
    /// <summary>
    /// Contains methods to generate Fibonacci numbers.
    /// </summary>
public class FibonacciTextReader : TextReader
    {
        /// <summary>
        /// Stores the maximum number of Fibonacci numbers to generate.
        /// </summary>
        private int maxLine;

        /// <summary>
        /// Stores the current number of Fibonacci number it generated.
        /// </summary>
        private int currentLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class. Takes an integer as a parameter
        /// indicating the maximum number of lines available.
        /// </summary>
        /// <param name="maxLine"> The maximum number of Fibonacci numbers to generate. </param>
        public FibonacciTextReader(int maxLine)
        {
            this.maxLine = maxLine;
            this.currentLine = 1;
        }

        /// <summary>
        /// Find and calculate the current line's fibonacci number.
        /// </summary>
        /// <returns>
        /// A string that has the current line's fibonacci number. If the maximum line is less then 1
        /// or if it is less then currentline, it will return null.
        /// </returns>
        public override string ReadLine()
        {
            BigInteger previous = 0;
            BigInteger current = 1;
            BigInteger fibonacciNumber = 0;

            // Check if the maxline is less then 1 or if currentline > max line return null
            if (this.maxLine < 1 || this.currentLine > this.maxLine)
            {
                return "\0";
            }

            // Check if the currentLine is 1, if so return 0 since it is at the first line
            else if (this.currentLine == 1)
            {
                fibonacciNumber = 0;
            }

            // Check if the currentLine is 2, if so return 1 since it is the second line
            else if (this.currentLine == 2)
            {
                fibonacciNumber = 1;
            }
            else // if the currentline > 3, loop to calculate the fibonacci number
            {
                // It will loop until it find the appropriate fibonacci number for the current line
                for (int i = 3; i <= this.currentLine; i++)
                {
                    fibonacciNumber = previous + current;
                    previous = current;
                    current = fibonacciNumber;
                }
            }

            // Returning the currentline's fibonacci number
            this.currentLine++;
            return fibonacciNumber.ToString();
        }

        /// <summary>
        /// Find the max line numbers of fibinocci numbers by calling ReadLine() and return.
        /// </summary>
        /// <returns>
        /// A string that has the full lines of fibonacci numbers. If the maximum line is less then 1 it will return null.
        /// </returns>
        public override string ReadToEnd()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Check if the max line is at least 1, if not it will return a null
            if (this.maxLine < 1)
            {
                return "\0";
            }

            // Loop and call ReadLine() while currentline is less then or equal to maxLine
            while (this.currentLine <= this.maxLine)
            {
                // Call the Readline and print the value to the text file
                stringBuilder.Append(this.currentLine + ": " + this.ReadLine() + "\r\n");
            }

            // return the fibonacci strings
            return stringBuilder.ToString();
        }
    }
}
