using Sudoku129.Commands;
using Sudoku129.Model;
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
    public class CreatePageViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private string _name;
        private string _description;
        private string _author;
        private int _difficulty;
        private List<int> _difficulties;
        private SudokuGrid _grid;

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

        public List<int> Difficulties
        {
            get { return _difficulties; }
        }

        public SudokuGrid Grid
        {
            get { return _grid; }
        }

        public ObservableCollection<SudokuCell> Cells { get; set; }

        public ICommand UploadCommand { get; }
        public ICommand ExitCommand { get; }

        public CreatePageViewModel(NavigationStore navigationStore)
        {
            _name = "";
            _description = "";
            _author = "";
            _difficulty = 1;
            _difficulties = new List<int>();
            _difficulties.Add(1);
            _difficulties.Add(2);
            _difficulties.Add(3);
            _difficulties.Add(4);
            _difficulties.Add(5);
            _grid = new SudokuGrid();

            _navigationStore = navigationStore;

            Cells = new ObservableCollection<SudokuCell>();
            for (int ii = 0; ii < 81; ii++)
            {
                Cells.Add(new SudokuCell());
            }

            UploadCommand = new SavePuzzleCommand(this, _navigationStore);
            ExitCommand = new ReturnCommand(_navigationStore);
        }
    }
}