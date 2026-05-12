// <copyright file="Tests.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
#pragma warning disable CA1416
using System.Text;
using HW3;
using NUnit.Framework.Internal;

namespace HW3Test
{
    /// <summary>
    /// Contains the tests of normal, boundary, and error case to test if the methods works as intended.
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Testing ReadLine() method by inputting a positive number to test if it does correctly return the fibonacci value
        /// for when testing for a positive value.
        /// </summary>
        [Test]
        public void TestReadLinePositive()
        {
            StringBuilder stringBuilder = new StringBuilder();
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(1);
            string test = fibonacciTextReader.ReadLine();

            // Check how to check the test
            Assert.That(test, Is.EqualTo("0"));
        }

        /// <summary>
        /// Testing ReadLine() method by inputting a number zero to test if method would return null.
        /// </summary>
        [Test]
        public void TestReadLineZero()
        {
            StringBuilder stringBuilder = new StringBuilder();
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(0);
            string test = fibonacciTextReader.ReadLine();

            // Check how to check the test
            Assert.That(test, Is.EqualTo("\0"));
        }

        /// <summary>
        /// Testing ReadLine() method by inputting a negative number to test if method would return null.
        /// </summary>
        [Test]
        public void TestReadLineNegative()
        {
            StringBuilder stringBuilder = new StringBuilder();
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(-1);
            string test = fibonacciTextReader.ReadLine();

            // Check how to check the test
            Assert.That(test, Is.EqualTo("\0"));
        }

        /// <summary>
        /// Testing ReadToEnd() method by inputting a positive number to test if the vales for the line 1 to
        /// print 0, line 2 to print 1, and if the following lines do the correct calculation to find the
        /// fibonacci numbers.
        /// </summary>
        [Test]
        public void TestReadToEnd_Positive()
        {
            StringBuilder stringBuilder = new StringBuilder();
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(5);
            string test = fibonacciTextReader.ReadToEnd();

            // Check how to check the test
            Assert.That(test, Is.EqualTo("1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n"));
        }

        /// <summary>
        /// Testing ReadToEnd() method by inputting a number zero to test if method would return null.
        /// </summary>
        [Test]
        public void TestReadToEnd_Zero()
        {
            StringBuilder stringBuilder = new StringBuilder();
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(0);
            string test = fibonacciTextReader.ReadToEnd();

            // Check how to check the test
            Assert.That(test, Is.EqualTo("\0"));
        }

        /// <summary>
        /// Testing ReadToEnd() method by inputting a negative number to test if method would return null.
        /// </summary>
        [Test]
        public void TestReadToEnd_Negative()
        {
            StringBuilder stringBuilder = new StringBuilder();
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(-3);
            string test = fibonacciTextReader.ReadToEnd();

            // Check how to check the test
            Assert.That(test, Is.EqualTo("\0"));
        }
    }
}
