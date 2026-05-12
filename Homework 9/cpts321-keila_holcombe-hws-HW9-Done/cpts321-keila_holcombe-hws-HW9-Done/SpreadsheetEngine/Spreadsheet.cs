// <copyright file="Spreadsheet.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using System.ComponentModel;
using System.Xml;

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
        /// Stores each cell name and what they are referencing.
        /// </summary>
        private Dictionary<string, HashSet<string>> reference = new Dictionary<string, HashSet<string>>();

        /// <summary>
        /// Manages undo and redo operations.
        /// </summary>
        private UndoRedoManager undoRedoManager = new UndoRedoManager();

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
            this.undoRedoManager.UndoAdded = false;

            // For each cell in the spreadsheet, initialize them
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

            int index = 0;

            // Count how many letters are in the cell name
            while (index < cellName.Length && char.IsLetter(cellName[index]))
            {
                index++;
            }

            // Parsing the string seprate the column and row
            string columnPart = cellName.Substring(0, index);
            string rowPart = cellName.Substring(index);

            // Try to convert the string row to int row
            if (!int.TryParse(rowPart, out int rowIndex))
            {
                return null;
            }

            // Since the spreadsheet starts by 1 but array starts from 0, decrease the row index by 1
            rowIndex -= 1;

            int columnIndex = 0;

            // Since we have a string of column, change it to ASCII number for each letter and subtract it by 'A' to get the columnIndex
            for (int i = 0; i < columnPart.Length; i++)
            {
                columnIndex *= 26;
                columnIndex += columnPart[i] - 'A' + 1;
            }

            // Same reason as rowIndex, decrease by 1 to set it the first to be 0.
            columnIndex -= 1;

            // Return the cell at the position by calling the other GetCell method
            return this.GetCell(rowIndex, columnIndex);
        }

        /// <summary>
        /// Get the current cell name that is under row and column.
        /// </summary>
        /// <param name="row"> The current cell's row number.</param>
        /// <param name="column"> The current cell's column number.</param>
        /// <returns> Name of the cell at position row, column.</returns>
        public string GetCellName(int row, int column)
        {
            // The place that will store the current cell's name.
            string currentCellName = string.Empty;

            // Since the column is from 0 in the array but is from 1 (A) in the spreadsheet, increase it by 1.
            column++;

            // while column is greater than 0, calculate the character of the current column.
            while (column > 0)
            {
                // Get the current column's letter one by one
                currentCellName = (char)('A' + ((column - 1) % 26)) + currentCellName;

                // Go to the next letter in case there are more than one letter
                column = column / 26;
            }

            // Add the row at the end of the name. Add 1 since 0 is actually 1 in spreadsheet
            currentCellName += row + 1;

            // Return the name of the cell
            return currentCellName;
        }

        /// <summary>
        /// This will change the color of each selected cells.
        /// </summary>
        /// <param name="currentCells"> This represents the selected cells.</param>
        /// <param name="currentColor"> This represents the new color it's being changed to.</param>
        public void ChangeColor(List<Cell> currentCells, uint currentColor)
        {
            List<uint> previousColor = new List<uint>();

            // For each of the cell, add their previous color to the list
            foreach (Cell cell in currentCells)
            {
                cell.BGColor = currentColor;
                previousColor.Add(cell.PreviousBGColor);
            }

            // If this is not an undo action, add the current changes to undo stack.
            if (!this.undoRedoManager.UndoAdded)
            {
                ColorCommand newColor = new (currentCells, previousColor, currentColor);
                this.AddUndo(newColor);
            }
        }

        /// <summary>
        /// It will look at the undostack and return the correct text for the redo button.
        /// </summary>
        /// <returns> The text that should go on the redo button. </returns>
        public string GetRedoText()
        {
            return this.undoRedoManager.GetRedoText();
        }

        /// <summary>
        /// It will look at the undostack and return the correct text for the redo button.
        /// </summary>
        /// <returns> The text that should go on the redo button. </returns>
        public string GetUndoText()
        {
            return this.undoRedoManager.GetUndoText();
        }

        /// <summary>
        /// Allows to add the current changes to the undo stack.
        /// </summary>
        /// <param name="data"> The changes that just happened.</param>
        public void AddUndo(IUndoRedoCommand data)
        {
            this.undoRedoManager.AddUndo(data);
        }

        /// <summary>
        /// Allows us to add the undo changes to the redo changes.
        /// </summary>
        /// <param name="data"> The changes from undo.</param>
        public void AddRedo(IUndoRedoCommand data)
        {
            this.undoRedoManager.AddRedo(data);
        }

        /// <summary>
        /// Execute the redo action and update each cell to the changes in the redo stack.
        /// </summary>
        public void ExecuteRedo()
        {
            this.undoRedoManager.ExecuteRedo();
        }

        /// <summary>
        /// Execute the undo action and update each cell to the changes in the undo stack.
        /// </summary>
        public void ExecuteUndo()
        {
            this.undoRedoManager.ExecuteUndo();
        }

        /// <summary>
        /// Clear the text and BGColor of all cells in the spreadsheet.
        /// </summary>
        public void ClearCells()
        {
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    Cell? currentCell = this.GetCell(row, col);
                    currentCell?.Text = string.Empty;
                    currentCell?.BGColor = 0xFFFFFFFF;
                }
            }
        }

        /// <summary>
        /// It will accept the file stream and open the xml file.
        /// Referenced the following to learn about how to load xml files:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlreader?view=net-10.0&redirectedfrom=MSDN.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlreader.getattribute?view=net-10.0.
        /// </summary>
        /// <param name="stream"> The file stream of the xml file.</param>
        public void LoadFile(Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            stream.Position = 0;
            this.ClearCells();

            using (XmlReader? reader = XmlReader.Create(stream, settings))
            {
                while (reader?.Read() == true)
                {
                    if (reader.Name == "cell")
                    {
                        string? cellName = string.Empty;
                        cellName = reader?.GetAttribute("name");
                        if (cellName != null)
                        {
                            Cell? currentCell = this.GetCell(cellName);

                            if (Convert.ToUInt32(reader?.GetAttribute("bgcolor")) != 0)
                            {
                                currentCell?.BGColor = Convert.ToUInt32(reader?.GetAttribute("bgcolor"));
                            }

                            string? text = string.Empty;
                            if (reader?.GetAttribute("text") != null)
                            {
                                text = reader?.GetAttribute("text");
                            }

                            currentCell?.Text = text ?? string.Empty;
                        }
                    }
                }
            }

            // Clear everything from both stack
            this.undoRedoManager.ClearStacks();
        }

        /// <summary>
        /// It will accept the stream that it will be saved to and store saved information to that stream
        /// Referenced the following to learn about how to save as a xml file:
        /// https://stackoverflow.com/questions/16435735/xmlwriter-writestartelement-with-a-tag-name-and-string-to-indicate-tag-name
        /// https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlwriter.writeattributestring?view=net-10.0.
        /// </summary>
        /// <param name="stream">The file that is going to stored.</param>
        public void SaveFile(Stream stream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("spreadsheet");

                // For each of the cell in spreadsheet, check if it has been modified.
                for (int row = 0; row < this.RowCount; row++)
                {
                    for (int col = 0; col < this.ColumnCount; col++)
                    {
                        Cell? cell = this.GetCell(row, col);

                        // If both information is modified
                        if (!string.IsNullOrEmpty(cell?.Text) && cell.BGColor != 0xFFFFFFFF)
                        {
                            writer.WriteStartElement("cell");
                            writer.WriteAttributeString("name", this.GetCellName(row, col));
                            writer.WriteAttributeString("bgcolor", cell.BGColor.ToString());
                            writer.WriteAttributeString("text", cell.Text);
                            writer.WriteEndElement();
                        }

                        // If only the string is modified
                        else if (!string.IsNullOrEmpty(cell?.Text))
                        {
                            writer.WriteStartElement("cell");
                            writer.WriteAttributeString("name", this.GetCellName(row, col));
                            writer.WriteAttributeString("text", cell.Text);
                            writer.WriteEndElement();
                        }

                        // If only the BGColor is modified
                        else if (cell?.BGColor != 0xFFFFFFFF)
                        {
                            writer.WriteStartElement("cell");
                            writer.WriteAttributeString("name", this.GetCellName(row, col));
                            writer.WriteAttributeString("bgcolor", cell?.BGColor.ToString());
                            writer.WriteEndElement();
                        }
                    }
                }

                // End the spreadsheet element
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// This will update the reference dictionary by adding the current cell into each cell that is referencing. If there is no instance for the referenceCell,
        /// it will create one and add itself to it.
        /// </summary>
        /// <param name="referenceCell"> The name of the cell that is being referenced by currentcell.</param>
        /// <param name="currentCell"> The name of the current cell.</param>
        private void UpdateReference(string referenceCell, string currentCell)
        {
            // Check if the current reference exist in the dictionary or not
            if (this.reference.ContainsKey(referenceCell))
            {
                // add the currentCell into the hashset of the referenceCell
                this.reference[referenceCell].Add(currentCell);
            }
            else
            {
                // If it doesn't exist, Create one and add the currentCell into it
                this.reference[referenceCell] = new HashSet<string> { currentCell };
            }
        }

        /// <summary>
        /// Determine if the current new expression causes a circular reference..
        /// </summary>
        /// <param name="referenceCellName"> The current referencing cell name.</param>
        /// <param name="currentCellName"> The current cell name that we need to check.</param>
        /// <param name="visitedCell"> Stores the cell names of the cell that we visited.</param>
        /// <returns> true/false of either it was a circular reference or not.</returns>
        private bool CheckCircularReference(string referenceCellName, string currentCellName, HashSet<string> visitedCell)
        {
            // If the referenceCell and currentCell names are the same, return true
            if (referenceCellName == currentCellName)
            {
                return true;
            }

            // If we already visited this cell, return false so it won't loop forever
            else if (visitedCell.Contains(referenceCellName))
            {
                return false;
            }

            // Since we checked this reference Cell, add it to the visitedCell set
            else
            {
                visitedCell.Add(referenceCellName);
            }

            // Make sure this referenceCellName exist in the reference dictionary
            if (this.reference.ContainsKey(referenceCellName))
            {
                // For each cell inside the reference, repeat the process
                foreach (string checkCell in this.reference[referenceCellName])
                {
                    // Do the checkcircularreference method for this current cell.
                    if (this.CheckCircularReference(checkCell, currentCellName, visitedCell))
                    {
                        return true;
                    }
                }
            }

            // Otherwise, return false
            return false;
        }

        /// <summary>
        /// Clear all the references that this current cell is doing inside the dictionary.
        /// </summary>
        /// <param name="currentCell"> The name of the current cell.</param>
        private void ClearReference(string currentCell)
        {
            // Make sure there is something in the reference, if there is nothing, return and exit
            if (this.reference.Count == 0)
            {
                return;
            }

            // Get each of the cell name key and remove the currentCell from each of the HashSet designated to the cellName
            foreach (var cellName in this.reference.Keys)
            {
                this.reference[cellName].Remove(currentCell);
            }
        }

        /// <summary>
        /// Updates the value of the cell that is referencing the currentCell.
        /// </summary>
        /// <param name="currentCell"> The cell name that is being referenced.</param>
        private void UpdateReferenceCellValue(string currentCell)
        {
            // Check if there is a reference created for this currentCell
            if (this.reference.ContainsKey(currentCell))
            {
                // Get each of the cell name of the cell that is referencing the current cell
                foreach (string referenceName in this.reference[currentCell].ToList())
                {
                    Cell? temp = this.GetCell(referenceName);
                    if (temp != null)
                    {
                        // Get the cell of referenceName and convert it to spreadsheetCell so later we can set the value
                        SpreadsheetCell? referenceCell = this.GetCell(referenceName) as SpreadsheetCell;

                        // Make sure if this cell's text starts with an =
                        if (referenceCell != null && referenceCell.Text.Substring(0, 1).Equals("="))
                        {
                            // Evaluate the expression and set the new value back to its cell
                            string? newValue = string.Empty;

                            try
                            {
                                newValue = this.EvaluateCell(referenceCell);
                            }
                            catch (CircularReferenceException)
                            {
                                newValue = "#Circular Reference!";
                            }
                            catch (InvalidCellReferenceException)
                            {
                                newValue = "#REF!";
                            }
                            catch (InvalidTypeException)
                            {
                                newValue = "#VALUE!";
                            }
                            catch (InvalidExpressionException)
                            {
                                newValue = "#NAME?";
                            }

                            if (newValue != null)
                            {
                                // Update the cell value of each cell that is referencing the current cell;
                                referenceCell.SetValue(newValue);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Evaluate the current cell by using expressionTree class to help evaluate the expression. Checks if it's actually an expression by checking
        /// for = and replace the value with error case when it's doing some invalid things.
        /// </summary>
        /// <param name="cell"> The current cell that is going to be evaluated.</param>
        /// <returns> String of the evaluated value.</returns>
        private string? EvaluateCell(Cell cell)
        {
            // Get the current cell's name
            string currentCellName = this.GetCellName(cell.RowIndex, cell.ColumnIndex);

            // Clear all the references that the current cell is having from the dictionary
            this.ClearReference(currentCellName);

            // Check if this cell's text starts with '='. Otherwise, the value must be computed based on the formula that comes after the '='
            if (string.IsNullOrEmpty(cell.Text))
            {
                return string.Empty;
            }

            // CHecks if there is an equal sign, if not return that current cell as how it is
            if (!cell.Text.Substring(0, 1).Equals("="))
            {
                return cell.Text;
            }

            // Check if the expression, if there is nothing after =, that means it only has = and return that
            string expression = cell.Text.Substring(1);
            if (string.IsNullOrEmpty(expression))
            {
                return "=";
            }

            // From the expression, build a tree
            ExpressionTree expressionTree = new ExpressionTree(expression);

            // Get the list of Cell that this tree is referencing
            List<string> referenceList = expressionTree.GetVariableNames();

            // For each cell that this tree is referencing, get the value and set that variable
            for (int i = 0; i < referenceList.Count; i++)
            {
                // Get the current cell that is referencing
                Cell? currentCell = this.GetCell(referenceList[i]);

                string currentValue = string.Empty;

                // Get the current cell's value
                if (currentCell != null)
                {
                    currentValue = currentCell.Value;
                }

                // Check if the referencing cell is a invalid reference or not
                if (currentCell == null)
                {
                    // This will mean that cell doesn't exist in the spreadsheet, invalid reference
                    // return "#REF!";
                    throw new InvalidCellReferenceException("Exception: Invalid Reference");
                }

                this.UpdateReference(referenceList[i], currentCellName);

                if (this.CheckCircularReference(currentCellName, referenceList[i], new HashSet<string>()))
                {
                    // This means there was a circular references.
                    // return "#Circular Reference!";
                    throw new CircularReferenceException("Exception: Circular Reference");
                }

                // Check if the string currentValue is able to convert to a numerical value
                if (!double.TryParse(currentValue, out double doubleValue))
                {
                    // This will mean wrong data type
                    // return "#VALUE!";
                    throw new InvalidTypeException("Exception: Invalid Type");
                }

                // Set that reference name and value as variable
                expressionTree.SetVariable(referenceList[i], doubleValue);
            }

            // Evaluate the tree
            double? newValue = expressionTree.Evaluate();

            // Check if it was an invalid formula
            if (newValue == null)
            {
                // This will mean the entered formula was invalid
                // return "#NAME?";
                throw new InvalidExpressionException("Exception: Invalid Expression");
            }

            // Return the evaluated value
            string? newStringValue = newValue.ToString();

            return newStringValue;
        }

        /// <summary>
        /// Spreadsheet event handler that will handle the text and value setters.
        /// For this section, I have got some guidence from Professor Venera and my good friend Philip.
        /// </summary>
        /// <param name="sender"> The cell that has changed.</param>
        /// <param name="e">The changing property.</param>
        private void Spreadsheet_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Get the cell from the sender
            Cell cell = (Cell)sender!;
            string cellName = this.GetCellName(cell.RowIndex, cell.ColumnIndex);

            // Check if the property name is text or value, if not return
            if (e.PropertyName == "Text")
            {
                string? newValue = string.Empty;

                // Try doing the evaluation and if there was exception, change the newValue as exception text
                try
                {
                    newValue = this.EvaluateCell(cell);
                }
                catch (CircularReferenceException)
                {
                    newValue = "#Circular Reference!";
                }
                catch (InvalidCellReferenceException)
                {
                    newValue = "#REF!";
                }
                catch (InvalidTypeException)
                {
                    newValue = "#VALUE!";
                }
                catch (InvalidExpressionException)
                {
                    newValue = "#NAME?";
                }

                // Check if this is a undo action
                if (!this.undoRedoManager.UndoAdded)
                {
                    // Add the current change to the undo stack
                    TextCommand newText = new (cell, cell.Text);
                    this.AddUndo(newText);
                }

                if (!string.IsNullOrEmpty(newValue))
                {
                    ((SpreadsheetCell)cell).SetValue(newValue);
                }
                else
                {
                    ((SpreadsheetCell)cell).SetValue(string.Empty);
                }
            }
            else if (e.PropertyName == "Value")
            {
                if (cell.Value != "#Circular Reference!")
                {
                    // Re-calculate the cells that was referencing the current cell
                    this.UpdateReferenceCellValue(this.GetCellName(cell.RowIndex, cell.ColumnIndex));
                }
            }
            else if (e.PropertyName == "BGColor")
            {
                // This will notify that the cell property has changed
                this.CellPropertyChanged?.Invoke(cell, e);
                return;
            }
            else
            {
                return;
            }

            // After adding the current changes, make it to false so no other changes will be added by doing redo or undo
            this.undoRedoManager.UndoAdded = false;
            this.CellPropertyChanged?.Invoke(cell, e);
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

                // Notify that the changes has been made to the value
                this.OnPropertyChanged(nameof(this.Value));
            }
        }
    }
}
