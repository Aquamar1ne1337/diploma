using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    /// Логика взаимодействия для InsertClientControl.xaml
    /// </summary>
    public partial class InsertClientControl : UserControl
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        int ID { get; set; }

        public InsertClientControl()
        {
            InitializeComponent();
            Registerdp.Text = Getdate();
        }

        public InsertClientControl(int ID)
        {
            InitializeComponent();
            Registerdp.Text = Getdate();
            this.ID = ID;
            Readybtn.Content = "Обновить";
            Nametbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Имя;
            Emailtbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Электронная_почта;
            Registerdp.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Дата_регистрации.ToString();
            Phonetbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Телефон;
            Towntbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Город;

        }

        private void Readybtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var notification = new NotificationManager();
                SecureClass secure = new SecureClass();
                if (Nametbx.Text == "" || Emailtbx.Text == "" || Registerdp.SelectedDate == null || Phonetbx.Text == "" || Towntbx.Text == "")
                {                    
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы ввели не все данные!",
                        Type = NotificationType.Information
                    });
                    return;
                }

                if (DateTime.Now < Registerdp.SelectedDate)
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы ввели неправильную дату!",
                        Type = NotificationType.Information
                    });
                    return;
                }

                if(!secure.IsValidEmail(Emailtbx.Text))
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Почтовый адресс введен неверно!",
                        Type = NotificationType.Information
                    });
                    return;
                }

                if (ID == 0)
                {
                    _db.ClientAdd(Nametbx.Text, Emailtbx.Text, Registerdp.SelectedDate, Phonetbx.Text, Towntbx.Text);
                    notification.Show(new NotificationContent
                    {
                        Title = "Добавление!",
                        Message = "Клиент успешно добавлен!",
                        Type = NotificationType.Information
                    });
                    ((MainWindow)Window.GetWindow(this)).NewClientWindow(new ClientList());
                }
                else
                {
                    _db.ClientUpdate(Nametbx.Text, Emailtbx.Text, Registerdp.SelectedDate, Phonetbx.Text, Towntbx.Text, ID);
                    notification.Show(new NotificationContent
                    {
                        Title = "Обновление!",
                        Message = "Клиент успешно обновлен!",
                        Type = NotificationType.Information
                    });
                    ((MainWindow)Window.GetWindow(this)).NewClientWindow(new ClientList());
                }
            }
            catch {
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Ошибка!",
                    Message = "Данные введены неверно!",
                    Type = NotificationType.Information
                });
            }
        }

        private string Getdate()
        {
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            return date.ToString();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).NewClientWindow(new ClientList());
        }
    }
}
