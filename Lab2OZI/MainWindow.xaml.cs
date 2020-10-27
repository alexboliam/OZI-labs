using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab2OZI
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
            if(!KeyChecker.Check())
            {
                MessageBox.Show("Пiдпис користувача не спiвпадае з пiдписом власника програми. Завершення роботи.");
                Dispatcher.Invoke(() => Application.Current.Shutdown());
            }
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
