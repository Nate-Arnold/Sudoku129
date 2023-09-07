using Sudoku129.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku129.Model
{
    public class SudokuPuzzle : SudokuPuzzleDatabase
    {
        private string _name;
        private string _description;
        private string _author;
        private int _difficulty;
        private SudokuGrid _grid;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
       
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }
        public SudokuGrid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        public SudokuPuzzle()
        {
            _name = "";
            _author = "";
            _description = "Standard Sudoku Rules Apply";
            _difficulty = 1;

            //Could set grid size here in future
            _grid = new SudokuGrid();
        }

        public void SetPuzzle(string name, string description, string author, int difficulty, SudokuGrid grid)
        {
            _name = name;
            _description = description;
            _author = author;
            _difficulty = difficulty;
            _grid = grid;
        }

        public SudokuCell GetCell(int offset)
        {
            return _grid.GetCell(offset);
        }

        public bool IsValid()
        {
            return _grid.IsValid();
        }

        public bool IsValidUpload()
        {
            return _grid.IsValidUpload();
        }

        public bool UploadPuzzle()
        {
            if (IsValidUpload())
            {
                //Object to be uploaded to database
                SudokuPuzzleDBObject puzzleDB = new SudokuPuzzleDBObject();

                //Copy data to puzzleDB
                puzzleDB.PuzzleGrid = _grid;
                puzzleDB.Difficulty = _difficulty;
                puzzleDB.Author = _author;
                puzzleDB.Name = _name;
                puzzleDB.Description = _description;

                //Upload this puzzle to the database
                Sudoku_Puzzles_SavePuzzle(puzzleDB);
                return true;
            }
            else
            {
                MessageBox.Show("Puzzle is not valid and cannot be uploaded");
                return false;
            }
        }
    }
}
