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
using System.Text.RegularExpressions;
using Notifications.Wpf;
using MaterialDesignThemes.Wpf;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для UserControlRegistration.xaml
    /// </summary>
    public partial class UserControlRegistration : UserControl
    {
        SecureClass regexobj = new SecureClass();
        public UserControlRegistration()
        {
            InitializeComponent();
           
        }
        private void SignUpChecking()
        {
            if (regexobj.RegistrationCheck(LoginTB.Text, pasreg.Password.ToString(), pasreg2.Password.ToString()))
            {
                regbutton.IsEnabled = true;
            }
            else regbutton.IsEnabled = false;
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignUpChecking();
        }

        private void pasreg_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SignUpChecking();
        }

        private void pasreg2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SignUpChecking();
        }

        private void regbutton_Click(object sender, RoutedEventArgs e)
        {

            string pass = regexobj.HashFunc(pasreg.Password.ToString());
            try
            {
                DiplomadbEntities database = new DiplomadbEntities();
                database.SignUp(LoginTB.Text, pass);
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Новый пользователь.",
                    Message = "Вы успешно зарегестрировались!",
                    Type = NotificationType.Information
                });
                
                Clear();
            }
            catch
            {
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Ошибка!",
                    Message = "Пользователь с таким именем уже существует!",
                    Type = NotificationType.Information
                });
                Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        public int Clear()
        {
            LoginTB.Text = "";
            pasreg.Password = "";
            pasreg2.Password = "";
            return 0;
        }
    }


}
