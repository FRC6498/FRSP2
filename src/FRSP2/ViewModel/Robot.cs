using System;
using System.ComponentModel;
using System.Windows.Input;

namespace FRSP2.ViewModel
{
    public abstract class Robot : INotifyPropertyChanged
    {
        public ICommand ObjectRelayCommand { get; set; }
        public Robot()
        {
        
        }

        #region Misc

        private int? _teamNum;
        private int _matchNum = 1;
        private enum WatchPos {RED1, RED2, RED3, BLUE1, BLUE2, BLUE3, NA}; 
        private WatchPos _watchPos = WatchPos.NA;

        /*
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
        */

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void Reset()
        {
        
        }
    }
}
