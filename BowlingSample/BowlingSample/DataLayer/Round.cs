using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSample.DataLayer
{
    public class Round : INotifyPropertyChanged
    {
        #region Properties

        public int Frame { get; set; }

        int _ball1 = 0;
        public int Ball1
        {
            get
            {
                return _ball1;
            }
            set
            {
                if ((value != _ball1) && (value >= 0) && (value <= 10))
                {
                    _ball1 = value;
                    if (value == 10)
                    {
                        Ball2 = 0;
                    }
                    OnPropertyChanged("Ball1");
                    OnPropertyChanged("IsBall2Enabled");
                    OnPropertyChanged("IsBall3Enabled");
                    OnPropertyChanged("IsBall4Enabled");
                }
            }
        }

        int _ball2 = 0;
        public int Ball2
        {
            get
            {
                return _ball2;
            }
            set
            {
                if ((value != _ball2) && (value >= 0) && (value <= 10) && ((_ball1 + value) <= 10))
                {
                    _ball2 = value;
                    OnPropertyChanged("Ball2");
                    OnPropertyChanged("IsBall2Enabled");
                    OnPropertyChanged("IsBall3Enabled");
                    OnPropertyChanged("IsBall4Enabled");
                }
            }
        }

        int _ball3 = 0;
        public int Ball3
        {
            get
            {
                return _ball3;
            }
            set
            {
                if ((value != _ball3) && (value >= 0) && (value <= 10))
                {
                    _ball3 = value;
                    OnPropertyChanged("Ball3");
                    OnPropertyChanged("IsBall3Enabled");
                    OnPropertyChanged("IsBall4Enabled");
                }
            }
        }

        int _ball4 = 0;
        public int Ball4
        {
            get
            {
                return _ball4;
            }
            set
            {
                if ((value != _ball4) && (value >= 0) && (value <= 10))
                {
                    _ball4 = value;
                    OnPropertyChanged("Ball4");
                    OnPropertyChanged("IsBall3Enabled");
                    OnPropertyChanged("IsBall4Enabled");
                }
            }
        }

        public int RoundScore { get; set; }

        public bool IsStrike
        {
            get
            {
                return Ball1 == 10;
            }
        }

        public bool IsSpare
        {
            get
            {
                return (Ball1 + Ball2) == 10;
            }
        }

        public bool IsFrame10
        {
            get
            {
                return Frame == 10;
            }
        }

        public bool IsBall2Enabled
        {
            get
            {
                return Ball1 != 10;
            }
        }

        public bool IsBall3Enabled
        {
            get
            {
                return (IsFrame10 && (IsSpare || IsStrike));
            }
        }
        public bool IsBall4Enabled
        {
            get
            {
                return (IsFrame10 && IsStrike);
            }
        }
        #endregion

        #region Constructor

        public Round()
        {
            Ball1 = 0;
            Ball2 = 0;
            Ball3 = 0;
            Ball4 = 0;
            RoundScore = 0;
            Frame = 0;
        }
        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
