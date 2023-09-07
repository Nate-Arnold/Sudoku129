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
    public class NavigateCreateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateCreateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new CreatePageViewModel(_navigationStore);
        }
    }
}