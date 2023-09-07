using Sudoku129.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku129.Model
{
    //Note: Could probably make a singleton
    public class SudokuSearchList : SudokuPuzzleDatabase
    {
        private List<SudokuPuzzleDBObject> _puzzles;

        public List<SudokuPuzzleDBObject> Puzzles
        {
            get { return _puzzles; }
        }

        public SudokuSearchList()
        {
            _puzzles = new List<SudokuPuzzleDBObject>();

            _puzzles = Sudoku_Puzzles_GetList();
        }
    }
}
