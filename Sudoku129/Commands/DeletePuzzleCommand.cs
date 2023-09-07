using Sudoku129.Model;
using Sudoku129.Stores;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sudoku129.Commands
{
    public class DeletePuzzleCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SudokuPuzzle _sudokuPuzzle;

        public DeletePuzzleCommand(NavigationStore navigationStore, SudokuPuzzle sudokuPuzzle)
        {
            _navigationStore = navigationStore;
            _sudokuPuzzle = sudokuPuzzle;
        }

        public override void Execute(object? parameter)
        {
            //Absolutely no idea why it requires me to use the navigation just to get the ID instead of passing an int, but it works I guess
            if(((SearchListViewModel)(_navigationStore.CurrentViewModel)).SelectedPuzzle != null)
            {
                _sudokuPuzzle.Sudoku_Puzzles_RemoveByID(((SearchListViewModel)(_navigationStore.CurrentViewModel)).SelectedPuzzle.ID);
            }
            _navigationStore.CurrentViewModel = new SearchListViewModel(_navigationStore); //Refresh SearchListView so deleted puzzle is gone
        }
    }
}
