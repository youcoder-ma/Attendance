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
using System.Data.SqlClient;
using System.Data;

namespace AbsenMg
{
    /// <summary>
    /// Interaction logic for Trainer.xaml
    /// </summary>
    public partial class Trainer : Window
    {
        public Trainer()
        {
            InitializeComponent();
        }

        

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void DataGridTr_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataTable dt = stAdp.getCsharpSt();
            DataGridTr.ItemsSource = dt.DefaultView;
        }

        private void DataGridTr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = DataGridTr.SelectedItem as DataRowView;

            try
            {
                if (row.Row["userId"] != null)
                {
                    string Fname = row.Row[2].ToString();
                    string Lname = row.Row[3].ToString();

                    this.SelectedSt.Text = Fname + " " + Lname;
                }

            }
            catch (System.Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.studentsTableAdapter stAdp = new DataSet1TableAdapters.studentsTableAdapter();
            DataSet1TableAdapters.absenceTableAdapter absAdp = new DataSet1TableAdapters.absenceTableAdapter();

            DataRowView row = DataGridTr.SelectedItem as DataRowView;

            string Fname = row.Row[2].ToString();
            string Lname = row.Row[3].ToString();

            int? id = (int?)stAdp.getStId(Fname, Lname);

            if (SelectedSt.Text != string.Empty)
            {
                if(Absent.IsChecked == true)
                {
                    string absDate = datepicker.SelectedDate.Value.Date.ToShortDateString();
                    absAdp.InsertAbs((int) id, absDate);
                    
                    }
                }
            }

        private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string absDate = datepicker.SelectedDate.Value.Date.ToShortDateString();
        }
    }
    }

