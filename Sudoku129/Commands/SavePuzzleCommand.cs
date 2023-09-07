using Sudoku129.Model;
using Sudoku129.Stores;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku129.Commands
{
    public class SavePuzzleCommand : CommandBase
    {
        private readonly SudokuPuzzle _sudokuPuzzle;
        private readonly CreatePageViewModel _sudokuPage;

        //Just use the ReturnCommand to exit the page once it is uploaded
        //Not sure if this is best practice but it is easy and makes sense to me
        //Would need to be changed if we wanted to do something other than simply exit on upload, like just clear the page instead
        public ICommand ExitCommand;

        public SavePuzzleCommand(CreatePageViewModel sudokuPage, NavigationStore navigationStore)
        {
            _sudokuPuzzle = new SudokuPuzzle();
            _sudokuPage = sudokuPage;
            ExitCommand = new ReturnCommand(navigationStore);
        }

        public override void Execute(object? parameter)
        {
            for(int ii = 0; ii < 81; ii++)
            {
                if (_sudokuPage.Cells[ii] != null)
                {
                    _sudokuPage.Grid.SetCellValue(_sudokuPage.Cells[ii].CellValue, ii);
                    if(_sudokuPage.Cells[ii].CellValue != "")
                    {
                        //Should probably change base function to just set it to true, since it should not need to be changed to false
                        _sudokuPage.Grid.SetIsGiven(true, ii);
                    }
                }
            }
            
            _sudokuPuzzle.SetPuzzle(_sudokuPage.Name, _sudokuPage.Description, _sudokuPage.Author, _sudokuPage.Difficulty, _sudokuPage.Grid);
            if(_sudokuPuzzle.UploadPuzzle())
            {
                ExitCommand.Execute(null);
            }
        }
    }
}
