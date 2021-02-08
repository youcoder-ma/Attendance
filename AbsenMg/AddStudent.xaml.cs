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

namespace AbsenMg
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void addSt_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            userAdp.addUser(userName.Text, userPass.Text, userType.Text);
            int? id = (int?)userAdp.getUserID(userName.Text);
            stAdp.addStudent(id, FName.Text, LName.Text);

        }
    }
}
