// <copyright file="TestSpreadsheetEngine.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using SpreadsheetEngine;

namespace TestSpreadsheetEngine
{
    /// <summary>
    /// Allow to test methods inside the expression functions.
    /// </summary>
    public class TestSpreadsheetEngine
    {
        /// <summary>
        /// Testing normal case of the GetCell(int row, int col) method by using position inside the
        /// boundary to see if we are able to access those cells.
        /// </summary>
        [Test]
        public void TestGetCellIndexPositive()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell at position 3, 5
            Cell? testingCell = spreadsheet.GetCell(3, 5);
            Assert.That(testingCell, Is.Not.Null);
        }

        /// <summary>
        /// Testing boundary case of the GetCell(int row, int col) method by using zeros
        /// to see if we are able to return a null for it.
        /// </summary>
        [Test]
        public void TestGetCellIndexZero()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell at position 0, 0
            Cell? testingCell = spreadsheet.GetCell(0, 0);
            Assert.That(testingCell, Is.Not.Null);
        }

        /// <summary>
        /// Testing boundary case of the GetCell(int row, int col) method by using max position
        /// to see if we are able to return a null for it.
        /// </summary>
        [Test]
        public void TestGetCellIndexMax()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell at position 49, 25
            Cell? testingCell = spreadsheet.GetCell(49, 25);
            Assert.That(testingCell, Is.Not.Null);
        }

        /// <summary>
        /// Testing edge case of the GetCell(int row, int col) method by using out of boundary number
        /// to see if we are able to return a null for it.
        /// </summary>
        [Test]
        public void TestGetCellIndexNegative()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell outside of the boundary
            Cell? testingCell = spreadsheet.GetCell(-10, -5);
            Assert.That(testingCell, Is.Null);
        }

        /// <summary>
        /// Testing normal case of the GetCell(string name) method by using in bound name
        /// to see if we were able to access those cells.
        /// </summary>
        [Test]
        public void TestGetCellName()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell with a valid name
            Cell? testingCell = spreadsheet.GetCell("A1");
            Assert.That(testingCell, Is.Not.Null);
        }

        /// <summary>
        /// Testing boundary case of the GetCell(string name) method by using in out bound name
        /// to see if we were able to return a null for that.
        /// </summary>
        [Test]
        public void TestGetCellOutBoundName()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell with an invalid name
            Cell? testingCell = spreadsheet.GetCell("AA90");
            Assert.That(testingCell, Is.Null);
        }

        /// <summary>
        /// Testing edge case of the GetCell(string name) method by using an empty name to see
        /// if it's able to return a null for that.
        /// </summary>
        [Test]
        public void TestGetCellEmptyName()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Get the cell empty name
            Cell? testingCell = spreadsheet.GetCell(string.Empty);
            Assert.That(testingCell, Is.Null);
        }

        /// <summary>
        /// Testing normal case of Setting text by using '=' with in bound cell names to see if it was able
        /// to set their value as the other cell.
        /// </summary>
        [Test]
        public void TestSetTextInBound()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Let's set the cell at 'A1' as a number
            var cellA1 = spreadsheet.GetCell("A1");
            Assert.That(cellA1, Is.Not.Null);
            cellA1!.Text = "4";

            // Next, let's set the cell at 5, 5 as '=A1' to see if it was able to copy the value from position A1
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=A1";

            // Check if the Cell at 5,5 was actually able to store the value from A1
            Assert.That(cell55.Value, Is.EqualTo("4"));
        }

        /// <summary>
        /// Testing boundary case of Setting text by using '=' with out of bound cell names to see if it will able.
        /// to set as a empty case.
        /// </summary>
        [Test]
        public void TestSetValueOutBoundary()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Set the cell at 5,5 to '=Z102', something that is out of the boundary
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=Z102";

            // Check the Cell at 5,5
            Assert.That(cell55.Value, Is.EqualTo("#REF!"));
        }

        /// <summary>
        /// Testing edge case of Setting text by using '=' with no name of the cell and to see if it will able
        /// recognize it as being just a string.
        /// </summary>
        [Test]
        public void TestSetValueEmptyEqual()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // let's set the cell at 5, 5 as '=', to an empty equal sign
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=";

            // Check the Cell at 5,5
            Assert.That(cell55.Value, Is.EqualTo("="));
        }

        /// <summary>
        /// Testing normal case for EvaluateCell where it will do simple numerical expression.
        /// </summary>
        [Test]
        public void TestEvaluateCellNumerical()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // let's set the cell at 5, 5 do simple addition
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=3+1";

            // Check if it evaluated correctly
            Assert.That(cell55.Value, Is.EqualTo("4"));
        }

        /// <summary>
        /// Testing normal case for EvaluateCell where it will evaluate expression with cell reference.
        /// </summary>
        [Test]
        public void TestEvaluateCellVariable()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Set a number at A1
            var cellA1 = spreadsheet.GetCell("A1");
            Assert.That(cellA1, Is.Not.Null);
            cellA1!.Text = "4";

            // Doing an expression with that cell position
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=(A1+4)";

            // Check if it evaluated correctly
            Assert.That(cell55.Value, Is.EqualTo("8"));
        }

        /// <summary>
        /// Testing boundary case for EvaluateCell empty expression.
        /// </summary>
        [Test]
        public void TestEvaluateCellNull()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Next, let's set the cell at 5, 5 as '=A1' to see if it was able to copy the value from position A1
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = string.Empty;

            // Check if it was able to treate null as a empty string.
            Assert.That(cell55.Value, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Testing edge case for EvaluateCell where it will try to access an out of bound cell.
        /// </summary>
        [Test]
        public void TestEvaluateCellOutBound()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Set a number at A1
            var cellA1 = spreadsheet.GetCell("A1");
            Assert.That(cellA1, Is.Not.Null);
            cellA1!.Text = "4";

            // Try to create an expression that reference a cell position out of bound
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=A1*AA203";

            // Check if it was able to return the correct error type
            Assert.That(cell55.Value, Is.EqualTo("#REF!"));
        }

        /// <summary>
        /// Testing edge case for EvaluateCell where it will try to evaluate an expression with string.
        /// </summary>
        [Test]
        public void TestEvaluateCellStringValue()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // A1 will store a string
            var cellA1 = spreadsheet.GetCell("A1");
            Assert.That(cellA1, Is.Not.Null);
            cellA1!.Text = "hello";

            // Create an expression that has a variable with string
            var cell1 = spreadsheet.GetCell(5, 5);
            cell1!.Text = "=(A1+2)";

            // Check if it was able to return the correct error type
            Assert.That(cell1.Value, Is.EqualTo("#VALUE!"));
        }

        /// <summary>
        /// Testing edge case for EvaluateCell with invalid expression.
        /// </summary>
        [Test]
        public void TestEvaluateCellInvalidExpression()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Create an expression with invalid expression
            var cell1 = spreadsheet.GetCell(5, 5);
            cell1!.Text = "=((((1))))";

            // Check if it was able to return the correct error type
            Assert.That(cell1.Value, Is.EqualTo("1"));
        }

        /// <summary>
        /// Testing edge case for EvaluateCell when using unrecognized characters.
        /// </summary>
        [Test]
        public void TestEvaluateUnRecognize()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // let's set the cell at 5, 5 do simple addition
            var cell55 = spreadsheet.GetCell(5, 5);
            Assert.That(cell55, Is.Not.Null);
            cell55!.Text = "=3^1";

            // Check if it evaluated correctly
            Assert.That(cell55.Value, Is.EqualTo("#NAME?"));
        }

        /// <summary>
        /// Testing normal case of checking if a variable that is dependent to another variable will change after the refering variable changes.
        /// </summary>
        [Test]
        public void TestDependentVariables()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Create an expression with invalid expression
            var cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";

            var cell2 = spreadsheet.GetCell(1, 0);
            cell2!.Text = "=A1";
            cell1!.Text = "=5";

            // Check if it was able to return the correct error type
            Assert.That(cell2.Value, Is.EqualTo("5"));
        }

        /// <summary>
        /// Testing normal case of checking if a variable that is dependent to another multiple variable will change after the refering variable changes.
        /// </summary>
        [Test]
        public void TestDependentVariablesMultiple()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Create an expression with invalid expression
            var cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";

            var cell2 = spreadsheet.GetCell(1, 0);
            cell2!.Text = "=A1";

            var cell3 = spreadsheet.GetCell(2, 0);
            cell3!.Text = "=A2";

            var cell4 = spreadsheet.GetCell(3, 0);
            cell4!.Text = "=A3";

            var cell5 = spreadsheet.GetCell(4, 0);
            cell5!.Text = "=A4";

            var cell6 = spreadsheet.GetCell(5, 0);
            cell6!.Text = "=A5";

            var cell7 = spreadsheet.GetCell(6, 0);
            cell7!.Text = "=A6";

            cell1!.Text = "=5";

            // Check if it was able to return the correct error type
            Assert.That(cell7.Value, Is.EqualTo("5"));
        }

        /// <summary>
        /// Testing edge case for checking dependent variables with circular reference.
        /// </summary>
        [Test]
        public void TestDependentVariablesCircularReference()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);

            // Create an expression with invalid expression
            var cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";

            var cell2 = spreadsheet.GetCell(1, 0);
            cell2!.Text = "=A1";
            cell1!.Text = "=A2";

            // Check if it was able to return the correct error type
            Assert.That(cell1.Value, Is.EqualTo("#Circular Reference!"));
        }

        /// <summary>
        /// Testing for normal case of what will happen if a undo for text works.
        /// </summary>
        [Test]
        public void TestEvaluateUndoText()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";
            cell1!.Text = "=23";

            spreadsheet.ExecuteUndo();
            Assert.That(cell1.Text, Is.EqualTo("=4"));
        }

        /// <summary>
        /// Testing for normal case of what will happen if a undo for color works.
        /// </summary>
        [Test]
        public void TestEvaluateUndoColor()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            List<Cell?> cell = new List<Cell?>();

            cell?.Add(cell1);

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            spreadsheet.ChangeColor(cell, 0xFF0000FF);
            spreadsheet.ChangeColor(cell, 0xFF00000F);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning restore CS8604 // Possible null reference argument.

            spreadsheet.ExecuteUndo();
            Assert.That(cell1?.BGColor, Is.EqualTo(0xFF0000FF));
        }

        /// <summary>
        /// Testing for boundary case of what will happen if an undo of mix of text and color works.
        /// </summary>
        [Test]
        public void TestEvaluateUndoMix()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";
            List<Cell> cell = new List<Cell>();

            cell.Add(cell1);
            spreadsheet.ChangeColor(cell, 0xFF0000FF);

            spreadsheet.ExecuteUndo();
            Assert.That(cell1.Text, Is.EqualTo("=4"));
        }

        /// <summary>
        /// Testing for edge case of what will happen when doing an undo on empty stack.
        /// </summary>
        [Test]
        public void TestEvaluateUndoEmpty()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);

            spreadsheet.ExecuteUndo();
            Assert.That(cell1?.Text, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Testing for normal case of what will happen if a redo for text works.
        /// </summary>
        [Test]
        public void TestEvaluateRedoText()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";
            cell1!.Text = "=23";

            spreadsheet.ExecuteUndo();
            spreadsheet.ExecuteUndo();
            spreadsheet.ExecuteRedo();
            Assert.That(cell1.Text, Is.EqualTo("=4"));
        }

        /// <summary>
        /// Testing for normal case of what will happen if a redo for color works.
        /// </summary>
        [Test]
        public void TestEvaluateRedoColor()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            List<Cell?> cell = new List<Cell?>();
            cell?.Add(cell1);

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            spreadsheet.ChangeColor(cell, 0xFF0000FF);
            spreadsheet.ChangeColor(cell, 0xFF00000F);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning restore CS8604 // Possible null reference argument.

            spreadsheet.ExecuteUndo();
            spreadsheet.ExecuteUndo();
            spreadsheet.ExecuteRedo();
            Assert.That(cell1?.BGColor, Is.EqualTo(0xFF0000FF));
        }

        /// <summary>
        /// Testing for boundary case of what will happen if an redi of mix of text and color works.
        /// </summary>
        [Test]
        public void TestEvaluateRedoMix()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            cell1!.Text = "=4";
            cell1!.BGColor = 0xFFFFFFFF;

            spreadsheet.ExecuteUndo();
            spreadsheet.ExecuteUndo();
            spreadsheet.ExecuteRedo();
            Assert.That(cell1.Text, Is.EqualTo("=4"));
        }

        /// <summary>
        /// Testing for edge case of what will happen when doing an redo on empty stack.
        /// </summary>
        [Test]
        public void TestEvaluateRedoEmpty()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);

            spreadsheet.ExecuteRedo();
            Assert.That(cell1?.Text, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Testing normal case for changing color.
        /// </summary>
        [Test]
        public void TestChangeColor()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);
            cell1!.BGColor = 0xFFFFFFFF;

            Assert.That(cell1?.BGColor, Is.EqualTo(0xFFFFFFFF));
        }

        /// <summary>
        /// Testing boundary case for changing color multiple times.
        /// </summary>
        [Test]
        public void TestChangeColorMultipleTimes()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell = spreadsheet.GetCell(0, 0);

            cell!.BGColor = 0xFFFFFFFF;
            cell!.BGColor = 0xFF0000FF;

            Assert.That(cell.BGColor, Is.EqualTo(0xFF0000FF));
        }

        /// <summary>
        /// Testing edge case checking what BGColor would be without changing anything.
        /// </summary>
        [Test]
        public void TestChangeColorNull()
        {
            Spreadsheet spreadsheet = new Spreadsheet(50, 26);
            Cell? cell1 = spreadsheet.GetCell(0, 0);

            Assert.That(cell1?.BGColor, Is.EqualTo(0xFFFFFFFF));
        }

        /// <summary>
        /// Testing normal case for saving and loading by simply saving information and loading to a new spreadsheet.
        /// </summary>
        [Test]
        public void TestSaveLoadspreadsheet()
        {
            Spreadsheet original = new Spreadsheet(50, 26);

            Cell? a1 = original.GetCell(0, 0);
            Cell? b2 = original.GetCell(1, 1);

            a1?.Text = "Hello";
            b2?.Text = "=A1";

            using MemoryStream stream = new MemoryStream();
            original?.SaveFile(stream);

            Spreadsheet? loadedSheet = new Spreadsheet(50, 26);
            loadedSheet?.LoadFile(stream);

            Cell? loadedA1 = loadedSheet?.GetCell(0, 0);

            Assert.That(loadedA1?.Text, Is.EqualTo("Hello"));
        }

        /// <summary>
        /// Testing boundary case for saving and loading to a changed spreadsheet and see if it overwrite.
        /// </summary>
        [Test]
        public void TestSaveLoadChangedspreadsheet()
        {
            Spreadsheet original = new Spreadsheet(50, 26);

            Cell? a1 = original.GetCell(0, 0);
            Cell? b2 = original.GetCell(1, 1);

            a1?.Text = "Hello";
            b2?.Text = "=A1";

            using MemoryStream stream = new MemoryStream();
            original.SaveFile(stream);

            Spreadsheet loadedSheet = new Spreadsheet(50, 26);

            Cell? loadedA1 = loadedSheet.GetCell(0, 0);
            loadedA1?.Text = "Changed?";
            loadedSheet?.LoadFile(stream);

            Assert.That(loadedA1?.Text, Is.EqualTo("Hello"));
        }

        /// <summary>
        /// Testing Edge Case for testing when Saving empty spreadsheet and chack if it loads coreectly.
        /// </summary>
        [Test]
        public void TestSaveLoadNoChangedspreadsheet()
        {
            Spreadsheet original = new Spreadsheet(50, 26);
            using MemoryStream stream = new MemoryStream();
            original.SaveFile(stream);
            Spreadsheet loadedSheet = new Spreadsheet(50, 26);

            Cell? loadedA1 = loadedSheet?.GetCell(0, 0);
            loadedSheet?.LoadFile(stream);

            Assert.That(loadedA1?.Text, Is.EqualTo(string.Empty));
        }
    }
}
