using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LilView.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            return ((item as UserTaskList_Result).Название.IndexOf(SearchTB.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LilView.ItemsSource).Refresh();
        }

        private void insertbtn_Click_1(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskControl());
        }

        private void ReviewBT_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var task = button.DataContext as UserTaskList_Result;
            int ID = task.id_задания;
            int destributionId = task.id_распределения;

            ((MainWindow)Window.GetWindow(this)).NewTaskWindow(new TaskReview(ID, destributionId));
        }

        private void alltasktogglebutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleSort_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleSort.IsChecked == true)
            {
                CollectionViewSource.GetDefaultView(LilView.ItemsSource).SortDescriptions.Add(new SortDescription("Состояние", ListSortDirection.Descending)); 
            }
            else
            {
                CollectionViewSource.GetDefaultView(LilView.ItemsSource).SortDescriptions.Clear();
            }
        }
    }
}
