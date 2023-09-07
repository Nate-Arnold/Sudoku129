using Sudoku129.Commands;
using Sudoku129.Database;
using Sudoku129.Model;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sudoku129.ViewModels
{
    public class PuzzleViewModel : ViewModelBase
    {
        private int _ID;
        private string _name;
        private string _author;
        private int _difficulty;
        private SudokuGrid _grid;

        public int ID
        {
            get { return _ID; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged(nameof(Difficulty));
            }
        }

        public SudokuGrid Grid
        {
            get { return _grid; }
            set
            {
                _grid = value;
                OnPropertyChanged(nameof(Grid));
            }
        }

        public PuzzleViewModel(SudokuPuzzleDBObject sudokuPuzzle)
        {
            _ID = sudokuPuzzle.ID;
            _name = sudokuPuzzle.Name;
            _author = sudokuPuzzle.Author;
            _difficulty = sudokuPuzzle.Difficulty;
            _grid = sudokuPuzzle.PuzzleGrid;
        }
    }
}
