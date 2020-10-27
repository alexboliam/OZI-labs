using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2OZI
{
    /// <summary>
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Page
    {
        protected MainWindow mWindow;
        public UserMenu()
        {
            InitializeComponent();
        }
        public UserMenu(MainWindow mWindow)
        {
            InitializeComponent();
            this.mWindow = mWindow;
        }
        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow passwordWindow = new ChangePasswordWindow();

            if (passwordWindow.ShowDialog() == true)
            {
                MessageBox.Show("Пароль оновлено");
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() => Application.Current.Shutdown());
        }
    }
}
