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

namespace Kreta.View.Page
{
    /// <summary>
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : UserControl
    {
        private TeacherViewModel teacherViewModel;
        public TeacherPage(TeacherViewModel teacherViewModel)
        {
            this.teacherViewModel = teacherViewModel;
            InitializeComponent();
            this.DataContext = teacherViewModel;
        }
    }
}
