using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace fleetmanagementsystem
{
    public partial class persondeatilsdriver : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public persondeatilsdriver()
        {
            InitializeComponent();
        }
        public persondeatilsdriver(string id)
        {
            InitializeComponent();
            fillcontent(id);
            filltrips(id);
            fillkilometers(id);
            fillrevenue(id);
           
        }
        public void fillrevenue(string id)
        {
            con.Open();
            string query = "SELECT SUM(CAST(total AS INT)) AS Revenue FROM tripdetails WHERE ISNUMERIC(total) = 1 and did='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                label16.Text = dr[0].ToString();
            }
            con.Close();
        }
        public void filltrips(string id)
        {
  con.Open();
 string query="select count(tid) from tripdetails where did='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                label7.Text = dr[0].ToString();
            }
            con.Close();
        }
        public void fillkilometers(string id)
        {
            con.Open();
            string query = "SELECT SUM(CAST(kilometers AS INT)) AS TotalKilometers FROM tripdetails WHERE ISNUMERIC(kilometers) = 1 and did='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                label14.Text = dr[0].ToString();
            }
            con.Close();
        }
        public void fillcontent(string id)
        {
            textBox1.Text = id;

            string query = "Select * from driverdetails where did='"+id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();

                textBox6.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                textBox4.Text = dr[5].ToString();
                pictureBox1.ImageLocation = Application.StartupPath + dr[6].ToString();

            }
            con.Close();
 
        }

        private void persondeatilsdriver_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatedetails obj = new updatedetails(textBox1.Text);
            ActiveForm.Hide();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
