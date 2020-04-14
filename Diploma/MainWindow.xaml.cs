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
            LilView.ItemsSource = _db.Клиент.ToList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LilView.ItemsSource);
            //view.Filter = UserFilter;
        }
        //private bool UserFilter(object item)
        //{
        //    return ((item as Клиент).Имя.IndexOf(todo.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var client = button.DataContext as Клиент;
            int ID = client.id_клиента;
            
            var deleteClient = _db.Клиент.Where(m => m.id_клиента == ID).Single();
            _db.Клиент.Remove(deleteClient);
            _db.SaveChanges();
            LilView.ItemsSource = _db.Клиент.ToList();
        }

        private void insertbtn_Click_1(object sender, RoutedEventArgs e)
        {
            InsertWindow obj = new InsertWindow();
            obj.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var client = button.DataContext as Клиент;
            int ID = client.id_клиента;

            InsertWindow obj = new InsertWindow(ID);
            obj.ShowDialog();
        }

        private void updateallbtn_Click(object sender, RoutedEventArgs e)
        {
            LilView.ItemsSource = _db.Клиент.ToList();
        }
    }
}
