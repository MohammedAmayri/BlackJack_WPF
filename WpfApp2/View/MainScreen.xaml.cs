using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.View.ViewModels;
using GameCardLib.ViewModels;
using System.Media;
using BalckJack_Wpf.View;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Window 
    {
        private GameViewModel _gameViewModel;
        public MainScreen(GameViewModel gameViewModel)
        {
            InitializeComponent();
            _gameViewModel = gameViewModel;
            //Player for the sound effects
            //SoundPlayer soundPlayer = new SoundPlayer();
            //soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Sounds\\BackGroundMusic.wav"; //Change
            //soundPlayer.PlayLooping();
        }
        private void GameOver()
        {
            GameOverScreen gameOverScreen = new GameOverScreen();
            gameOverScreen.Show();
             //To close all the other windows
            foreach (Window item in Application.Current.Windows)
            {
               if (item.DataContext == this) item.Close();
            }
        }
        private void BetButton_Click(object sender, RoutedEventArgs e)
        {
            Button BetButton = sender as Button;
            
            switch (BetButton.Name)
            {
                case "PlayerBet1":
                    _gameViewModel.BetButtonCommand(BetButton.Name);
                    break;
                case "PlayerBet5":
                    _gameViewModel.BetButtonCommand(BetButton.Name);
                    break;
                case "PlayerBet10":
                    _gameViewModel.BetButtonCommand(BetButton.Name);
                    break;
                case "PlayerBet25":
                    _gameViewModel.BetButtonCommand(BetButton.Name);
                    break;
                case "PlayerBet50":
                    _gameViewModel.BetButtonCommand(BetButton.Name);
                    break;
                case "PlayerBet100":
                    _gameViewModel.BetButtonCommand(BetButton.Name);
                    break;
                default:
                    break;
            }
        }
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.PlayerHit();
        }
        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.PlayerStand();
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            Button ActionButton = sender as Button;
            _gameViewModel.ActionButtonCommand(ActionButton.Name,GameOver,() => MessageBox.Show("The cards are now reshuffled"));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.RetrieveData(ourDataGridScreen);
        }

        private void ourDataGridScreen(List<string> playerList)
        {
            DataGridScreen dataGridScreen = new DataGridScreen(playerList,_gameViewModel);
            dataGridScreen.Show();
        }
    }
      
    }

