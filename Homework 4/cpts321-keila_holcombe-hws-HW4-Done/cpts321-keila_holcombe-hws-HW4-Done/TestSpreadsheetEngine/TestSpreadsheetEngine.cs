namespace TestSpreadsheetEngine
{
	using NUnit.Framework;
	using SpreadsheetEngine;
	public class Tests
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
		/// Testing edge case of the GetCell(int row, int col) method by using out of boundary number 
		/// to see if we are able to return a null for it.
		/// </summary>
		[Test]
		public void TestGetCellIndexNegative()
		{
			Spreadsheet spreadsheet = new Spreadsheet(50, 26);
			// Get the cell outside of the boundary
			Cell?	 testingCell = spreadsheet.GetCell(-10, -5);
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
			Cell? testingCell = spreadsheet.GetCell("");
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
			// Let's set the cell at 'A1' as TEst
			var cellA1 = spreadsheet.GetCell("A1");
			Assert.That(cellA1, Is.Not.Null);
			cellA1!.Text = "Test";
			// Next, let's set the cell at 5, 5 as '=A1' to see if it was able to copy the value from position A1
			var cell55 = spreadsheet.GetCell(5, 5);
			Assert.That(cell55, Is.Not.Null);
			cell55!.Text = "=A1";

			// Check if the Cell at 5,5 was actually able to store the value from A1
			Assert.That(cell55.Value, Is.EqualTo("Test"));
		}

		/// <summary>
		/// Testing boundary case of Setting text by using '=' with out of bound cell names to see if it will able 
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
			Assert.That(cell55.Value, Is.EqualTo(string.Empty));
		}

		/// <summary>
		/// Testing edge case of Setting text by using '=' with no name of the cell and to see if it will able
		/// to set as a empty case.
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
			Assert.That(cell55.Value, Is.EqualTo(string.Empty));
		}
	}
}
