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
using System.Data;

namespace AbsenMg
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();
            DataTable dt = userAdp.GetDataByLogin(userName.Text, userPass.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["userType"].Equals("admin"))
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();
                    admin.Closed += (s, args) => this.Close();
                    admin.Show();

                }
                else if (dt.Rows[0]["userType"].Equals("student"))
                {
                    Student student = new Student();
                    student.Show();
                    this.Hide();
                    student.Closed += (s, args) => this.Close();
                    student.Show();
                }
                else if (dt.Rows[0]["userType"].Equals("trainer"))
                {
                    Trainer trainer = new Trainer();
                    trainer.Show();
                    this.Hide();
                    trainer.Closed += (s, args) => this.Close();
                    trainer.Show();
                }
                else
                {
                    Secretary secretary = new Secretary();
                    secretary.Show();
                    this.Hide();
                    secretary.Closed += (s, args) => this.Close();
                    secretary.Show();
                }
            }
            else
            {
                MessageBox.Show("Some or all of your entries are incorrect, try again");
                return;
            }
        }


        }
    }
