﻿using System;
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
