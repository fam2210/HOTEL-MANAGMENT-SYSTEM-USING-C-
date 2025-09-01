using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTELMANGMENT_SYSTEM
{
    public partial class FoodOrderForm : Form
    {
        SqlConnection con = new SqlConnection(
@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=E:\SEM-5 PROJECT\HOTEL_MANAGMENT\HOTELMANGMENT SYSTEM\HOTELMANGMENT SYSTEM\HotelDB.mdf;
Integrated Security=True;");

        Dictionary<string, decimal> foodMenu = new Dictionary<string, decimal>
        {
            {"Pizza", 250.00m},
            {"Burger", 150.00m},
            {"Pasta", 200.00m},
            {"Coffee", 80.00m},
            {"Tea", 50.00m},
            {"Juice", 120.00m}
        };

        decimal totalPrice = 0;
        public FoodOrderForm()
        {
            InitializeComponent();
        }

        private void FoodOrderForm_Load(object sender, EventArgs e)
        {
            dgvRooms.Rows.Clear();
            lvFoodMenu.Items.Clear();
            lstCart.Items.Clear();
            txtTotalPrice.Text = "0.00";
        }
        private void LoadRoomNumbers()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT RoomNo, CustomerName FROM Booking", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgvRooms.Rows.Add(dr["RoomNo"], dr["CustomerName"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
        }

        private void LoadFoodMenu()
        {
            lvFoodMenu.Items.Clear();
            foreach (var item in foodMenu)
            {
                ListViewItem lvi = new ListViewItem(item.Key);
                lvi.SubItems.Add(item.Value.ToString("0.00"));
                lvFoodMenu.Items.Add(lvi);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (lvFoodMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a food item.");
                return;
            }

            string foodItem = lvFoodMenu.SelectedItems[0].Text;
            decimal price = foodMenu[foodItem];
            int quantity = (int)numQuantity.Value;
            decimal itemTotal = price * quantity;

            lstCart.Items.Add($"{foodItem} x {quantity} = ₹{itemTotal}");
            totalPrice += itemTotal;
            txtTotalPrice.Text = totalPrice.ToString("0.00");
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room.");
                return;
            }

            string roomNo = dgvRooms.SelectedRows[0].Cells[0].Value.ToString();
            string customerName = dgvRooms.SelectedRows[0].Cells[1].Value.ToString();

            try
            {
                con.Open();
                foreach (var item in lstCart.Items)
                {
                    string[] parts = item.ToString().Split(new char[] { 'x', '=' });
                    if (parts.Length < 3) continue;

                    string foodItem = parts[0].Trim();
                    int quantity = int.Parse(parts[1].Trim());
                    decimal price = foodMenu[foodItem] * quantity;

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO FoodOrder (CustomerName, FoodItem, Quantity, Price) VALUES (@name, @food, @qty, @price)", con);
                    cmd.Parameters.AddWithValue("@name", customerName);
                    cmd.Parameters.AddWithValue("@food", foodItem);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                MessageBox.Show("Order placed successfully!");
                lstCart.Items.Clear();
                txtTotalPrice.Text = "0.00";
                totalPrice = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
            }

        }

        private void btnLoadRooms_Click(object sender, EventArgs e)
        {
            LoadRoomNumbers();
        }

        private void btnLoadFoodMenu_Click(object sender, EventArgs e)
        {
            LoadFoodMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
