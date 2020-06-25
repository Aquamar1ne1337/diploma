using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Notifications.Wpf;
using Stimulsoft.Report;
using System.Security.Cryptography;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для TaskReview.xaml
    /// </summary>
    public partial class TaskReview : UserControl
    {
       

        DiplomadbEntities _db = new DiplomadbEntities();
        public int DestributionID { get; set; }

        public int TaskID { get; set; }
        public TaskReview(int id, int destributionId)
        {
            InitializeComponent();
            TaskID = id;
            DestributionID = destributionId;
            listw.DataContext = _db.Задание.Where(t => t.id_задания == id).ToList();
            UserComboBox.ItemsSource = _db.UsersInTask(id).ToList();
            UserComboBox.DisplayMemberPath = "Логин";
            NoteListBox.ItemsSource = _db.NoteList(DestributionID).ToList();
            //subtaskdatagrid.ItemsSource = _db.SubtaskView(id).ToList();
            subtaskdatagrid.ItemsSource = _db.Подзадача.Where(t => t.id_задания == TaskID).ToList();
            ProgressBarMath(id);
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 1: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));

            //you can cancel the dialog close:
            //eventArgs.Cancel();

            if (!Equals(eventArgs.Parameter, true)) return;

            if (!string.IsNullOrWhiteSpace(NoteTextBox.Text))
            {
                _db.NoteAdd(DestributionID, NoteTextBox.Text);
                NoteListBox.ItemsSource = _db.NoteList(DestributionID).ToList();
            }
            NoteTextBox.Text = "";
        }

        private void NoteListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var note = NoteListBox.SelectedItem as NoteList_Result;
            if (note == null) return;

            int ID = note.id_заметки;

            var deleteNote = _db.Заметка.Where(m => m.id_заметки == ID).Single();
            _db.Заметка.Remove(deleteNote);
            _db.SaveChanges();
            NoteListBox.ItemsSource = _db.NoteList(DestributionID).ToList();
        }

        public void ProgressBarMath(int id)
        {
            //int full = subtaskdatagrid.Items.Count;
            int full = _db.Подзадача.Where(n => n.id_задания == TaskID).Count();
            if (full == 0) { return; }
            pb1.Maximum = full;
            var count = _db.SubtaskView(id).Count(d => d.Статус);
            if (count == full)
            {
                endtaskbutton.IsEnabled = true;
            }
            else endtaskbutton.IsEnabled = false;
            pb1.SetPercent(count);
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskList());
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var subtask = subtaskdatagrid.SelectedItem as Подзадача;
            if (subtask == null) return;

            int id = subtask.id_подзадачи;

            _db.SubtaskComplete(id);
            subtaskdatagrid.Focus();
            ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskReview(TaskID, DestributionID));
            ProgressBarMath(TaskID);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var subtask = subtaskdatagrid.SelectedItem as Подзадача;
            if (subtask == null) return;

            int id = subtask.id_подзадачи;

            _db.SubtaskRollback(id);
            subtaskdatagrid.Focus();
            ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskReview(TaskID, DestributionID));
            ProgressBarMath(TaskID);
        }

        private void subtaskdatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var subtask = subtaskdatagrid.SelectedItem as Подзадача;
                if (subtask == null) return;
                int id = subtask.id_подзадачи;

                var deleteSubtask = _db.Подзадача.Where(m => m.id_подзадачи == id).Single();
                _db.Подзадача.Remove(deleteSubtask);
                _db.SaveChanges();
                //subtaskdatagrid.ItemsSource = _db.SubtaskView(TaskID).ToList();
                //subtaskdatagrid.ItemsSource = _db.Подзадача.Where(t => t.id_задания == TaskID).ToList();
                //ProgressBarMath(TaskID);
                ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskReview(TaskID, DestributionID));
            }
            catch { }
        }

        private void addsubtaskbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subtasktb.Text != "")
                {
                    _db.SubtaskAdd(TaskID, subtasktb.Text);
                    //subtaskdatagrid.ItemsSource = _db.SubtaskView(TaskID).ToList();
                    //subtaskdatagrid.ItemsSource = _db.Подзадача.Where(t => t.id_задания == TaskID).ToList();
                    //ProgressBarMath(TaskID);
                    subtasktb.Text = "";
                    ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskReview(TaskID, DestributionID));
                }
            }
            catch
            {

            }
        }

        private void endtaskbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _db.TaskCompleted(TaskID);
                string status = string.Empty;
                var task = _db.Задание.Where(t => t.id_задания == TaskID).FirstOrDefault();
                if (task.id_статуса == 2)
                {
                    status = "\"Завершено!\"";
                }
                else status = "\"Завершено с опозданием!\"";
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Задание выполнено!",
                    Message = "Ваше задание завершено с статутcом " + status,
                    Type = NotificationType.Success
                });
                foreach (var a in _db.Распределение.Where(n => n.id_задания == TaskID && n.id_пользователя != CurrentUser.Id))
                {
                    Уведомление notif = new Уведомление
                    {
                        Содержание = "Задание " + task.Название + " сдано со статусом " + status + "!",
                        id_пользователя = a.id_пользователя
                    };
                    _db.Уведомление.Add(notif);
                }
                _db.SaveChanges();
                ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskList());
            }
            catch
            {
                var notification = new NotificationManager();
                notification.Show(new NotificationContent
                {
                    Title = "Ошибка!",
                    Message = "Задание не может быть завершено!",
                    Type = NotificationType.Error
                });
              
            }
        }

        private void ganttreportbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var i = _db.Подзадача.Where(u => u.id_задания == TaskID).Where(u => u.Статус == true).Count();

                if (i > 1)
                {
                    StiReport report = new StiReport();
                    report.Load("SubtaskGantt.mrt");
                    report.Compile();
                    report["Variable1"] = TaskID;
                    report.Render();
                    report.ShowWithWpf();
                }
                else MessageBox.Show("Диаграмма не может быть создана с таким количеством заданий!");
            }
            catch { }
            
        }

        private void refreshbutton_Click(object sender, RoutedEventArgs e)
        {
            _db.SaveChanges();
        }
    }

    public static class ProgressBarExtensions
    {
        private static TimeSpan duration = TimeSpan.FromSeconds(0.5);

        public static void SetPercent(this ProgressBar progressBar, double percentage)
        {
            DoubleAnimation animation = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, animation);
        }
    }
}
