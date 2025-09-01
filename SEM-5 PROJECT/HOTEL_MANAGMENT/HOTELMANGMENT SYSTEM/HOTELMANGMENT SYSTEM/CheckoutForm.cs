using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HOTELMANGMENT_SYSTEM
{
    public partial class CheckoutForm : Form
    {
        SqlConnection con = new SqlConnection(
@"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=E:\SEM-5 PROJECT\HOTEL_MANAGMENT\HOTELMANGMENT SYSTEM\HOTELMANGMENT SYSTEM\HotelDB.mdf;
      Integrated Security=True;");

        public CheckoutForm()
        {
            InitializeComponent();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Booking WHERE RoomNo=@r", con);
            cmd.Parameters.AddWithValue("@r", txtRoomNo.Text);

            int rows = cmd.ExecuteNonQuery();
            con.Close();

            if (rows > 0)
                MessageBox.Show("Check-out successful!");
            else
                MessageBox.Show("Room not found!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
