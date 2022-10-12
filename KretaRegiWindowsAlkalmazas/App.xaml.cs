using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Kreta.Views;

namespace Kreta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private MainWindow window;

        protected override void OnStartup(StartupEventArgs e)
        {
            window = new MainWindow();
            window.Show();
            base.OnStartup(e);
        }

    }
}
