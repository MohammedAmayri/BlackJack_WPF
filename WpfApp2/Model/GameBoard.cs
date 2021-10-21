using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class GameBoard : ObservableObject
    {
        #region Enum
        public enum GameState
        {
            PlayerBet,
            PlayerHit,
            PlayerStand,
            DealerStand,
            DealerDraw,
            PlayerBust,
            DealerBust,
            PlayerBlackJack,
            DealerBlackJack,
            Draw,
            PlayerWon,
            DealerWon,
            RoundOver,
            NewRound
        };
        #endregion

        #region CardLogic
        List<string> cards = new List<string>()
        {
            "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "d13", "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13", "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13", "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13"
        };
        List<string> selectedCards = new List<string>();
        const int initialDealNumberOfCards = 2;

        public (List<string> dCards,List<string> pCards) InitialDeal()
        {
            List<string> dealerCards = new List<string>();
            List<string> playerCards = new List<string>();
            Random random = new Random();

            for (int i = 0; i < initialDealNumberOfCards; i++)
            {
                int r = random.Next(0, cards.Count);
                string chosenCard = cards[r];
                dealerCards.Add(chosenCard);
                selectedCards.Add(chosenCard);
                cards.Remove(chosenCard);

            }

            for (int i = 0; i < initialDealNumberOfCards; i++)
            {
                int r = random.Next(0, cards.Count);
                string chosenCard = cards[r];
                playerCards.Add(chosenCard);
                selectedCards.Add(chosenCard);
                cards.Remove(chosenCard);

            }
            return (dealerCards, playerCards);
        }

        public string DealCard()
        {
            Random random = new Random();
            int r = random.Next(0, cards.Count);
            string chosenCard = cards[r];
            selectedCards.Add(chosenCard);
            cards.Remove(chosenCard);
            return chosenCard;
        }

        public void Reshuffle()
        {   // Check logic here!
            for (int i = 0; i < selectedCards.Count; i++)
            {
                cards.Add(selectedCards[i]);
            }

            selectedCards.Clear();
        }
        #endregion

        #region GameStateLogic

        public GameState currentGameState { get; set; }
        public bool Clickable()
        {
            if (currentGameState == GameState.PlayerStand || currentGameState == GameState.PlayerBust || currentGameState == GameState.PlayerBlackJack)
            {
                return false;
            }
            else if (currentGameState == GameState.PlayerBet)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool Visible()
        {
            if (currentGameState == GameState.RoundOver || currentGameState == GameState.PlayerBlackJack || currentGameState == GameState.PlayerBust)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
