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
    /// Логика взаимодействия для TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public TaskControl()
        {
            InitializeComponent();
            ClientCB.ItemsSource = _db.Клиент.ToList();
            ClientCB.SelectedValuePath = "id_клиента";
            ClientCB.DisplayMemberPath = "Имя";
        }

        private void DoneBT_Click(object sender, RoutedEventArgs e)
        {
            var notification = new NotificationManager();
            try
            {
                if (ClientCB.Text == "")
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы не выбрали клиента!",
                        Type = NotificationType.Error
                    });
                    return;
                }

                if (NameTB.Text == "")
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы не ввели название!",
                        Type = NotificationType.Error
                    });
                    return;
                }

                if (DeadlineDP.SelectedDate < DateTime.Now.Date)
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы не можете выбрать такую дату!",
                        Type = NotificationType.Error
                    });
                    return;
                }

                if (descriptionTB.Text == "")
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы не ввели описание задания!",
                        Type = NotificationType.Error
                    });
                    return;
                }

                _db.TaskAdd((int)ClientCB.SelectedValue, NameTB.Text, descriptionTB.Text, DeadlineDP.SelectedDate);
                ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskList());
            }
            catch
            {
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Данные введены неверно!",
                        Type = NotificationType.Error
                     });
                    return;
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskList());
        }
    }
}
