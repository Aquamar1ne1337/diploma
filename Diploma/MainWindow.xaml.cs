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
            TaskUpdater(CurrentUser.Id);
            readytextblock.Text = "Количество ваших выполненных задач: " + _db.ReadyTaskCount(CurrentUser.Id).Single().ToString();
            inprocesstextblock.Text = "Количество ваших задач в процессе: " + _db.InProcessTaskCount(CurrentUser.Id).Single().ToString();
            latetextblock.Text = "Количество ваших просроченных задач: " + _db.lateReadyTaskCount(CurrentUser.Id).Single().ToString();
            dropedtextblock.Text = "Количество ваших невыполненных задач: " + _db.DroppedTaskCount(CurrentUser.Id).Single().ToString(); 
            
            NewClientWindow(new ClientList());
            NewTaskWindow(new TaskList());
            if (CurrentUser.TypeID == 1)
            {
                AdminBT.Visibility = Visibility.Visible;
            }
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

        private void TaskUpdater(int id)
        {
            try
            {
                var notification = new NotificationManager();
                foreach (var a in _db.UserTaskUpdater(id))
                {
                    if (DateTime.Now.Date > a.Крайний_срок && DateTime.Now.Date < a.Крайний_срок.AddDays(7).Date)
                    {

                        var b = _db.Задание.Where(c => c.id_задания == a.id_задания).FirstOrDefault();
                        b.id_статуса = 4;
                        notification.Show(new NotificationContent
                        {
                            Title = "Изменение статуса!",
                            Message = "Задание " + a.Название.ToString() + " просрочено!",
                            Type = NotificationType.Information
                        }, expirationTime: TimeSpan.FromSeconds(10));

                    }
                    if (DateTime.Now.Date > a.Крайний_срок && DateTime.Now.Date > a.Крайний_срок.AddDays(7).Date)
                    {
                        var b = _db.Задание.Where(c => c.id_задания == a.id_задания).FirstOrDefault();
                        b.id_статуса = 6;
                        notification.Show(new NotificationContent
                        {
                            Title = "Изменение статуса!",
                            Message = "Задание " + a.Название.ToString() + " не завершено, т.к. прошло больше недели!",
                            Type = NotificationType.Information

                        }, expirationTime: TimeSpan.FromSeconds(10));

                    }
                }
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Невозможно обновить БД!");
            }

        }
    }
}
