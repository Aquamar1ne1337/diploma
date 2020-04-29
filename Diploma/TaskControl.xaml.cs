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
    /// Логика взаимодействия для TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        public TaskControl()
        {
            InitializeComponent();
            ClientCB.ItemsSource = _db.Клиент.ToList();
            ClientCB.DisplayMemberPath = "Имя";
        }

        private void DoneBT_Click(object sender, RoutedEventArgs e)
        {
           
            if (DeadlineDP.SelectedDate < DateTime.Now.Date)
            {
                MessageBox.Show("NO");
            }
            else { MessageBox.Show("Yes"); }
        }
    }
}
