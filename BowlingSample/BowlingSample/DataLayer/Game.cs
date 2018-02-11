using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSample.DataLayer
{
    public class Game : INotifyPropertyChanged
    {
        #region Properties

        public string Player { get; set; }

        public List<Round> Frames { get; private set; }

        int _totalScore = 0;
        public int TotalScore
        {
            get
            {
                return _totalScore;
            }
            private set
            {
                if (value != _totalScore)
                {
                    _totalScore = value;
                    OnPropertyChanged("TotalScore");
                }
            }
        }

        #endregion

        #region Constructor
        public Game(string player)
        {
            Player = player;
            List<Round> f = new List<Round>();
            for (int i = 1; i <= 10; i++)
            {
                Round r = new Round();
                r.PropertyChanged += Round_PropertyChanged;
                r.Frame = i;
                //r.Ball1 = 0;
                //r.Ball2 = 0;
                //r.Ball3 = 0;
                //r.Ball4 = 0;
                f.Add(r);
            }
            Frames = f;
        }

        private void Round_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CalculateScore();
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

        #region Calculate Score

        public void CalculateScore()
        {
            Round prevFrame1 = null;
            Round prevFrame2 = null;
            int totalScore = 0;
            foreach (Round r in Frames.OrderByDescending(r => r.Frame))
            {
                if (r.Frame == 10)
                {
                    if (r.IsStrike)
                    {
                        r.RoundScore = 10 + r.Ball3 + r.Ball4;
                    }
                    else if (r.IsSpare)
                    {
                        r.RoundScore = 10 + r.Ball3;
                    }
                    else
                    {
                        r.RoundScore = r.Ball1 + r.Ball2;
                    }
                }
                else
                {
                    if (r.IsStrike)
                    {
                        if (prevFrame1 == null)
                        {
                            r.RoundScore = 10;
                        }
                        else if ((prevFrame1.IsStrike) && (prevFrame1.Frame == 10))
                        {
                            r.RoundScore = 10 + 10 + prevFrame1.Ball3;
                        }
                        else if (prevFrame1.IsStrike)
                        {
                            r.RoundScore = 10 + 10 + (prevFrame2 == null ? 0 : prevFrame2.Ball1);
                        }
                        else
                        {
                            r.RoundScore = 10 + (prevFrame1 == null ? 0 : prevFrame1.RoundScore);
                        }
                    }
                    else if (r.IsSpare)
                    {
                        r.RoundScore = 10 + (prevFrame1 == null ? 0 : prevFrame1.Ball1);
                    }
                    else
                    {
                        r.RoundScore = r.Ball1 + r.Ball2;
                    }
                }
                totalScore += r.RoundScore;
                prevFrame2 = prevFrame1;
                prevFrame1 = r;
            }
            TotalScore = totalScore;
        }

        #endregion
    }
}
