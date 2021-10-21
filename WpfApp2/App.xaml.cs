using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.View.ViewModels;
using WpfApp2.View;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public GameViewModel GameViewModel { get; private set; }

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            StartingScreen startingScreen = new StartingScreen();
            startingScreen.Show();
        }

    }
}
