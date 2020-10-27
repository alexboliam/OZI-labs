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
using System.Windows.Shapes;

namespace Lab2OZI
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(userName.Text != "Ім'я користувача" || userName.Text != "")
            {
                UserService.AddUserToFile(userName.Text);
                this.DialogResult = true;
            }
        }

        private void userName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userName.Text == "Ім'я користувача")
            {
                userName.Text = "";
            }
        }

        private void userName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userName.Text == "")
            {
                userName.Text = "Ім'я користувача";
            }
        }


    }
}
