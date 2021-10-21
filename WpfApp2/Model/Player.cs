using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class Player : ObservableObject
    {
        #region fields
        private string _name;
        private int _bankRoll;
        private int _totalBet;
        private int _totalWinnings;
        private int? _cardTotal;
        private List<string> _card;
        private int _betAmount;
        #endregion

        #region properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
               OnPropertyChanged(nameof(Name));
            }
        }

        public int BankRoll
        {
            get => _bankRoll;
            set
            {
                _bankRoll = value;
               OnPropertyChanged(nameof(BankRoll));
            }
        }

        //[JsonIgnore]
        public int TotalBet
        {
            get => _totalBet;
            set
            {
                _totalBet = value;
               OnPropertyChanged(nameof(TotalBet));
            }
        }

        //[JsonIgnore]
        public int TotalWinnings
        {
            get => _totalWinnings;
            set
            {
                _totalWinnings = value;
               OnPropertyChanged(nameof(TotalWinnings));
            }
        }

        //[JsonIgnore]
        public int? CardTotal
        {
            get => _cardTotal;
            set
            {
                _cardTotal = value;
               OnPropertyChanged(nameof(CardTotal));
            }
        }


        //[JsonIgnore]
        public List<string> Card
        {
            get => _card;
            set
            {
                _card = value;
               OnPropertyChanged(nameof(Card));
            }
        }

        //[JsonIgnore]
        public int BetAmount
        {
            get => _betAmount;
            set
            {
                _betAmount = value;
               OnPropertyChanged(nameof(BetAmount));
            }
        }

        #endregion

        #region Constructor
        public Player(string name)
        {
            _name = name;
            Card = new List<string>();
        }
        #endregion

    }
}
