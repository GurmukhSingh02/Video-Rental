using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Rental_Gurmukh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCustomers();
            GetMovies();
            GetRental();
        }
        private void GetCustomers()//Showing the customer list
        {
            dataGridViewCustomers.DataSource = Video_Rental_Gurmukh_Static_Functions.Find_All_Customers();
        }
        private void GetMovies()//Showing the movies list
        {
            dataGridViewMovies.DataSource = Video_Rental_Gurmukh_Static_Functions.Find_All_Movies();
        }

        private void GetRental()//Showing the rental list
        {
            dataGridViewRental.DataSource = Video_Rental_Gurmukh_Static_Functions.Get_Pending_Rentals();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//Method is used for add the customer
        {
            if (txtName.Text == "" || txtMobile.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Video_Rental_Gurmukh_Static_Functions.Add_Customer(txtName.Text, txtMobile.Text, txtAddress.Text);
                MessageBox.Show("New Customer Added");
                Dispose();
                GetCustomers();

            }
        }

        private void button5_Click(object sender, EventArgs e)//method is used for edit customer
        {
            Video_Rental_Gurmukh_Static_Functions.Edit_Customer(txtName.Text, txtMobile.Text, txtAddress.Text, lblCustomer.Text);
            MessageBox.Show("Customer Updated");
            Dispose();
            GetCustomers();
        }

        private void button6_Click(object sender, EventArgs e)//method is used for delete customer
        {
            Video_Rental_Gurmukh_Static_Functions.Delete_Customer(lblCustomer.Text);
            MessageBox.Show("Customer Deleted");
            Dispose();
            GetCustomers();
        }

        private void button1_Click(object sender, EventArgs e)//add moovie
        {
            int a, b;

            if (txtMovieName.Text == "" || textPoints.Text == "" || textYear.Text == "" || textCopies.Text == "" || textReleased.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else if (!int.TryParse(textYear.Text, out a) || !(int.TryParse(textCopies.Text, out b)))
            {
                MessageBox.Show("Year and Copies must be a valid integer");
            }
            else
            {
                int rental = 0;
                if ((DateTime.Now.Year - a) > 5)
                {
                    rental = 2;
                }
                else
                {
                    rental = 5;
                }

                Video_Rental_Gurmukh_Static_Functions.Add_Movie(txtMovieName.Text, textPoints.Text, Convert.ToInt32(textYear.Text), Convert.ToInt32(textCopies.Text), textReleased.Text, rental);
                MessageBox.Show("New Movie Added");
            }
        }

        private void btnVideoUpdate_Click(object sender, EventArgs e)//update movie
        {
            int a;
            if (!int.TryParse(textYear.Text, out a))
            {
                MessageBox.Show("Year and Copies must be a valid integer");
            }
            else
            {
                int rental = 0;
                if ((DateTime.Now.Year - a) > 5)
                {
                    rental = 2;
                }
                else
                {
                    rental = 5;
                }
                Video_Rental_Gurmukh_Static_Functions.Edit_Movie(txtMovieName.Text, textPoints.Text, Convert.ToInt32(textYear.Text), Convert.ToInt32(textCopies.Text), textReleased.Text, rental, lblVideo.Text);
                MessageBox.Show("Movie Updated");
                Dispose();
            }
            GetMovies();
        }

        private void btnVideoDelete_Click(object sender, EventArgs e)//delete movie
        {
            Video_Rental_Gurmukh_Static_Functions.Delete_Movie(lblVideo.Text);
            MessageBox.Show("Movie Deleted");
            Dispose();
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dataGridViewCustomers.Rows[e.RowIndex];
                var a = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtMobile.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dataGridViewMovies.Rows[e.RowIndex];
                var a = row.Cells[0].Value.ToString();
                txtMovieName.Text = row.Cells[1].Value.ToString();
                textPoints.Text = row.Cells[2].Value.ToString();
                textYear.Text = row.Cells[3].Value.ToString();
                textCopies.Text = row.Cells[4].Value.ToString();
                textReleased.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataGridViewRental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewRental.Rows[e.RowIndex];
            lblRentalArea.Text = row.Cells[0].Value.ToString();
            comboBox1.SelectedItem = row.Cells[1].Value.ToString();
            comboBox2.SelectedItem = row.Cells[2].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.videosTableAdapter.Fill(this.videoRental_GurmukhDataSet1.Videos);
            this.customersTableAdapter.Fill(this.videoRental_GurmukhDataSet.Customers);

        }

        private void btnMovieIssue_Click(object sender, EventArgs e)
        {
            Video_Rental_Gurmukh_Static_Functions.Add_Rental_Record(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue.ToString()), Convert.ToDateTime(dateTimePicker1.Text));
            MessageBox.Show("Movie Rented");
            GetRental();
        }

        private void btnMovieReturn_Click(object sender, EventArgs e)
        {
            Video_Rental_Gurmukh_Static_Functions.Update_Return_Record(Convert.ToDateTime(DateTime.Now.ToString()), lblRentalArea.Text);
            MessageBox.Show("Movie Returned");
            GetRental();
        }
    }
}
