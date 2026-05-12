// <copyright file="Spreadsheet.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using System.ComponentModel;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Store the 2D array of cells in the spreadsheet.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Create an 2d array where it will store the SpreadSheetCell for each position.
        /// The website that I referenced:
        /// https://stackoverflow.com/questions/549399/c-sharp-creating-an-array-of-arrays.
        /// </summary>
        private readonly Cell[,] cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// Initializes the spreadsheet with the row count and column. Also initialize each cells.
        /// </summary>
        /// <param name="rows"> Number of total amount of rows the shreadsheet would have.</param>
        /// <param name="columns">Number of total amount of columns the shreadsheet would have.</param>
        public Spreadsheet(int rows, int columns)
        {
            // Initialize the row and column Count
            this.RowCount = rows;
            this.ColumnCount = columns;
            this.cells = new Cell[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    // Initializing the 2D array based on the row size and column size
                    this.cells[row, column] = new SpreadsheetCell(row, column);

                    // Got helped by Venera
                    this.cells[row, column].PropertyChanged += this.Spreadsheet_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Initializing the event of PropertyChangedEventHandler.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = static (sender, e) => { };

        /// <summary>
        /// Gets the number of columns in the spreadsheet.
        /// </summary>
        public int ColumnCount { get; }

        /// <summary>
        /// Gets the number of rows in the spreadsheet.
        /// </summary>
        public int RowCount { get; }

        /// <summary>
        /// Gets the cell at the position at the specified column and row indicies.
        /// </summary>
        /// <param name="rowIndex"> The index of row of the finding cell.</param>
        /// <param name="columnIndex">The index of column of the finding cell.</param>
        /// <returns> returns the cell at the specific column and row indicies.</returns>
        public Cell? GetCell(int rowIndex, int columnIndex)
        {
            // Check if the current cell is within the boundrary.
            if (columnIndex >= 0 && columnIndex < this.ColumnCount)
            {
                if (rowIndex >= 0 && rowIndex < this.RowCount)
                {
                    return this.cells[rowIndex, columnIndex];
                }
            }

            // If they are not in bounds, return null
            return null;
        }

        /// <summary>
        /// Gets the cell's name at the specified column and row indicies.
        /// </summary>
        /// <param name="cellName"> The name of the cell.</param>
        /// <returns> returns the cell by the name.</returns>
        public Cell? GetCell(string cellName)
        {
            // Check if the string is empty or not. If empty, return null.
            if (cellName == string.Empty)
            {
                return null;
            }

            // Initialize the variables that will be used later
            string columnLetter = string.Empty;
            int rowIndex = 0;

            // Check how many letters we need to parse for.
            int letterAmount = (int)Math.Ceiling(this.ColumnCount / 26.0);

            // Parsing the string to get the letter for column and number for row
            columnLetter = cellName.Substring(0, letterAmount);
            string rowLetter = cellName.Substring(letterAmount);
            char firstLetter = (char)rowLetter[0];

            // Check if there is no extra letter in the number portion
            if (char.IsLetter(firstLetter))
            {
                return null;
            }

            // If not make the rowLetter to integer
            rowIndex = int.Parse(rowLetter);

            // After getting the string of it, change it to ASCII number for each letter and subtract it by 'A' to get the rowIndex
            int columnIndex = 0;
            for (int i = 0; i < letterAmount; i++)
            {
                columnIndex += columnLetter[0] - 'A';
            }

            // Check if this cell exist. If not return null
            if (this.GetCell(rowIndex, columnIndex) == null)
            {
                return null;
            }

            // Return the cell at the position by calling the other GetCell method
            return this.GetCell(rowIndex, columnIndex);
        }

        /// <summary>
        /// Spreadsheet event handler that will handle the text and value setters.
        /// For this section, I have got some guidence from Professor Venera.
        /// </summary>
        /// <param name="sender"> The cell that has changed.</param>
        /// <param name="e">The changing property.</param>
        private void Spreadsheet_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Get the cell from the sender
            SpreadsheetCell cell = (SpreadsheetCell)sender!;

            // Store the new text of this cell
            string newText = cell.Text;

            // Check if the newtext is the same as the current one
            if (cell.Value != newText)
            {
                // Check if this cell's text starts with '='. Otherwise, the value must be computed based on the formula that comes after the '='
                if (!string.IsNullOrEmpty(cell.Text))
                {
                    if (cell.Text.Substring(0, 1).Equals("="))
                    {
                        // Get the rest of the text after '='
                        string text = cell.Text.Substring(1);
                        SpreadsheetCell? referenceCell = this.GetCell(text) as SpreadsheetCell;

                        // Check if that referenced cell exist
                        if (referenceCell != null)
                        {
                            // Get the referenced cell value by calling the GetCell method
                            newText = referenceCell.Value;
                        }
                        else
                        {
                            // IF the referenced cell does not exist, make the text as empty
                            newText = string.Empty;
                        }
                    }
                }

                // Store the new text to the cell's value
                cell.SetValue(newText);
            }

            // After changing the value of the cell, call the event
            this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// Manages the cell class by inheriting that class and allowing setting values.
        /// </summary>
        private class SpreadsheetCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
            /// Initialize the SpreadsheetCell by calling the base class.
            /// </summary>
            /// <param name="currentRow">The number of the current row.</param>
            /// <param name="currentColumn">The number of the current column.</param>
            public SpreadsheetCell(int currentRow, int currentColumn)
                : base(currentRow, currentColumn)
            {
            }

            /// <summary>
            /// Sets the current's cell's value as the new value.
            /// </summary>
            /// <param name="newValue"> New string of the value that will be set to the cell's value.</param>
            public void SetValue(string newValue)
            {
                this.value = newValue;
            }
        }
    }
}
