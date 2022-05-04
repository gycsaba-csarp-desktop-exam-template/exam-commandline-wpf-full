using Kreta.ViewModel;
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

namespace Kreta.Views.Page
{
    /// <summary>
    /// Interaction logic for ParentsAdministrationPage.xaml
    /// </summary>
    public partial class ParentsAdministrationPage : UserControl
    {
        private ParentsViewModel parentsViewModel;
        public ParentsAdministrationPage(ParentsViewModel parentsViewModel)
        {
            this.parentsViewModel = parentsViewModel;
            InitializeComponent();
            this.DataContext = parentsViewModel;
        }
    }
}
