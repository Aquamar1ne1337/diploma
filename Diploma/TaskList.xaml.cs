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
    /// Логика взаимодействия для TaskList.xaml
    /// </summary>
    public partial class TaskList : UserControl
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public TaskList()
        {
            InitializeComponent();
            LilView.ItemsSource = _db.UserTaskList(CurrentUser.Id).ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void insertbtn_Click_1(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).NewTaksWindow(new TaskControl());
        }
    }
}
