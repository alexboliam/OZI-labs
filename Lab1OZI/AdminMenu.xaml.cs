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

namespace Lab1OZI
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        protected MainWindow mWindow;
        public AdminMenu()
        {
            InitializeComponent();
        }
        public AdminMenu(MainWindow mWindow)
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

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUserWindow addWindow = new AddUserWindow();

            if (addWindow.ShowDialog() == true)
            {
                MessageBox.Show("Нового користувача додано");
            }
        }
        private void ShowUserList(object sender, RoutedEventArgs e)
        {
            UsersListPage page = new UsersListPage(this);
            NavigationService.Navigate(page);
        }
    }
}
