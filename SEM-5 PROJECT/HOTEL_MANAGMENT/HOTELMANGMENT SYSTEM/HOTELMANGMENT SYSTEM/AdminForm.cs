using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace HOTELMANGMENT_SYSTEM
{
    public partial class AdminForm : Form
    {
        SqlConnection con = new SqlConnection(
@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=E:\SEM-5 PROJECT\HOTEL_MANAGMENT\HOTELMANGMENT SYSTEM\HOTELMANGMENT SYSTEM\HotelDB.mdf;
Integrated Security=True;");

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadAllTables();
            Timer timer = new Timer();
            timer.Interval = 10000; // 10 seconds
            timer.Tick += (s, ev) => LoadAllTables();
            timer.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllTables();
        }

        private void LoadAllTables()
        {
            try
            {
                con.Open();

                // Load Users
                SqlDataAdapter daUsers = new SqlDataAdapter("SELECT * FROM Users", con);
                DataTable dtUsers = new DataTable();
                daUsers.Fill(dtUsers);
                dgvUsers.DataSource = dtUsers;

                // Load Bookings
                SqlDataAdapter daBookings = new SqlDataAdapter("SELECT * FROM Booking", con);
                DataTable dtBookings = new DataTable();
                daBookings.Fill(dtBookings);
                dgvBookings.DataSource = dtBookings;

                // Load Food Orders
                SqlDataAdapter daFood = new SqlDataAdapter("SELECT * FROM FoodOrder", con);
                DataTable dtFood = new DataTable();
                daFood.Fill(dtFood);
                dgvFoodOrders.DataSource = dtFood;

                // 🔹 Count Pending Food Orders
                SqlCommand cmdPending = new SqlCommand("SELECT COUNT(*) FROM FoodOrder WHERE Status = 'Pending'", con);
                int pendingCount = (int)cmdPending.ExecuteScalar();
                lblNotification.Text = $"🔔 Pending Food Orders: {pendingCount}";

                // Load Staff Reviews
                SqlDataAdapter daReviews = new SqlDataAdapter("SELECT * FROM StaffReview", con);
                DataTable dtReviews = new DataTable();
                daReviews.Fill(dtReviews);
                dgvStaffReviews.DataSource = dtReviews;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if user has selected a row

            if (dgvFoodOrders.SelectedRows.Count > 0)
            {
                // Get CustomerName from selected row (make sure column name matches DB)
                string customerName = dgvFoodOrders.SelectedRows[0].Cells["CustomerName"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this food order for " + customerName + "?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM FoodOrder WHERE CustomerName = @name", con))
                    {
                        cmd.Parameters.AddWithValue("@name", customerName);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }


                }
            }
            else
            {
                MessageBox.Show("Please select an order to delete.");
            }
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvFoodOrders.SelectedRows.Count > 0)
            {
                string customerName = dgvFoodOrders.SelectedRows[0].Cells["CustomerName"].Value.ToString();

                using (SqlCommand cmd = new SqlCommand("UPDATE FoodOrder SET Status = 'Completed' WHERE CustomerName = @name", con))
                {
                    cmd.Parameters.AddWithValue("@name", customerName);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                LoadAllTables();
                MessageBox.Show("Order for " + customerName + " marked as Completed!");
            }
            else
            {
                MessageBox.Show("Please select an order to complete.");
            }
        }
    }
}
