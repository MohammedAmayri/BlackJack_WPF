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
using WpfApp2;

namespace BalckJack_Wpf.View
{
    /// <summary>
    /// Interaction logic for PlayingHabitsWindow.xaml
    /// </summary>
    public partial class PlayingHabitsWindow : Window
    {
        string playerName;
        int cashEarnedOrSpent;
        int numberOfDaysSinceLastGame;
        int wonLastGame = 1;
        public PlayingHabitsWindow(string playerName)
        {
            this.playerName = playerName;
            InitializeComponent();
        }

        private void WonRB_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void LostRB_Checked(object sender, RoutedEventArgs e)
        {
            wonLastGame = -1;
        }

        private void StartGame_Btn(object sender, RoutedEventArgs e)
        {   
            GameViewModel gameViewModel = new GameViewModel(playerName, numberOfDaysSinceLastGame, cashEarnedOrSpent);
            MainScreen mainScreen = new MainScreen(gameViewModel);
            mainScreen.DataContext = gameViewModel;
            mainScreen.Show();
            this.Close();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            numberOfDaysSinceLastGame = 1;
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            numberOfDaysSinceLastGame = 6;
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            numberOfDaysSinceLastGame = 20;
        }
        private void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            numberOfDaysSinceLastGame = 30;
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
