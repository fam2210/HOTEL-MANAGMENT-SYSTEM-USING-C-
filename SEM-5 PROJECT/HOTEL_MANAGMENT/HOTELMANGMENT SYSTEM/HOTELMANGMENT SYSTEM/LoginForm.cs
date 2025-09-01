using HOTELMANGMENT_SYSTEM;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HOTELMANGMENT_SYSTEM
{
    public partial class LoginForm : Form
    {

        // Property accessible from MainForm
        public static string LoggedInRole { get; private set; }
        // Use |DataDirectory| so you don’t hardcode the path
        SqlConnection con = new SqlConnection(
   @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\SEM-5 PROJECT\HOTEL_MANAGMENT\HOTELMANGMENT SYSTEM\HOTELMANGMENT SYSTEM\HotelDB.mdf; Integrated Security=True;");

        public LoginForm()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Users 
                             WHERE Username = @u AND Password = @p AND Role = @r";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        cmd.Parameters.AddWithValue("@r", role);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // ✅ Login successful from DB
                            LoggedInRole = role;

                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close(); // Close login form → MainForm will apply role permissions
                            return;
                        }
                    }
                }

                // ✅ Fallback: Hardcoded credentials
                if (username == "admin" && password == "Admin@123" && role == "Admin")
                {
                    LoggedInRole = "Admin";
                    this.Close();
                }
                else if (username == "reception" && password == "Reception@123" && role == "Reception")
                {
                    LoggedInRole = "Reception";
                    this.Close();
                }
                else if (username == "customer" && password == "Customer@123" && role == "Customer")
                {
                    LoggedInRole = "Customer";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username, password, or role!", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = cmbRole.Text.Trim();

           

            if (role == "Customer")
            {
                MessageBox.Show("👉 Default Credentials for Customer:\nUsername: customer\nPassword: Customer@123",
                                "Role Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

    
