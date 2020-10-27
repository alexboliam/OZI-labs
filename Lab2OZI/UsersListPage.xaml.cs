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
    /// Логика взаимодействия для UsersListPage.xaml
    /// </summary>
    public partial class UsersListPage : Page
    {
        protected Page previous;
        public UsersListPage(Page previous) 
        { 
            InitializeComponent();
            this.previous = previous;
            lvDataBinding.ItemsSource = UserService.dbUsers;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(previous);
        }

        private void BanChanged(object sender, RoutedEventArgs e)
        {
            UserService.UpdateUsersStatus();
        }
        private void LimitChanged(object sender, RoutedEventArgs e)
        {
            UserService.UpdateUsersStatus();
        }
    }
}
