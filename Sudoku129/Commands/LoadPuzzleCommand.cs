using Sudoku129.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku129.Commands
{
    public class LoadPuzzleCommand : CommandBase
    {
        private readonly SudokuPuzzle _sudokuPuzzle;

        public override void Execute(object? parameter)
        {
            //TODO, download puzzle from database
            //Then need to store data into a SudokuPageViewModel
            //Then need to load that into, and open a SolveSudokuView 

            throw new NotImplementedException();
        }
    }
}
