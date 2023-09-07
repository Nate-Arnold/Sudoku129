using Sudoku129.Commands;
using Sudoku129.Model;
using Sudoku129.Models;
using Sudoku129.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku129.ViewModels
{
    public class SolvePuzzlePageViewModel : ViewModelBase
    {
        private string _name;
        private string _description;
        private string _author;
        private int _difficulty;
        private SudokuGrid _grid;

        //Timer variables
        private volatile bool _timerRunning;
        private int _seconds;
        private string _time;
        //private Timer _time; //Should just have one class used

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public bool TimerRunning
        {
            set { _timerRunning = value; }
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
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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
        }

        public ObservableCollection<SudokuCell> Cells { get; set; }
        public ICommand CheckCommand { get; }
        public ICommand ExitCommand { get; }

        public SolvePuzzlePageViewModel(SudokuPuzzle sudokuPuzzle, NavigationStore navigationStore)
        {
            _name = sudokuPuzzle.Name;
            _description = sudokuPuzzle.Description;
            _author = sudokuPuzzle.Author; ;
            _difficulty = sudokuPuzzle.Difficulty; ;
            _grid = sudokuPuzzle.Grid;

            Cells = new ObservableCollection<SudokuCell>();
            for (int ii = 0; ii < 81; ii++)
            {
                Cells.Add(_grid.GetCell(ii));

                //Ensure integer value of 0 is not copied into the grid
                if (Cells[ii].CellValue == "0")
                {
                    Cells[ii].CellValue = "";  
                }
            }

            CheckCommand = new CheckPuzzleCommand(this, sudokuPuzzle);
            ExitCommand = new ReturnCommand(navigationStore);

            _seconds = 0;
            _timerRunning = true;
            _time = "00:00:00";

            RunTimer();
        }

        private async void RunTimer()
        {
            int hours;
            int minutes;
            int secs;

            while (_timerRunning)
            {
                hours = _seconds / 3600;
                minutes = (_seconds % 3600) / 60;
                secs = _seconds % 60;
                _time = string.Format("{0}:{1}:{2}", hours.ToString("D2"), minutes.ToString("D2"), secs.ToString("D2"));
                ++_seconds;
                await Task.Delay(1000); //Delay 1 second
                OnPropertyChanged(nameof(Time));
            }
        }
    }
}
