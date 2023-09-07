using Sudoku129.Stores;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku129.Commands
{
    public class ReturnCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public ReturnCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SearchListViewModel(_navigationStore);
        }
    }
}