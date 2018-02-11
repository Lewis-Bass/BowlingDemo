using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelSupport;
using BowlingSample.DataLayer;

namespace BowlingSample.ViewModel
{
    public class GameEntryVM : ViewModelBase
    {
        #region Properties

        List<Game> _games;
        public List<Game> Games
        {
            get
            {
                return _games;
            }
        }

        #endregion

        #region Constructor

        public GameEntryVM()
        {
            _games = new List<Game>();
            Game l = new Game("Lewis");
            l.PropertyChanged += Game_PropertyChanged;
            _games.Add(l);
            Game p = new Game("Paula");
            p.PropertyChanged += Game_PropertyChanged;
            _games.Add(p);
            RaisePropertyChanged("Games");
        }

        private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Games");
        }

        #endregion

        #region Recalculate

        public void Recalculate()
        {
            foreach(var game in _games)
            {
                game.CalculateScore();

            }
            RaisePropertyChanged("Games");
        }

        #endregion


    }
}
