
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace FRSP2.ViewModel
{
    public class Robot2020 : Robot
    {

        public Robot2020()
        {

        }

        // all game events and data points. this class is a liason between the UI itself and the VM

        #region Autonomous
        private int ballsAutoLower = 0; // 2pts
        private int ballsAutoOuter = 0; // 4pts
        private int ballsAutoInner = 0; // 6pts
        private bool crossedAutoLine = false; // true if the robot moves during auto

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
        private bool park = false; // 5pts
        //private bool balance; // neat
        private bool level = false; // 15pts

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

        public bool CanPark
        {
            get
            {
                return park;
            }
            set
            {
                park = value;
                OnPropertyChanged(nameof(CanPark));
            }
        }

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
        
        public override void Reset()
        {
            CrossedAutoLine = false;
            BallsAutoInner = 0;
            BallsAutoLower = 0;
            BallsAutoOuter = 0;
            BallsTeleInner = 0;
            BallsTeleOuter = 0;
            BallsTeleLower = 0;
            CanHang = false;
            CanPark = false;
            IsLevel = false;
            WheelPosition = false;
            WheelRotation = false;
            MatchNumber += 1;
            TeamNumber = 0000;
        }
    }
}
