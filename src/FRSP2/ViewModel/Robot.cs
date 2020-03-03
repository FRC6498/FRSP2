
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace FRSP2.ViewModel
{
    public class Robot : INotifyPropertyChanged
    {
        public ICommand ObjectRelayCommand { get; set; }
        //public static Robot self;

        public Robot()
        {

        }

        // all game events and data points. this class is a liason between the UI itself and the VM

        #region Autonomous
        private int ballsAutoLower = 0; // 2pts
        private int ballsAutoOuter = 0; // 4pts
        private int ballsAutoInner = 0; // 6pts
        private bool crossedAutoLine = false; // true if the robot moves during auto

        //[Index(3)]
        public int BallsAutoLower
        {
            get
            {
                return ballsAutoLower;
            }
            set
            {
                ballsAutoLower = value;
                OnPropertyChanged(nameof(BallsAutoLower));
            }
        }

        //[Index(4)]
        public int BallsAutoOuter
        {
            get
            {
                return ballsAutoOuter;
            }
            set
            {
                ballsAutoOuter = value;
                OnPropertyChanged(nameof(BallsAutoOuter));
            }
        }

        //[Index(5)]
        public int BallsAutoInner
        {
            get
            {
                return ballsAutoInner;
            }
            set
            {
                ballsAutoInner = value;
                OnPropertyChanged(nameof(BallsAutoInner));
            }
        }

        //[Index(6)]
        public bool CrossedAutoLine
        {
            get
            {
                return crossedAutoLine;
            }
            set
            {
                crossedAutoLine = value;
                OnPropertyChanged(nameof(CrossedAutoLine));
            }
        }
        #endregion

        #region Teleop
        private int ballsTeleLower = 0; // 1pt
        private int ballsTeleOuter = 0; // 2pts
        private int ballsTeleInner = 0; // 3pts
        private bool wheelRotationControl = false; // 10pts
        private bool wheelPositionControl = false; // 20pts

        //[Index(7)]
        public int BallsTeleLower
        {
            get
            {
                return ballsTeleLower;
            }
            set
            {
                ballsTeleLower = value;
                OnPropertyChanged(nameof(BallsTeleLower));
            }
        }

        //[Index(8)]
        public int BallsTeleOuter
        {
            get
            {
                return ballsTeleOuter;
            }
            set
            {
                ballsTeleOuter = value;
                OnPropertyChanged(nameof(BallsTeleOuter));
            }
        }

        //[Index(9)]
        public int BallsTeleInner
        {
            get
            {
                return ballsTeleInner;
            }
            set
            {
                ballsTeleInner = value;
                OnPropertyChanged(nameof(BallsTeleInner));
            }
        }

        //[Index(10)]
        public bool WheelRotation
        {
            get
            {
                return wheelRotationControl;
            }
            set
            {
                wheelRotationControl = value;
                OnPropertyChanged(nameof(WheelRotation));
            }
        }

        //[Index(10)]
        public bool WheelPosition
        {
            get
            {
                return wheelPositionControl;
            }
            set
            {
                wheelPositionControl = value;
                OnPropertyChanged(nameof(WheelPosition));
            }
        }
        #endregion

        #region Endgame
        private bool hang = false; // 25pts
        //private bool balance; // neat
        private bool level = false; // 15pts

        //[Index(11)]
        public bool CanHang
        {
            get
            {
                return hang;
            }
            set
            {
                hang = value;
                OnPropertyChanged(nameof(CanHang));
            }
        }

        //[Index(13)]
        public bool IsLevel
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged(nameof(IsLevel));
            }
        }
        #endregion

        #region Misc

        private int? _teamNum;
        private int _matchNum = 1;
        private String _watchPos = string.Empty;

        //[Index(1)]
        public int TeamNumber
        {
            get
            {
                return _teamNum ?? 0;
            }
            set
            {
                _teamNum = value;
                OnPropertyChanged(nameof(TeamNumber));
            }
        }

        //[Index(0)]
        public int MatchNumber
        {
            get
            {
                return _matchNum;
            }
            set
            {
                _matchNum = value;
                OnPropertyChanged(nameof(MatchNumber));
            }
        }

        
        public String WatchPos
        {
            get
            {
                return _watchPos;
            }
            set
            {
                _watchPos = value;
                OnPropertyChanged(nameof(WatchPos));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Reset()
        {
            CrossedAutoLine = false;
            BallsAutoInner = 0;
            BallsAutoLower = 0;
            BallsAutoOuter = 0;
            BallsTeleInner = 0;
            BallsTeleOuter = 0;
            BallsTeleLower = 0;
            CanHang = false;
            IsLevel = false;
            WheelPosition = false;
            WheelRotation = false;
            MatchNumber += 1;
            TeamNumber = 0000;
        }
    }
}
