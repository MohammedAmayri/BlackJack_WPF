using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EFBlackJacDAL;
using EFBlackJacEL.Model;
using GameCardLib.Model;
using Microsoft.EntityFrameworkCore;

namespace GameCardLib.ViewModels
{
    public class GameViewModel : ObservableObject
    {
        #region Delegates
        public delegate void OurDelegate();
        public delegate void OurDelegate2();
        public delegate void OurDelegateForDataGrid(List<string> players);
        #endregion
        #region fields
        private Player _player;
        private Dealer _dealer;
        private GameBoard _gameBoard;
        List<int> playerIds; // To be accessed by multiple methods 

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

        #region Start Game
        public GameViewModel(string playerName,int daysNoGame,int moneySpent)
        {   
            Player = new Player(playerName);
            Dealer = new Dealer("Richard");
            _gameBoard = new GameBoard();
            PlayingHabit playingHabit = new PlayingHabit(daysNoGame, moneySpent);
            Player.PlayerPlayingHabbits = playingHabit;
            playerIds = new List<int>();
            InitializeGame();
        }

        

        private void InitializeGame()
        {
            CanBet = true;
            Messages = "Player Can Make A Bet Now";
        }

        private void Deal()
        {
            CanBet = false;
            _gameBoard.currentGameState = GameBoard.GameState.PlayerBet;
            CanClick = _gameBoard.Clickable();
            var value = _gameBoard.InitialDeal();
            _dealer.Card.Add("../Images/Cards/b1fv.bmp");
            _dealer.HiddenCard = ("../Images/Cards/" + value.dCards[0] + ".bmp");
            _dealer.Card.Add("../Images/Cards/" + value.dCards[1] + ".bmp");
            _player.Card.Add("../Images/Cards/" + value.pCards[0] + ".bmp");
            _player.Card.Add("../Images/Cards/" + value.pCards[1] + ".bmp");

            //to get the numeric value of the card
            int.TryParse(value.dCards[0].Substring(1).TrimStart('0'), out int dCardValue1);
            int.TryParse(value.dCards[1].Substring(1).TrimStart('0'), out int dCardValue2);

            int.TryParse(value.pCards[0].Substring(1).TrimStart('0'), out int cardValue1);
            int.TryParse(value.pCards[1].Substring(1).TrimStart('0'), out int cardValue2);

            //Adjust the value according to the rules
            if (cardValue1 >= 10)
            {
                cardValue1 = 10;
            }
            if (cardValue2 >= 10)
            {
                cardValue2 = 10;
            }
            if (cardValue1 == 1 && cardValue2 >= 10)
            {
                cardValue1 = 11;
            }

            if (dCardValue1 >= 10)
            {
                dCardValue1 = 10;
            }
            if (dCardValue2 >= 10)
            {
                dCardValue2 = 10;
            }
            if (dCardValue1 == 1 && dCardValue2 >= 10)
            {
                dCardValue1 = 11;
            }

            _player.CardTotal = cardValue1 + cardValue2;
            _dealer.HiddenCardTotal = dCardValue1 + dCardValue2;
            _isDealVisible = false;
            OnPropertyChanged(nameof(Player));
            OnPropertyChanged(nameof(Dealer));

            if (_player.CardTotal == 21)
            {
                PlayerBlackJack();
            }

        }

        #endregion

        private void NewRound()
        {
            _dealer.Card.Clear();
            _dealer.CardTotal = 0;
            _player.Card.Clear();
            _player.CardTotal = 0;
            _isVisible = _gameBoard.Visible();
            _gameBoard = new GameBoard();
            _messages = "Please Place Your Bet";
            InitializeGame();
            OnPropertyChanged(nameof(Messages));
            OnPropertyChanged(nameof(Player));
            OnPropertyChanged(nameof(Dealer));
            OnPropertyChanged(nameof(IsVisible));
        }


        #region Game Logic

        #region BettingLogic

        private const int BET1 = 1;
        private const int BET5 = 5;
        private const int BET10 = 10;
        private const int BET25 = 25;
        private const int BET50 = 50;
        private const int BET100 = 100;

        public void CheckBankRoll(int bet, int bankRoll)
        {
            if (bankRoll > 0 && bankRoll - bet >= 0)
            {
                _player.BankRoll -= bet;
                _player.BetAmount = bet;
                _player.TotalBet += bet;
            }
            else
            {
                bet = bankRoll;
                _player.BankRoll -= bet;
                _player.TotalBet += bet;
            }

        }
        public void BetButtonCommand(string bet)
        {
            switch (bet)
            {
                case "PlayerBet1":
                    CheckBankRoll(BET1, _player.BankRoll);
                    break;
                case "PlayerBet5":
                    CheckBankRoll(BET5, _player.BankRoll);
                    break;
                case "PlayerBet10":
                    CheckBankRoll(BET10, _player.BankRoll);
                    break;
                case "PlayerBet25":
                    CheckBankRoll(BET25, _player.BankRoll);
                    break;
                case "PlayerBet50":
                    CheckBankRoll(BET50, _player.BankRoll);
                    break;
                case "PlayerBet100":
                    CheckBankRoll(BET100, _player.BankRoll);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ActionButtonLogic
        public void PlayerHit()
        {
            if (_player.TotalBet >= 1)
            {
                _gameBoard.currentGameState = GameBoard.GameState.PlayerHit;
                _messages = "Player Hit";
                string card = _gameBoard.DealCard();
                int.TryParse(card.Substring(1).TrimStart('0'), out int cardValue1);

                if (cardValue1 >= 10)
                {
                    cardValue1 = 10;
                }

                _player.CardTotal += cardValue1;
                _player.Card.Add("../Images/Cards/" + card + ".bmp");
                CheckPlayerWinCondition();
                OnPropertyChanged(nameof(Player));
                OnPropertyChanged(nameof(Messages));
            }
            else
            {
                _messages = "You Must First Place A Bet!";
                OnPropertyChanged(nameof(Messages));
            }
        }

        public void PlayerStand()
        {
            if (_player.TotalBet >= 1)
            {
                _gameBoard.currentGameState = GameBoard.GameState.PlayerStand;
                _canClick = _gameBoard.Clickable();
                _messages = "Player Stand";
                OnPropertyChanged(nameof(CanClick));
                OnPropertyChanged(nameof(Messages));
                DealerDeal();
            }
        }

        private void DealerDeal()
        {
            _gameBoard.currentGameState = GameBoard.GameState.DealerDraw;
            _messages = "Dealer Draw";
            OnPropertyChanged(nameof(Messages));
            _dealer.CardTotal = _dealer.HiddenCardTotal;
            _dealer.Card[0] = _dealer.HiddenCard;
            while (_dealer.CardTotal <= 16)
            {
                string dCard = _gameBoard.DealCard();
                int.TryParse(dCard.Substring(1).TrimStart('0'), out int dCardValue1);

                if (dCardValue1 >= 10)
                {
                    dCardValue1 = 10;
                }
                _dealer.CardTotal += dCardValue1;
                Dealer.Card.Add("../Images/Cards/" + dCard + ".bmp");

            }
            OnPropertyChanged(nameof(Dealer));
            OnPropertyChanged(nameof(Player));
            CheckGameWinCondition();
        }

        #endregion

        #region WinConditions

        private void CheckPlayerWinCondition()
        {
            if (_player.CardTotal == 21)
            {
                PlayerBlackJack();
            }
            else if (_player.CardTotal > 21)
            {
                PlayerBust();
            }
        }

        private void PlayerBlackJack()
        {
            _gameBoard.currentGameState = GameBoard.GameState.PlayerBlackJack;
            Messages = "Player Black Jack";
            _player.BankRoll += _player.BetAmount * 2;
            _player.TotalWinnings += _player.BetAmount * 2;
            _player.TotalBet = 0;
            _isVisible = _gameBoard.Visible();
            _canClick = _gameBoard.Clickable();
            OnPropertyChanged(nameof(Player));
            OnPropertyChanged(nameof(CanClick));
            OnPropertyChanged(nameof(CanBet));
        }

        private void PlayerBust()
        {
            _gameBoard.currentGameState = GameBoard.GameState.PlayerBust;
            _messages = "Player Bust";
            _canClick = _gameBoard.Clickable();
            _isVisible = _gameBoard.Visible();
            _player.TotalWinnings = 0;
            _player.TotalBet = 0;
            OnPropertyChanged(nameof(IsVisible));
            OnPropertyChanged(nameof(Messages));
            OnPropertyChanged(nameof(CanClick));
        }

        private void DealerBust()
        {
            _gameBoard.currentGameState = GameBoard.GameState.RoundOver;
            _messages = "Dealer Bust";
            _player.TotalWinnings = _player.TotalBet * 2;
            _player.BankRoll += _player.TotalWinnings;
            _player.TotalBet = 0;

        }

        private void DrawGame()
        {
            _gameBoard.currentGameState = GameBoard.GameState.RoundOver;
            _messages = "Draw";
            _player.TotalWinnings = _player.TotalBet;
            _player.BankRoll += _player.TotalWinnings;
            _player.TotalBet = 0;
        }

        private void DealerWin()
        {
            _gameBoard.currentGameState = GameBoard.GameState.RoundOver;
            _messages = "Dealer Won";
            _player.TotalWinnings = 0;
            _player.TotalBet = 0;
        }

        private void PlayerWin()
        {
            _gameBoard.currentGameState = GameBoard.GameState.RoundOver;
            _messages = "Player Won";
            _player.TotalWinnings = _player.TotalBet * 2;
            _player.BankRoll += _player.TotalWinnings;
            _player.TotalBet = 0;
        }

        private void DealerBlackJack()
        {
            _gameBoard.currentGameState = GameBoard.GameState.RoundOver;
            _messages = "Dealer BlackJack";
            _player.TotalWinnings = 0;
            _player.TotalBet = 0;

        }

        public void CheckGameWinCondition()
        {
            if (_dealer.CardTotal > 21)
            {
                DealerBust();
            }
            else if (_dealer.CardTotal == 21)
            {
                DealerBlackJack();
            }
            else if (_player.CardTotal > _dealer.CardTotal)
            {
                PlayerWin();
            }
            else if (_player.CardTotal < _dealer.CardTotal)
            {
                DealerWin();
            }
            else if (_player.CardTotal == _dealer.CardTotal)
            {
                DrawGame();
            }
            else
            {
                _messages = "Something went wrong! You should have never seen this message";
                OnPropertyChanged(nameof(Messages));
            }

            _isVisible = _gameBoard.Visible();

            OnPropertyChanged(nameof(Dealer));
            OnPropertyChanged(nameof(Player));
            OnPropertyChanged(nameof(Messages));
            OnPropertyChanged(nameof(IsVisible));
        }

        #endregion

        #region ButtonCommands

        public void ActionButtonCommand(string actionName,OurDelegate2 gameOverDelegate, OurDelegate reshuffleDelegate)
        {
            switch (actionName)
            {
                case "NextRound":
                    _gameBoard.currentGameState = GameBoard.GameState.PlayerBet;
                    _canClick = _gameBoard.Clickable();

                    if (_player.BankRoll == 0)
                    {
                        SaveToDB();
                        gameOverDelegate();
                        _gameBoard.currentGameState = GameBoard.GameState.GameOver;
                        IsVisible = _gameBoard.Visible();
                    }
                    else
                    {
                        NewRound();
                    }
                    break;

                case "Deal":
                    if (_player.TotalBet < 1)
                        Messages = "Please Place Your Bet First!";
                    else
                    {
                        Deal();
                    }
                    break;
                case "Reshuffle":
                    _gameBoard.Reshuffle();
                   reshuffleDelegate();
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region DataBase
        private void SaveToDB()
        {
            using GameDbContext _dbContext =new GameDbContext(); 
            _dbContext.Players.Add(Player);
            _dbContext.Dealers.Add(Dealer);
            _dbContext.SaveChanges();
        }
         public void RetrieveData(OurDelegateForDataGrid dataGridDelegate)
        {
            List<string> PlayerListForGrid = new List<string>();
            string str = string.Format("{0,-15} {1,-15} {2,-15} {3,-15}\n", "Player ID", "Player Name", "Number of days since last game", "Amount of money Won/lost");
            PlayerListForGrid.Add(str);
            //To retrive the data from the DB using the DBContext
            using GameDbContext _dbContext = new GameDbContext();
            var players = (from player in _dbContext.Players
                           select new
                           {
                               Name = player.Name,
                               id = player.PlayerId,
                               playingHabit=player.PlayerPlayingHabbits
                           }).ToList();

            foreach (var player in players)
            {
                str = string.Format("{0,-15} {1,-15} {2,-15} {3,-15}\n", player.id, player.Name, player.playingHabit.NoGameDays, player.playingHabit.MoneySpent);
                PlayerListForGrid.Add(str);
                playerIds.Add(Convert.ToInt32(player.id));
            }
            _dbContext.SaveChanges();
            dataGridDelegate(PlayerListForGrid);


        }
        public void deleteData(int playerIdIndex)
        {
            int idToSearchFor = playerIds[playerIdIndex];
            using GameDbContext _dbContext = new GameDbContext();
            var players = (from player in _dbContext.Players
                           where player.PlayerId==idToSearchFor
                           select player).ToList();

            foreach (var player in players)
            {
                {  _dbContext.Remove(player); }
            }
            _dbContext.SaveChanges();

        }


        #endregion
        #region Screens
        private void GameOver()
        {
            // delegates to trigger the game over window?
            Messages = "Game Over! Please start a new game!";
        }

        #endregion

        #endregion

    }
}