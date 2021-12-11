using GameCardLib.Model;
using GameCardLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace BalckJack_Wpf.View
{
    /// <summary>
    /// Interaction logic for DataGridScreen.xaml
    /// </summary>
    public partial class DataGridScreen : Window
    {
        GameViewModel _gameViewModel;
        public DataGridScreen(List<string> playerList,GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            StringWraper stringWraper = new StringWraper(playerList);
            InitializeComponent();
            ObservableCollection<string> obsCollection = new ObservableCollection<string>(playerList);
            
            this.MyListBox.ItemsSource = stringWraper.PlayerListToWrap;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(MyListBox.SelectedItem.ToString());
            _gameViewModel.deleteData(MyListBox.SelectedIndex - 1);
        }
    }
}
