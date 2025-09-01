using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HOTELMANGMENT_SYSTEM
{
    public partial class StaffReviewForm : Form
    {
        SqlConnection con = new SqlConnection(
   @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=E:\SEM-5 PROJECT\HOTEL_MANAGMENT\HOTELMANGMENT SYSTEM\HOTELMANGMENT SYSTEM\HotelDB.mdf;
      Integrated Security=True;");
        public StaffReviewForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO StaffReview (StaffName, Rating, Comments) VALUES (@s, @r, @c)", con);
            cmd.Parameters.AddWithValue("@s", txtStaffName.Text);
            cmd.Parameters.AddWithValue("@r", cmbRating.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@c", txtComments.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Review submitted!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
