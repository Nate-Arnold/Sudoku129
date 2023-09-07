using Sudoku129.Database;
using Sudoku129.Model;
using Sudoku129.Stores;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku129.Commands
{
    public class NavigateSolveCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SudokuPuzzle _sudokuPuzzle;

        public NavigateSolveCommand(NavigationStore navigationStore, SudokuPuzzle sudokuPuzzle)
        {
            _navigationStore = navigationStore;
            _sudokuPuzzle = sudokuPuzzle;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SolvePuzzlePageViewModel(_sudokuPuzzle, _navigationStore);
        }
    }
}
