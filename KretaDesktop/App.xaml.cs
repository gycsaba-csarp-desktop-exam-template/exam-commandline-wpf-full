using ApplicationPropertiesSettings;
using KretaDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ValidationProject.Static;

namespace KretaDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // https://x15.x10hosting.com
            // https://github.com/2021-2022-vizsgaremek-nappali-14b-gyak/gycsaba-vasvari

            base.OnStartup(e);

            ProjectLocalization projectLocalization = new ProjectLocalization();
            projectLocalization.SwitchToCurrentCutureLanguage();

            //var window = new MainWindow() { DataContext = new MainWindowViewModel() };
            //window.Show();
        }
    }
}
