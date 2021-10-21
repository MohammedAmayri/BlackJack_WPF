﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class Dealer : ObservableObject
    {
        #region fields
        private string _name;
        private int? _cardTotal;
        private List<string> _card;
        private string _hiddenCard;
        private int _hiddenCardTotal;
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

        public int? CardTotal
        {
            get => _cardTotal;
            set
            {
                _cardTotal = value;
               OnPropertyChanged(nameof(CardTotal));
            }
        }

        public List<string> Card
        {
            get => _card;
            set
            {
                _card = value;
               OnPropertyChanged(nameof(Card));
            }
        }

        public string HiddenCard
        {
            get => _hiddenCard;
            set
            {
                _hiddenCard = value;
               OnPropertyChanged(nameof(Player));
            }
        }

        public int HiddenCardTotal
        {
            get => _hiddenCardTotal;
            set
            {
                _hiddenCardTotal = value;
               OnPropertyChanged(nameof(HiddenCardTotal));
            }
        }
        #endregion

        #region Constructor
        public Dealer(string name)
        {
            _name = name;
            this.Card = new List<string>();
        }
        #endregion
    }
}
