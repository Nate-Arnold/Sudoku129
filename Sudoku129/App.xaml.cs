using Sudoku129.Model;
using Sudoku129.Stores;
using Sudoku129.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku129
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //TODO should this be a puzzle, or the search list?
        private readonly SudokuPuzzle _sudokuPuzzle;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _sudokuPuzzle = new SudokuPuzzle();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new SearchListViewModel(_navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        //TODO could try to use but need to pass a SudokuPuzzle object into the the views which seems difficult or not possible

        //private SolvePuzzlePageViewModel CreateSolvePuzzlePageViewModel()
        //{
        //    return new SolvePuzzlePageViewModel(_sudokuPuzzle, _navigationStore, CreateSearchListViewModel);
        //}

        //private SearchListViewModel CreateSearchListViewModel()
        //{
        //    return new SearchListViewModel(_navigationStore, CreateSolvePuzzlePageViewModel);
        //}
    }
}
