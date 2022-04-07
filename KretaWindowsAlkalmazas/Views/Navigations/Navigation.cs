using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

namespace Kreta.Views.Navigations
{
    public static class Navigation
    {
        public static MainWindow MainWindow;

        public static void Navigate(UserControl userControl)
        {
            MainWindow.PageContent.Children.Clear();
            MainWindow.PageContent.Children.Add(userControl);
        }
    }
}
