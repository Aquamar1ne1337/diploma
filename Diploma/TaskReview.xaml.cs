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
            NoteListBox.ItemsSource = _db.NoteList(destributionId).ToList();
            subtaskdatagrid.ItemsSource = _db.SubtaskView(id).ToList();
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
            int full = subtaskdatagrid.Items.Count;
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
            var subtask = subtaskdatagrid.SelectedItem as SubtaskView_Result;
            if (subtask == null) return;

            int id = subtask.id_подзадачи;

            _db.SubtaskComplete(id);
             ProgressBarMath(TaskID);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var subtask = subtaskdatagrid.SelectedItem as SubtaskView_Result;
            if (subtask == null) return;

            int id = subtask.id_подзадачи;

            _db.SubtaskRollback(id);
            ProgressBarMath(TaskID);
        }

        private void subtaskdatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var subtask = subtaskdatagrid.SelectedItem as SubtaskView_Result;
            if (subtask == null) return;
            int id = subtask.id_подзадачи;

            var deleteSubtask = _db.Подзадача.Where(m => m.id_подзадачи == id).Single();
            _db.Подзадача.Remove(deleteSubtask);
            _db.SaveChanges();
            subtaskdatagrid.ItemsSource = _db.SubtaskView(TaskID).ToList();
            ProgressBarMath(TaskID);
        }

        private void addsubtaskbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subtasktb.Text != "")
                {
                    _db.SubtaskAdd(TaskID, subtasktb.Text);
                    subtaskdatagrid.ItemsSource = _db.SubtaskView(TaskID).ToList();
                    ProgressBarMath(TaskID);
                    subtasktb.Text = "";
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
