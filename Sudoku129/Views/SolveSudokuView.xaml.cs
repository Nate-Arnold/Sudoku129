using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku129.Views
{
    /// <summary>
    /// Interaction logic for SolveSudokuView.xaml
    /// </summary>
    public partial class SolveSudokuView : UserControl
    {
        public SolveSudokuView()
        {
            InitializeComponent();
        }

        //Limit Cells to only accept the digits 1-9
        private void CellDigitValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]");
            e.Handled = regex.IsMatch(e.Text);

            //Prevent Space? Not sure why Regex allows it
            if (e.Text == " ")
            {
                e.Handled = true;
            }
        }

        //PreviewTextInput does not handle spacebar input, adding this extra check prevent spaces from being entered
        //Note: Does not prevent spaces be copy + pasted in
        private void PreventSpacebar(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //Prevents characters being pasted into textbox, which would otherwise ignore the regex
        private void PreventPasteAction(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        //Updates SudokuPuzzle object if input is valid and checks puzzle validity
        private void CellModified(object sender, TextChangedEventArgs e)
        {
            //TODO Test if input is a digit from 1-9

            //TODO Update a SudokuPage object(use the textbox to get row and column values, then call SetCellValue/SetCellColor)

            //TODO Call a validity check function, IsValid()
            //If invalid it should highlight the cell as red
            //Should also highlight the related cells causing the invalidity, but that is extra functionality
        }

        private void CheckClicked(object sender, RoutedEventArgs e)
        {
            //Clear all entered data? Or simply return to main menu view?
            //Currently clearing data seems slightly difficulty because of the extra levels of stackpanels

            //TODO, the actual upload should be handled by a command binded to a viewmodel
        }
    }
}
