using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Sudoku129.Model
{
    public class SudokuPage
    {
        SudokuPuzzle puzzle;

        //TODO Add color selector type object and handle the saving/loading of colors here?

        public SudokuPage()
        { }

        public SudokuCell GetCell(int offset)
        {
            return puzzle.GetCell(offset);
        }

        public void SetCellValue(int row, int column, int value)
        {
            //TODO
        }

        public void SetCellColor(int row, int column, int color)
        {
            //TODO
        }

        public bool Check()
        {
            //Need to check if the puzzle is value
            //For now simply check if puzzle is valid by standard rules

            //Add ability to check Author's solution(for custom rules)

            return puzzle.IsValid();
        }

        public void Submit()
        {
            puzzle.UploadPuzzle();

            //Clear Page and/or display success message
        }
    }
}
