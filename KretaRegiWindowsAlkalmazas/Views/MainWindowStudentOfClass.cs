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

using Kreta.Views.Navigations;
using Kreta.Views.Pages;
using Kreta.ViewModels;

namespace Kreta.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentOfClassViewModel studentOfClassViewModel = new StudentOfClassViewModel();


        public void miStudentOfClass_Click(object sender, RoutedEventArgs e)
        {
            StudentOfClassPage studentOfClassPage = new StudentOfClassPage(studentOfClassViewModel);
            Navigation.Navigate(studentOfClassPage);
        }
    }
}
