using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.View.ViewModels
{
    public class GameViewModel : ObservableObject
    {
        #region fields
        private Player _player;
        private Dealer _dealer;
        private GameBoard _gameBoard;
        #endregion

        #region properties 
        public Player Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public Dealer Dealer
        {
            get => _dealer;
            set
            {
                _dealer = value;
                OnPropertyChanged(nameof(Dealer));
            }
        }

        private string _messages;

        public string Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }


        private bool _canClick;

        public bool CanClick
        {
            get => _canClick;
            set
            {
                _canClick = value;
                OnPropertyChanged(nameof(CanClick));
            }
        }

        private bool _canBet;

        public bool CanBet
        {
            get => _canBet;
            set
            {
                _canBet = value;
                OnPropertyChanged(nameof(CanBet));
            }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private bool _isDealVisible;

        public bool IsDealVisible
        {
            get => _isDealVisible;
            set
            {
                _isDealVisible = value;
                OnPropertyChanged(nameof(IsDealVisible));
            }
        }

        #endregion


    }
}
