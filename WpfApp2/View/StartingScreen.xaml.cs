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
using BalckJack_Wpf.View;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartingScreen : Window
    {
        public StartingScreen()
        {
            InitializeComponent();
        }

        private void StartGame_Btn(object sender, RoutedEventArgs e)
        {
            PlayingHabitsWindow playingHabits = new PlayingHabitsWindow(UserName.Text);
            playingHabits.Show();
            this.Close();
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }


    }
}
