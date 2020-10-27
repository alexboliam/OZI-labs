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

namespace Lab1OZI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Page CurrentPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CurrentPage = new AuthorizePage(this);
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            MainFrame.Navigate(CurrentPage);
        }
        private void Author_Click(object sender, RoutedEventArgs e)
        {
            ProgramInfoWindow programInfo = new ProgramInfoWindow();
            programInfo.ShowDialog();
        }
    }
}
