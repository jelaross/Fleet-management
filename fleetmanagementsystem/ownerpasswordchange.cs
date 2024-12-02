using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace fleetmanagementsystem
{
    public partial class ownerpasswordchange : Form
    {
        // Establish a connection to the database
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true;");

        // Assuming this is the driver ID (for example, you may retrieve this from the session)
        private string driverId = Program.username; // Replace with actual logic to get the logged-in driver ID

        public ownerpasswordchange()
        {
            InitializeComponent();
        }

        private void driverpasswordchange_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Step 1: Validate user input
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string oldPassword = textBox1.Text;  // Old password
            string newPassword = textBox2.Text;  // New password
            string confirmPassword = textBox3.Text; // Confirm new password

            // Step 2: Check if new password and confirm password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match!");
                return;
            }

            try
            {
                // Step 3: Open the database connection
                con.Open();

                // Step 4: Retrieve the current (old) password from the logindetails table for the logged-in driver
                string selectQuery = "SELECT Password FROM logindetails WHERE username = @DriverId";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                selectCmd.Parameters.AddWithValue("@DriverId", driverId);
                object result = selectCmd.ExecuteScalar();

                if (result != null)
                {
                    string storedPassword = result.ToString();

                    // Step 5: Check if the old password entered by the user matches the stored password
                    if (storedPassword == oldPassword)
                    {
                        // Step 6: If old password is correct, update the password in the logindetails table
                        string updateQuery = "UPDATE logindetails SET Password = @NewPassword WHERE username= @DriverId";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        updateCmd.Parameters.AddWithValue("@DriverId", driverId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password changed successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Password Change Failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old Password is Incorrect.");
                    }
                }
                else
                {
                    MessageBox.Show("Driver Not Found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.InnerException.ToString());
            }
            finally
            {
                // Step 7: Close the connection
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        // Other event handlers (if needed)
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void driverpasswordchange_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ownerpasswordchange_Load(object sender, EventArgs e)
        {

        }
    }
}
