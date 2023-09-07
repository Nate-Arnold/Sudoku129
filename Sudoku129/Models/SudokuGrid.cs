using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;

namespace Sudoku129.Model
{
    public class SudokuGrid
    {
        //Cannot Bind to multidimension array without a work around, so using a single dimension array instead
        public SudokuCell[] _cells;

        public SudokuGrid()
        {
            //Hard coded to 81 for now
            _cells = new SudokuCell[81];

            for (int ii = 0; ii < 81; ii++)
            {
                _cells[ii] = new SudokuCell();
            }
        }

        public SudokuCell GetCell(int offset)
        {
            return _cells[offset];
        }

        public SudokuCell[] GetCells()
        {
            return _cells;
        }

        public void SetCellValue(string value, int offset)
        {
            _cells[offset].CellValue = value;
        }

        public void SetCellColor(string color, int offset)
        {
            _cells[offset].CellColor = color;
        }

        public void SetIsGiven(bool isGiven, int offset)
        { 
            _cells[offset].IsGiven = isGiven;

            //If cell is given the text color should be black
            if(isGiven)
            {
                _cells[offset].TextColor = "#000000";
            }
        }

        //Validates a single box, given the starting row and col
        //Assumes a 3x3 box
        private bool ValidateBox(int row, int col)
        {
            //Convert to multidimensional array to make it easier
            string[,] grid = new string[9, 9];
            int cellCount = 0;
            for (int ii = 0; ii < 9; ii++)
            {
                for (int jj = 0; jj < 9; jj++)
                {
                    grid[ii, jj] = _cells[cellCount++].CellValue;
                }
            }

            var list = new List<string>();
            int orginCol = col;

            for (int ii = 0; ii < 3; ii++)
            {
                for(int jj = 0; jj < 3; jj++)
                {
                    if (!String.IsNullOrEmpty(grid[row, col]))
                    {
                        list.Add(grid[row, col]);
                    }
                    col++;
                }
                row++;
                col = orginCol;
            }

            if (list.Count != list.Distinct().Count())
            {
                // Duplicates exist
                return false;
            }

            return true;
        }

        //Check all boxes in grid are valid(Standard Sudoku Rules)
        //TODO Absurdly bad code, but it works for now, fix later
        private bool ValidateBoxes()
        {
            if(!ValidateBox(0, 0)) return false;
            if (!ValidateBox(0, 3)) return false;
            if (!ValidateBox(0, 6)) return false;

            if (!ValidateBox(3, 0)) return false;
            if (!ValidateBox(3, 3)) return false;
            if (!ValidateBox(3, 6)) return false;

            if (!ValidateBox(6, 0)) return false;
            if (!ValidateBox(6, 3)) return false;
            if (!ValidateBox(6, 6)) return false;

            return true;
        }

        //Check if this grid is valid(Standard Sudoku Rules)
        public bool IsValid()
        {
            //Need to check each cell is filled with a digit
            for (int ii = 0; ii < 81; ii++) //Hardcoded as 81 for now
            {
                if (String.IsNullOrEmpty(_cells[ii].CellValue))
                {
                    return false;
                }
            }

            //Then just use IsValidUpload() to check each row and column is unique
            return IsValidUpload();
        }

        //Only needs to check that digits in rows and columns are unique
        public bool IsValidUpload()
        {
            //Check each Row has no duplicates
            for (int ii = 0; ii < 81; ii += 9)
            {
                var list = new List<string>();

                for (int jj = 0; jj < 9; jj++)
                {
                    if (!String.IsNullOrEmpty(_cells[ii + jj].CellValue))
                    {
                        list.Add(_cells[ii + jj].CellValue);
                    }
                }

                if (list.Count != list.Distinct().Count())
                {
                    // Duplicates exist
                    return false;
                }
            }

            //Check each Column has no duplicates
            for (int ii = 0; ii < 9; ii++)
            {
                var list = new List<string>();

                for (int jj = 0; jj < 81; jj += 9)
                {
                    if (!String.IsNullOrEmpty(_cells[ii + jj].CellValue))
                    {
                        list.Add(_cells[ii + jj].CellValue);
                    }
                }

                if (list.Count != list.Distinct().Count())
                {
                    // Duplicates exist
                    return false;
                }
            }

            //Finally Check By Boxes
            return ValidateBoxes();
        }
    }
}
