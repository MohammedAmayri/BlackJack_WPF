using EFBlackJacEL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Model
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
        private int _WholeGameBetAmount=0;
        public Random random = new Random();
        private int _playerID ;
        private PlayingHabit playingHabbits;
        #endregion

        #region properties
        [Key]
        public int PlayerId {
            get; set;
        }
        [Required]
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

        public virtual PlayingHabit PlayerPlayingHabbits
        {
            set; get;
        }

        
        [NotMapped]
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
                _WholeGameBetAmount += _betAmount;
               OnPropertyChanged(nameof(BetAmount));
            }
        }
        [Required]
        public int WholeGameBetAmount
        {
            get => _WholeGameBetAmount;
            set { }
        }

        #endregion

        #region Constructor
        public Player(string name)
        {
            Name = name;
            BankRoll = 100;
            Card = new List<string>();
        }
        #endregion

    }
}
