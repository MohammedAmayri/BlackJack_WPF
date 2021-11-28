using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Model
{
    public class Dealer : ObservableObject
    {
        #region fields
        private string _name;
        private int? _cardTotal;
        private List<string> _card;
        private string _hiddenCard;
        private int _hiddenCardTotal;
        public Random random = new Random();
        private int _DealerID;
        #endregion

        #region properties
        [Key]
        public int PlayerId
        {
            get => _DealerID;
            set { _DealerID = random.Next(1, 10000); }
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

        public int? CardTotal
        {
            get => _cardTotal;
            set
            {
                _cardTotal = value;
               OnPropertyChanged(nameof(CardTotal));
            }
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
