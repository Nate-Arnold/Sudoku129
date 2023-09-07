using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sudoku129.Model
{
    public class SudokuCell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        string _cellValue;
        string _cellColor;
        string _textColor;
        bool _isGiven;

        public string CellValue 
        {
            get { return _cellValue; }
            set { _cellValue = value; OnPropertyChanged("CellValue"); }
        }

        public string CellColor
        {
            get { return _cellColor; }
            set { _cellColor = value; OnPropertyChanged("CellColor"); }
        }

        public string TextColor
        {
            get { return _textColor; }
            set { _textColor = value; OnPropertyChanged("TextColor"); }
        }

        public bool IsGiven
        {
            get { return _isGiven;}
            set{ _isGiven = value; OnPropertyChanged("IsGiven"); }
        }

        public SudokuCell()
        {
            _cellValue = "";
            _cellColor = "#ffffff"; //Defult of White
            _textColor = "#0000fa"; //Should have a default text color of blue
            _isGiven = false;
        }
    }
}
