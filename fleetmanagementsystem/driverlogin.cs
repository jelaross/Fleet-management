using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace fleetmanagementsystem
{
    public partial class driverlogin : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public driverlogin(string username_from_login)
        {
            InitializeComponent();
            greeting();
            fillcontent( Program.did );
        }
        public void fillcontent(string id)
        {


            string query = "Select * from driverdetails where did='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                pictureBox1.ImageLocation = Application.StartupPath + dr[6].ToString();

            }
            con.Close();

        }
        public void greeting()
        {
            int hour = DateTime.Now.Hour;
           

            // Determine greeting based on the hour
            if (hour >= 0 && hour < 12)
            {
                label3.Text = "Good Morning " + Program.dname;
            }
            else if (hour >= 12 && hour < 17)
            {
                label3.Text = "Good Afternoon " + Program.dname;
            }
            else
            {
                label3.Text = "Good Evening " + Program.dname;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            driverpasswordchange obj = new driverpasswordchange();

            obj.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {
           tripdetails obj = new tripdetails();

            obj.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            closetrip obj = new closetrip();
            obj.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
