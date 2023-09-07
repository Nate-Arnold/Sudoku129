using Sudoku129.Model;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku129.Commands
{
    public class CheckPuzzleCommand : CommandBase
    {
        private readonly SudokuPuzzle _sudokuPuzzle;
        private readonly SolvePuzzlePageViewModel _sudokuPage;

        public CheckPuzzleCommand(SolvePuzzlePageViewModel sudokuPage, SudokuPuzzle sudokuPuzzle)
        {
            _sudokuPuzzle = sudokuPuzzle;
            _sudokuPage = sudokuPage;
        }
        public override void Execute(object? parameter)
        {
            _sudokuPuzzle.SetPuzzle(_sudokuPage.Name, _sudokuPage.Author, _sudokuPage.Description, _sudokuPage.Difficulty, _sudokuPage.Grid);
           
            //Check if valid, probably want a CheckPuzzle() function, that can also need to display a messagebox depending on validity. 
            if (_sudokuPuzzle.IsValid())
            {
                _sudokuPage.TimerRunning = false; //Stop Timer
                MessageBox.Show("Looks Good!");
            }
            else
            {
                //Should stop and start timer, but its not working for me right now

                //_sudokuPage.TimerRunning = false; //Stop Timer
                MessageBox.Show("Something Doesn't Look Right");
                //_sudokuPage.TimerRunning = true; //Restart Timer when messagebox is closed
            }
        }
    }
}
