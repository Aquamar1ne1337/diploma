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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Notifications.Wpf;
using Stimulsoft.Report;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для AdminControlPanel.xaml
    /// </summary>
    public partial class AdminControlPanel : Window
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public AdminControlPanel()
        {
            InitializeComponent();
            notegridview.ItemsSource = _db.AdminNoteLists.ToList();

            usertodis.ItemsSource = _db.EmployeeView().ToList();
            usertodis.SelectedValuePath = "id_пользователя";
            usertodis.DisplayMemberPath = "Логин";

            tasktodis.ItemsSource = _db.TasksPerformed().ToList();
            tasktodis.SelectedValuePath = "id_задания";
            tasktodis.DisplayMemberPath = "Название";

            taskgridview.ItemsSource = _db.Задание.Where(n => n.id_статуса == 2 || n.id_статуса == 4).ToList();
            taskended.ItemsSource = _db.Задание.Where(n => n.id_статуса == 3 || n.id_статуса == 5).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void disaddbutton_Click(object sender, RoutedEventArgs e)
        {
            
            int i = _db.Распределение.Where(u => u.id_задания == (int)tasktodis.SelectedValue).Where(u => u.id_пользователя == (int)usertodis.SelectedValue).Count();
            if (i >= 1)
            {
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Ошибка!",
                    Message = "Этот пользователь уже распределен!",
                    Type = NotificationType.Error
                });
            }
            else
            {
                _db.TaskDistribution((int)tasktodis.SelectedValue, (int)usertodis.SelectedValue);
            }
        }

        private void GanttChartButton_Click(object sender, RoutedEventArgs e)
        {
            StiReport report = new StiReport();
            report.Load("Report.mrt");
            report.ShowWithWpf();
        }

        private void Updatebutton_Click(object sender, RoutedEventArgs e)
        {
            _db.SaveChanges();
        }

        private void disdeletebutton_Click(object sender, RoutedEventArgs e)
        {
            
            int i = _db.Распределение.Where(u => u.id_задания == (int)tasktodis.SelectedValue).Where(u => u.id_пользователя == (int)usertodis.SelectedValue).Count();
            int i2 = _db.Распределение.Where(u => u.id_задания == (int)tasktodis.SelectedValue).Count();
            if (i >= 1)
            {
                if (i2 > 1)
                {
                    _db.TaskRemoveDistribution((int)tasktodis.SelectedValue, (int)usertodis.SelectedValue);
                    _db.OnTaskRemoveDistribution((int)usertodis.SelectedValue, (int)tasktodis.SelectedValue);
                }
                else
                {
                    var notification = new NotificationManager();
                    notification.Show(new NotificationContent
                    {
                        Title = "Ошибка!",
                        Message = "Вы не можете снять единственного сотрудника с задания!",
                        Type = NotificationType.Error
                    });
                }
            }
            else if (i == 0)
            {
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Ошибка!",
                    Message = "Этого пользователя нет на этом задании!",
                    Type = NotificationType.Error
                });
            }
            
        }
    }
}
