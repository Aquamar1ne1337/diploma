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

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для TaskReview.xaml
    /// </summary>
    public partial class TaskReview : UserControl
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public int DestributionID { get; set; }
        public TaskReview(int id, int destributionId)
        {
            InitializeComponent();
            DestributionID = destributionId;
            listw.DataContext = _db.Задание.Where(t => t.id_задания == id).ToList();
            UserComboBox.ItemsSource = _db.UsersInTask(id).ToList();
            UserComboBox.DisplayMemberPath = "Логин";
            NoteListBox.ItemsSource = _db.NoteList(destributionId).ToList();
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
    }
}
