//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sudoku129.Models
//{
//    public class Timer
//    {
//        //Timer variables
//        private volatile bool _timerRunning;
//        private int _seconds;
//        private string _time;

//        public string Time
//        {
//            get { return _time; }
//            set { _time = value; }
//        }

//        public Timer()
//        {
//            _seconds = 0;
//            _timerRunning = false;
//            _time = "00:00:00";

//            RunTimer();
//        }

//        private async void RunTimer()
//        {
//            int hours;
//            int minutes;
//            int secs;

//            while (_timerRunning)
//            {
//                hours = _seconds / 3600;
//                minutes = (_seconds % 3600) / 60;
//                secs = _seconds % 60;
//                _time = string.Format("{0}:{1}:{2}", hours.ToString("D2"), minutes.ToString("D2"), secs.ToString("D2"));

//                ++_seconds;
//                await Task.Delay(1000); //Delay 1 second
//            }
//        }
//    }
//}
