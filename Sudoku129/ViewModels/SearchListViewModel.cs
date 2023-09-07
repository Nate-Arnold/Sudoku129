using Sudoku129.Commands;
using Sudoku129.Model;
using Sudoku129.Stores;
using Sudoku129.ViewModels;
using Sudoku129.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Sudoku129.ViewModels
{
    public class SearchListViewModel : ViewModelBase
    {
        //Notes:

        //Use this viewmodel to grab only the neccasary data for displaying a SudokuPuzzle in the searchlist window???
        //Or Should it just have all the data to transfer to the solving page???

        //On a button click(puzzle selection), this should change the view to a solving page
        //If only some data is stored here, it would need to query the database and send the whole puzzle in???

        //Should add a refresh command/button so users can refresh the list without closing and reopening page

        private readonly NavigationStore _navigationStore;
        private readonly ObservableCollection<PuzzleViewModel> _puzzles;
        private SudokuSearchList _searchList;
        private PuzzleViewModel _sudokuPuzzleViewModel;
        private SudokuPuzzle _sudokuPuzzle;
        private int _id;

        public PuzzleViewModel SelectedPuzzle
        {
            get { return _sudokuPuzzleViewModel; }
            set
            {
                //Extremely scuffed roundabout way of dynamically updated the command parameter
                _sudokuPuzzleViewModel = value;
                SudokuPuzzleDBObject tempObject = _sudokuPuzzle.Sudoku_Puzzles_GetByID(_sudokuPuzzleViewModel.ID);
                _id = tempObject.ID;
                _sudokuPuzzle.SetPuzzle(tempObject.Name, tempObject.Description, tempObject.Author,tempObject.Difficulty, tempObject.PuzzleGrid);
                OnPropertyChanged(nameof(SelectedPuzzle));
            }
        }

        public IEnumerable<PuzzleViewModel> Puzzles => _puzzles;

        public ICommand CreatePuzzleCommand { get; }
        public ICommand SolvePuzzleCommand
        {
            get { return new NavigateSolveCommand(_navigationStore, _sudokuPuzzle); } 
        }
        public ICommand DeleteCommand
        {
            get { return new DeletePuzzleCommand(_navigationStore, _sudokuPuzzle); }
        }

        public SearchListViewModel(NavigationStore navigationStore)
        {
            _puzzles = new ObservableCollection<PuzzleViewModel>();
            SudokuPuzzle puzzle = new SudokuPuzzle();
            _sudokuPuzzle = puzzle;
            _searchList = new SudokuSearchList();
            _id = 0;

            _navigationStore = navigationStore;

            for (int ii = 0; ii < _searchList.Puzzles.Count; ii++)
            {
                _puzzles.Add(new PuzzleViewModel(_searchList.Puzzles[ii]));
            }

            CreatePuzzleCommand = new NavigateCreateCommand(navigationStore);
        }
    }
}
