namespace HOTELMANGMENT_SYSTEM
{
    partial class BookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            btnCheckout = new Button();
            textBox1 = new TextBox();
            dtCheckOut = new DateTimePicker();
            label4 = new Label();
            txtRoomNo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnBook = new Button();
            dtCheckIn = new DateTimePicker();
            txtCustomerName = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnCheckout);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(dtCheckOut);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtRoomNo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBook);
            panel1.Controls.Add(dtCheckIn);
            panel1.Controls.Add(txtCustomerName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(537, 558);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(139, 488);
            button1.Name = "button1";
            button1.Size = new Size(251, 51);
            button1.TabIndex = 19;
            button1.Text = "EXIT PROGRAM";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(284, 430);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(188, 52);
            btnCheckout.TabIndex = 1;
            btnCheckout.Text = "CHECKOUT";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(54, 36);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(418, 37);
            textBox1.TabIndex = 18;
            textBox1.TabStop = false;
            textBox1.Text = "ROOM BOOK NOW";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // dtCheckOut
            // 
            dtCheckOut.Format = DateTimePickerFormat.Short;
            dtCheckOut.Location = new Point(258, 378);
            dtCheckOut.Name = "dtCheckOut";
            dtCheckOut.Size = new Size(214, 37);
            dtCheckOut.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(54, 378);
            label4.Name = "label4";
            label4.Size = new Size(129, 28);
            label4.TabIndex = 16;
            label4.Text = "CHECK-OUT:";
            // 
            // txtRoomNo
            // 
            txtRoomNo.Location = new Point(258, 178);
            txtRoomNo.Name = "txtRoomNo";
            txtRoomNo.PlaceholderText = "ROOM NO";
            txtRoomNo.Size = new Size(214, 37);
            txtRoomNo.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(54, 290);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 14;
            label3.Text = "CHECK-IN:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(54, 178);
            label2.Name = "label2";
            label2.Size = new Size(116, 28);
            label2.TabIndex = 13;
            label2.Text = "ROOM NO:";
            // 
            // btnBook
            // 
            btnBook.Location = new Point(54, 430);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(214, 52);
            btnBook.TabIndex = 12;
            btnBook.Text = "BOOK NOW";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += btnBook_Click;
            // 
            // dtCheckIn
            // 
            dtCheckIn.Format = DateTimePickerFormat.Short;
            dtCheckIn.Location = new Point(258, 290);
            dtCheckIn.Name = "dtCheckIn";
            dtCheckIn.Size = new Size(214, 37);
            dtCheckIn.TabIndex = 11;
            dtCheckIn.Value = new DateTime(2025, 8, 27, 6, 6, 0, 0);
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(258, 95);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "CUSTOMER NAME";
            txtCustomerName.Size = new Size(214, 37);
            txtCustomerName.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(54, 95);
            label1.Name = "label1";
            label1.Size = new Size(189, 28);
            label1.TabIndex = 9;
            label1.Text = "CUSTOMER NAME:";
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ChatGPT_Image_Aug_31__2025__11_21_40_AM;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(567, 583);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookingForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DateTimePicker dtCheckOut;
        private Label label4;
        private TextBox txtRoomNo;
        private Label label3;
        private Label label2;
        private Button btnBook;
        private DateTimePicker dtCheckIn;
        private TextBox txtCustomerName;
        private Label label1;
        private TextBox textBox1;
        private Button btnCheckout;
        private Button button1;
    }
}