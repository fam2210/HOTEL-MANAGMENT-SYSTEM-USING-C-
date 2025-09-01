using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HOTELMANGMENT_SYSTEM
{
    public partial class BookingForm : Form
    {
        // Database connection
        SqlConnection con = new SqlConnection(
       @"Data Source=(LocalDB)\MSSQLLocalDB;
          AttachDbFilename=E:\SEM-5 PROJECT\HOTEL_MANAGMENT\HOTELMANGMENT SYSTEM\HOTELMANGMENT SYSTEM\HotelDB.mdf;
          Integrated Security=True;");

        // Print variables
        private PrintDocument printDoc = new PrintDocument();
        private string printCustomer, printRoom, printCheckIn, printCheckOut;

        public BookingForm()
        {
            InitializeComponent();

            // Attach event for printing
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        // BOOK NOW BUTTON
        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Booking (CustomerName, RoomNo, CheckInDate, CheckOutDate) " +
                    "VALUES (@n, @r, @in, @out)", con);

                cmd.Parameters.AddWithValue("@n", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@r", txtRoomNo.Text);
                cmd.Parameters.AddWithValue("@in", dtCheckIn.Value);
                cmd.Parameters.AddWithValue("@out", dtCheckOut.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Booking successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Prepare data for printing
                printCustomer = txtCustomerName.Text;
                printRoom = txtRoomNo.Text;
                printCheckIn = dtCheckIn.Value.ToString("dd/MM/yyyy");
                printCheckOut = dtCheckOut.Value.ToString("dd/MM/yyyy");

                // Show print preview
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDoc;
                preview.ShowDialog();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Primary Key Violation
                {
                    MessageBox.Show("❌ This Room Number is already booked. Please choose another room.",
                                    "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("⚠️ Database Error: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        // CHECKOUT BUTTON
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            new CheckoutForm().Show();
        }

        // EXIT BUTTON
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // PRINT RECEIPT LOGIC
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font bodyFont = new Font("Segoe UI", 12, FontStyle.Regular);

            float y = 100;

            // Hotel Header
            e.Graphics.DrawString(" Hotel Management System", headerFont, Brushes.Black, 200, y);
            y += 50;

            e.Graphics.DrawString("------ Booking Receipt ------", bodyFont, Brushes.Black, 220, y);
            y += 40;

            // Booking Details
            e.Graphics.DrawString("Customer Name: " + printCustomer, bodyFont, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString("Room Number:   " + printRoom, bodyFont, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString("Check-In Date: " + printCheckIn, bodyFont, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString("Check-Out Date:" + printCheckOut, bodyFont, Brushes.Black, 100, y); y += 50;

            // Footer
            e.Graphics.DrawString("Thank you for booking with us!", bodyFont, Brushes.Black, 100, y);
            y += 30;
            e.Graphics.DrawString("Visit Our Website:https://hotelfantastic.blogspot.com/", bodyFont, Brushes.Black, 200, y);
        }
    }
}
