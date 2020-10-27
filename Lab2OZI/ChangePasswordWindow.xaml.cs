using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(oldPasswordBox.Text == "Старий пароль")
            {
                oldPasswordBox.Text = "";
            }
            if(newPasswordBox.Text == "Новий пароль")
            {
                newPasswordBox.Text = "";
            }
            if (confirmPasswordBox.Text == "Підтвердіть пароль")
            {
                confirmPasswordBox.Text = "";
            }
            if (UserService.currentUser.Password == oldPasswordBox.Text)
            {
                if(newPasswordBox.Text == confirmPasswordBox.Text)
                {
                    if(!UserService.currentUser.IsPasswordLimited || Regex.Matches(newPasswordBox.Text, UserService.passwordLimiter).Count == newPasswordBox.Text.Length)
                    {
                        UserService.ChangePassword(newPasswordBox.Text);
                        this.DialogResult = true;
                        return;
                    }
                    else
                    {
                        InputError.Text = "Неправильна структура паролю. Пароль має містити тільки цифри та знаки арифметичних операцій.";
                        InputError.Visibility = Visibility.Visible;
                        return;
                    }
                }
                else
                {
                    InputError.Text = "Введені паролі не співпадають";
                    InputError.Visibility = Visibility.Visible;
                    return;
                }
            }
            else
            {
                InputError.Text = "Введений неправильний поточний пароль";
                InputError.Visibility = Visibility.Visible;
                return;
            }
        }

        private void oldPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(oldPasswordBox.Text == "Старий пароль")
            {
                oldPasswordBox.Text = "";
            }
        }

        private void newPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (newPasswordBox.Text == "Новий пароль")
            {
                newPasswordBox.Text = "";
            }
        }

        private void confirmPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (confirmPasswordBox.Text == "Підтвердіть пароль")
            {
                confirmPasswordBox.Text = "";
            }
        }

        private void oldPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (oldPasswordBox.Text == "")
            {
                oldPasswordBox.Text = "Старий пароль";
            }
        }

        private void newPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (newPasswordBox.Text == "")
            {
                newPasswordBox.Text = "Новий пароль";
            }
        }

        private void confirmPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (confirmPasswordBox.Text == "")
            {
                confirmPasswordBox.Text = "Підтвердіть пароль";
            }
        }
    }
}
