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
using System.Windows.Shapes;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        DiplomadbEntities _db = new DiplomadbEntities();
        int ID { get; set; }

        public InsertWindow()
        {
            InitializeComponent();
            Registerdp.Text = Getdate();
        }

        public InsertWindow(int ID)
        {
            InitializeComponent();
            Registerdp.Text = Getdate();
            this.ID = ID;
            Readybtn.Content = "Обновить";
            Nametbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Имя;
            Emailtbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Электронная_почта;
            Registerdp.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Дата_регистрации.ToString();
            Phonetbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Телефон;
            Towntbx.Text = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault().Город;

        }

        private void Readybtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    MessageBox.Show("Добавление");
                    _db.ClientAdd(Nametbx.Text, Emailtbx.Text, Registerdp.SelectedDate, Phonetbx.Text, Towntbx.Text);        
                    //MainWindow.datagrid.ItemsSource = _db.Клиент.ToList();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Обновление");
                    //_db.ClientUpdate(Nametbx.Text, Emailtbx.Text, Registerdp.SelectedDate, Phonetbx.Text, Towntbx.Text, ID);
                    var update = _db.Клиент.Where(c => c.id_клиента == ID).FirstOrDefault();
                    update.Имя = Nametbx.Text;
                    update.Электронная_почта = Emailtbx.Text;
                    update.Дата_регистрации = Convert.ToDateTime(Registerdp.SelectedDate).Date;
                    update.Телефон = Phonetbx.Text;
                    update.Город = Towntbx.Text;
                    _db.SaveChanges();
                    //MainWindow.datagrid.ItemsSource = _db.Клиент.ToList();
                    this.Close();
                }
            }
            catch { MessageBox.Show("Данные введены неверно!"); }
        }

        private string Getdate()
        {
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            return date.ToString();
        }
    }
}
