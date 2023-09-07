using Sudoku129.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku129.Database
{
    public class SudokuPuzzleDBObject
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Description { get; set; } = "";
        public int Difficulty { get; set; }
        public SudokuGrid? PuzzleGrid { get; set; }
    }
}
