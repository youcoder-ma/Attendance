using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AbsenMg
{
    /// <summary>
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // Design functionality
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (oma.Visibility == Visibility.Collapsed)
            {
                if (oma1.Visibility == Visibility.Visible)
                    oma1.Visibility = Visibility.Collapsed;
                else if (oma2.Visibility == Visibility.Visible)
                    oma2.Visibility = Visibility.Collapsed;
                oma.Visibility = Visibility.Visible;
            }

            else
                oma.Visibility = Visibility.Collapsed;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (oma1.Visibility == Visibility.Collapsed)
            {
                if (oma.Visibility == Visibility.Visible)
                    oma.Visibility = Visibility.Collapsed;
                else if (oma2.Visibility == Visibility.Visible)
                    oma2.Visibility = Visibility.Collapsed;
                oma1.Visibility = Visibility.Visible;
            }
            else
                oma1.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (oma2.Visibility == Visibility.Collapsed)
            {
                if (oma.Visibility == Visibility.Visible)
                    oma.Visibility = Visibility.Collapsed;
                else if (oma1.Visibility == Visibility.Visible)
                    oma1.Visibility = Visibility.Collapsed;
                oma2.Visibility = Visibility.Visible;
            }
            else
                oma2.Visibility = Visibility.Collapsed;
        }

        public void updateCsRecords()
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.getCsharpSt();
            DataG1.ItemsSource = dt.DefaultView;
        }

        public void updateFBRecords()
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.GetFEBESt();
            this.DataG2.ItemsSource = dt.DefaultView;
        }

        public void updateJee()
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.GetJeeSt();
            DataG3.ItemsSource = dt.DefaultView;
        }

        public void updateTr()
        {
            DataSet1TableAdapters.trainersTableAdapter trAdp = new DataSet1TableAdapters.trainersTableAdapter();
            DataTable dt = trAdp.GetTrainers();
            this.dataGrid.ItemsSource = dt.DefaultView;
        }

        public void updateSec()
        {
            DataSet1TableAdapters.secretariesTableAdapter secAdp = new DataSet1TableAdapters.secretariesTableAdapter();
            DataTable dt = secAdp.getSecretaries();
            this.dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void button_Click_3(object sender, RoutedEventArgs e)
        {
            this.userName.Text = string.Empty;
            this.userPass.Text = string.Empty;
            this.FName.Text = string.Empty;
            this.LName.Text = string.Empty;
            this.Class.Text = string.Empty;
        }
        //Student section
        //Load Student DataGrids

        private void DataG1_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.getCsharpSt();
            DataG1.ItemsSource = dt.DefaultView;
        }


        private void DataG2_Loaded(object sender, RoutedEventArgs e)
        {

            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.GetFEBESt();
            this.DataG2.ItemsSource = dt.DefaultView;

        }


        private void DataG3_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.GetJeeSt();
            DataG3.ItemsSource = dt.DefaultView;
        }

        //Student DG selectionChanged

        private void DataG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();




            DataRowView row = DataG1.SelectedItem as DataRowView;

            try
            {
                if (row.Row["userId"] != null)
                {

                    int oo = int.Parse(row.Row["userId"].ToString());

                    DataTable dt = userAdp.GetStLoginByID(oo);

                    this.userName.Text = dt.Rows[0]["userName"].ToString();
                    this.userPass.Text = dt.Rows[0]["userPass"].ToString();
                    this.FName.Text = row.Row[2].ToString();

                    this.LName.Text = row.Row[3].ToString();
                    this.Class.Text = row.Row[4].ToString();
                }
            }
            catch (System.Exception)
            {


            }

        }

        private void DataG2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();

            DataRowView row = DataG2.SelectedItem as DataRowView;


            try
            {
                if (row.Row["userId"] != null)
                {
                    int oo = int.Parse(row.Row["userId"].ToString());

                    DataTable dt = userAdp.GetStLoginByID(oo);

                    this.userName.Text = dt.Rows[0]["userName"].ToString();
                    this.userPass.Text = dt.Rows[0]["userPass"].ToString();
                    this.FName.Text = row.Row[2].ToString();

                    this.LName.Text = row.Row[3].ToString();
                    this.Class.Text = row.Row[4].ToString();
                }
            }
            catch (System.Exception)
            {

            }

        }

        private void DataG3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();

            DataRowView row = DataG3.SelectedItem as DataRowView;

            try
            {
                if (row.Row["userId"] != null)
                {
                    int oo = int.Parse(row.Row["userId"].ToString());

                    DataTable dt = userAdp.GetStLoginByID(oo);

                    this.userName.Text = dt.Rows[0]["userName"].ToString();
                    this.userPass.Text = dt.Rows[0]["userPass"].ToString();
                    this.FName.Text = row.Row[2].ToString();

                    this.LName.Text = row.Row[3].ToString();
                    this.Class.Text = row.Row[4].ToString();
                }
            }
            catch (System.Exception)
            {

            }
        }

        //Implemented Buttons
        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Text == string.Empty || userPass.Text == string.Empty || FName.Text == string.Empty || LName.Text == string.Empty || Class.Text == string.Empty)
            {
                MessageBox.Show("Something missing, please retry");
                return;
            }
            else
            {
                DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();
                DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
                userAdp.addUser(userName.Text, userPass.Text, "student");
                int? id = (int?)userAdp.getUserID(userName.Text);
                stAdp.AddStudent(id, FName.Text, LName.Text, Class.Text);
                MessageBox.Show("Added successfully");
            }
            updateCsRecords();
            updateFBRecords();
            updateJee();
        }


        private void deleteStudent_Click_1(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdo = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            int? id = (int?)userAdo.getUserID(userName.Text);
            stAdp.DeleteStudent(id);
            userAdo.DeleteUser((int)id);
            MessageBox.Show("Deleted successfully");
            updateCsRecords();
            updateFBRecords();
            updateJee();
        }

        private void editStudent_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdo = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            int? id = (int?)userAdo.getUserID(userName.Text);
            stAdp.UpdateStudent(FName.Text, LName.Text, Class.Text, (int)id);
            MessageBox.Show("modified successfully");
            updateCsRecords();
            updateFBRecords();
            updateJee();
        }


        //Trainer section
        //Load Trainer DataGrid

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.trainersTableAdapter trAdp = new DataSet1TableAdapters.trainersTableAdapter();
            DataTable dt = trAdp.GetTrainers();
            this.dataGrid.ItemsSource = dt.DefaultView;
        }

        //Trainer DG selectionChanged

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();

            DataRowView row = dataGrid.SelectedItem as DataRowView;

            try
            {
                if (row.Row["userId"] != null)
                {
                    int oo = int.Parse(row.Row["userId"].ToString());

                    DataTable dt = userAdp.GetTLoginById(oo);

                    this.userName.Text = dt.Rows[0]["userName"].ToString();
                    this.userPass.Text = dt.Rows[0]["userPass"].ToString();
                    this.FName.Text = row.Row[2].ToString();

                    this.LName.Text = row.Row[3].ToString();
                    this.Class.Text = row.Row[4].ToString();
                }
            }
            catch (System.Exception)
            {

            }

            
        }

        //Implemented Buttons

        private void addTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Text == string.Empty || userPass.Text == string.Empty || FName.Text == string.Empty || LName.Text == string.Empty || Class.Text == string.Empty)
            {
                MessageBox.Show("Something missing, please retry");
                return;
            }
            else
            {
                DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();
                DataSet1TableAdapters.trainersTableAdapter trAdp = new DataSet1TableAdapters.trainersTableAdapter();
                userAdp.addUser(userName.Text, userPass.Text, "trainer");
                int? id = (int?)userAdp.getUserID(userName.Text);
                trAdp.addTrainer(id, FName.Text, LName.Text, Class.Text);
                MessageBox.Show("Added successfully");
            }
            updateTr();

        }



        private void deleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdo = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.trainersTableAdapter traAdp = new DataSet1TableAdapters.trainersTableAdapter();
            int? id = (int?)userAdo.getUserID(userName.Text);
            traAdp.DeleteTrainer(id);
            userAdo.DeleteUser((int)id);
            MessageBox.Show("Deleted successfully");
            updateTr();
        }

        private void editTeacher_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdo = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.trainersTableAdapter traAdp = new DataSet1TableAdapters.trainersTableAdapter();
            int? id = (int?)userAdo.getUserID(userName.Text);
            traAdp.UpdateTrainer(FName.Text, LName.Text, Class.Text, (int)id);
            MessageBox.Show("modified successfully");
            updateTr();
        }



        //Secretary Section
        //Load

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.secretariesTableAdapter secAdp = new DataSet1TableAdapters.secretariesTableAdapter();
            DataTable dt = secAdp.getSecretaries();
            this.dataGrid1.ItemsSource = dt.DefaultView;
        }

        //Selection Changed Event
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();

            DataRowView row = dataGrid1.SelectedItem as DataRowView;

            try
            {
                if (row.Row["userId"] != null)
                {
                    int oo = int.Parse(row.Row["userId"].ToString());

                    DataTable dt = userAdp.GetSecLoginId(oo);

                    this.userName.Text = dt.Rows[0]["userName"].ToString();
                    this.userPass.Text = dt.Rows[0]["userPass"].ToString();
                    this.FName.Text = row.Row[2].ToString();

                    this.LName.Text = row.Row[3].ToString();
                }
            }
            catch (System.Exception)
            {

            }

        }

        //Implemented buttons

        private void addSecretary_Click_1(object sender, RoutedEventArgs e)
        {
            if (userName.Text == string.Empty || userPass.Text == string.Empty || FName.Text == string.Empty || LName.Text == string.Empty)
            {
                MessageBox.Show("Something missing, please retry");
                return;
            }
            else
            {
                DataSet1TableAdapters.usersTableAdapter userAdp = new DataSet1TableAdapters.usersTableAdapter();
                DataSet1TableAdapters.secretariesTableAdapter secAdp = new DataSet1TableAdapters.secretariesTableAdapter();
                userAdp.addUser(userName.Text, userPass.Text, "secretary");
                int? id = (int?)userAdp.getUserID(userName.Text);
                secAdp.addSecretary(id, FName.Text, LName.Text);
                MessageBox.Show("Added successfully");
            }
            updateSec();
        }

        
        private void deleteSecretary_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdo = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.secretariesTableAdapter secAdp = new DataSet1TableAdapters.secretariesTableAdapter();
            int? id = (int?)userAdo.getUserID(userName.Text);
            secAdp.DeleteSec(id);
            userAdo.DeleteUser((int)id);
            MessageBox.Show("Deleted successfully");
            updateSec();
        }

        

        private void editSecretary_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.usersTableAdapter userAdo = new DataSet1TableAdapters.usersTableAdapter();
            DataSet1TableAdapters.secretariesTableAdapter secAdp = new DataSet1TableAdapters.secretariesTableAdapter();
            int? id = (int?)userAdo.getUserID(userName.Text);
            secAdp.UpdateSec(FName.Text, LName.Text, (int)id);
            MessageBox.Show("modified successfully");
            updateSec();
        }


    }
}   