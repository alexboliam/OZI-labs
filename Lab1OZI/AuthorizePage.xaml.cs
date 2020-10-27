using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
        protected MainWindow mWindow;
        private static int triesCounter = 0;
        public AuthorizePage()
        {
            InitializeComponent();
        }
        public AuthorizePage(MainWindow w)
        {
            InitializeComponent();
            this.mWindow = w;
        }

        private void Authorize(object sender, RoutedEventArgs e)
        {
            UserService.ReadFromFile();
            if(MyLogin.Text == "ADMIN" && UserService.dbUsers.Where(x => x.Login == "ADMIN").Any(x => x.Password == MyPassword.Password.ToString()))
            {
                UserService.currentUser = UserService.dbUsers.First((x) => x.Login == "ADMIN" && x.Password == MyPassword.Password.ToString());
                MainWindow.CurrentPage = new AdminMenu(mWindow);
                mWindow.MainFrame.Navigate(MainWindow.CurrentPage);
                return;
            }
            if(UserService.dbUsers.Where(x => x.Login == MyLogin.Text).Any(x => x.Password == MyPassword.Password.ToString()))
            {
                UserService.currentUser = UserService.dbUsers.First((x) => x.Login == MyLogin.Text && x.Password == MyPassword.Password.ToString());
                if(UserService.currentUser.IsBanned)
                {
                    MessageBox.Show("Даний користувач заблокований та не може користуватись системою. Увійдіть під іншим ім'ям або завершіть роботу програми.");
                    return;
                }
                MainWindow.CurrentPage = new UserMenu(mWindow);
                mWindow.MainFrame.Navigate(MainWindow.CurrentPage);
                return;
            }
            else
            {
                triesCounter++;
                if(triesCounter < 4 && triesCounter != 3)
                {
                    NotFoundError.Text = $"Даного користувача не існує, спробуйте ще раз або завершіть роботу. Залишилось спроб: {3 - triesCounter}";
                    NotFoundError.Visibility = Visibility.Visible;
                }
                else
                {
                    NotFoundError.Text = $"Ви вичерпали спроби входу. Завершення роботи програми через 3 секунди.";
                    NotFoundError.Visibility = Visibility.Visible;
                    AuthButton.IsEnabled = false;
                    var t = new System.Timers.Timer(500);
                    t.Elapsed += T_Elapsed;
                    t.Start();
                }
                
            }

        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread.Sleep(3000);
            Dispatcher.Invoke(() => Application.Current.Shutdown());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() => Application.Current.Shutdown());
        }
        private void MyLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            NotFoundError.Visibility = Visibility.Hidden;
        }
        private void MyPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            NotFoundError.Visibility = Visibility.Hidden;
        }
    }
}
