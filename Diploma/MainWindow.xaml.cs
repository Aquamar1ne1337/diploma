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
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
