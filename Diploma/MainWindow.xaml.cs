using MaterialDesignThemes.Wpf;
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
using System.Data.Entity.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public MainWindow()
        {
            InitializeComponent();
            hellotextblock.Text += CurrentUser.Login;
            TaskUpdater();
            TaskCount();
            NotificationShow();
            NewClientWindow(new ClientList());
            NewTaskWindow(new TaskList());
            if (CurrentUser.TypeID == 1)
            {
                AdminBT.Visibility = Visibility.Visible;
            }
        }

        public void TaskCount()
        {
            readytextblock.Text = "Количество ваших выполненных задач: " + _db.ReadyTaskCount(CurrentUser.Id).Single().ToString();
            inprocesstextblock.Text = "Количество ваших задач в процессе: " + _db.InProcessTaskCount(CurrentUser.Id).Single().ToString();
            latetextblock.Text = "Количество ваших просроченных задач: " + _db.lateReadyTaskCount(CurrentUser.Id).Single().ToString();
            dropedtextblock.Text = "Количество ваших невыполненных задач: " + _db.DroppedTaskCount(CurrentUser.Id).Single().ToString();
        }
        

        public void NewClientWindow(UIElement obj)
        {
            ClientGrid.Children.Clear();
            ClientGrid.Children.Add(obj);
        }

        public void NewTaskWindow(UIElement obj)
        {
            TaskGrid.Children.Clear();
            TaskGrid.Children.Add(obj);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AdminBT_Click(object sender, RoutedEventArgs e)
        {
            AdminControlPanel adminControl = new AdminControlPanel();
            adminControl.Show();
        }

        private void TaskUpdater()
        {
            try
            {
                var tasks = _db.UserTaskUpdater(CurrentUser.Id);
                foreach (var a in tasks)
                {
                    if (DateTime.Now.Date > a.Крайний_срок)
                    {       
                        var b = _db.Задание.Where(c => c.id_задания == a.id_задания).FirstOrDefault();                
                        b.id_статуса = 4;
                        Уведомление notif = new Уведомление
                        {
                            Содержание = "Задание " + b.Название + " просрочено!",
                            id_пользователя = a.id_пользователя
                        };
                    _db.Уведомление.Add(notif);
                    }
                }
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Невозможно обновить БД!");
            }

}

        private void NotificationShow()
        {
            try
            {
                var notification = new NotificationManager();
                foreach (var a in _db.Уведомление.Where(u => u.id_пользователя == CurrentUser.Id && u.Статус == 0))
                {
                    notification.Show(new NotificationContent
                    {
                        Title = "У вас новое уведомление!",
                        Message = a.Содержание.ToString(),
                        Type = NotificationType.Information
                    }, expirationTime: TimeSpan.FromSeconds(20));
                    a.Статус = 1;
                }
                _db.SaveChanges();
            }
            catch { }
        }

        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstTabItem.IsSelected)
            {
                TaskCount();
            }    
        }
    }
}
