using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public Window1()
        {
            InitializeComponent();
            UserTreeView.DataContext = _db.UsersInTask(9).ToList();

        }

      
        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = sender as Button;
        //    if (button == null) return;

        //    var note = button.DataContext as NoteList_Result;
        //    int ID = note.id_заметки;

        //    var deleteNote = _db.Заметка.Where(m => m.id_заметки == ID).Single();
        //    _db.Заметка.Remove(deleteNote);
        //    _db.SaveChanges();
        //    NoteListBox.ItemsSource = _db.NoteList(3).ToList();
        //}

    }
}
