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
using Notifications.Wpf;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        SecureClass regexobj = new SecureClass();

        public UserControlLogin()
        {
            InitializeComponent();
        }

        private void SignInChecking()
        {
            if (regexobj.LoginCheck(LoginTB.Text, pasentertb.Password.ToString()))
            {
                enterbt.IsEnabled = true;
            }
            else enterbt.IsEnabled = false;
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignInChecking();
        }

        private void pasentertb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SignInChecking();
        }

        private void enterbt_Click(object sender, RoutedEventArgs e)
        {
            string pass = regexobj.HashFunc(pasentertb.Password.ToString()); 
            using (DiplomadbEntities diplomadb = new DiplomadbEntities())
            {
                var user = diplomadb.Пользователь.FirstOrDefault(u => u.Логин == LoginTB.Text);
                {
                    if (user != null)
                    {
                        if (user.Пароль == pass)
                        {
                            if (user.id_типа == 1)
                            {
                                MessageBox.Show("Админ");
                                Application.Current.Shutdown();

                            }
                            else
                            {
                                CurrentUser.Login = LoginTB.Text;
                                CurrentUser.Id = user.id_пользователя;
                                MainWindow main = new MainWindow();
                                main.Show();
                                var myWindow = Window.GetWindow(this);
                                myWindow.Close();
                            }
                        }
                        else
                        {
                            var notification = new NotificationManager();
                            notification.Show(new NotificationContent
                            {
                                Title = "Ошибка!",
                                Message = "Неправильный пароль!",
                                Type = NotificationType.Information
                            });
                        }
                    }
                    else
                    {
                        var notification = new NotificationManager();
                        notification.Show(new NotificationContent
                        {
                            Title = "Ошибка!",
                            Message = "Такого пользователя не существует!",
                            Type = NotificationType.Information
                        });
                    }
                }

            }
        }

        private void Closebt_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
