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
            _gameViewModel.ActionButtonCommand(ActionButton.Name);
        }
    }
      
    }

