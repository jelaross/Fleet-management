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
    public partial class closetrip : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public closetrip()
        {
            InitializeComponent();
            gettid();
            getvid();
        }
        public void gettid()
        {
            con.Open();
            string query = "select distinct(tid) from tripdetails where did='"+Program.did+"' and status='active'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();

        }
        public void getvid()
        {
            con.Open();
            string query = "select * from tripdetails where starting_reading = '" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[3].ToString();
            }
            con.Close();

        }
        private void closetrip_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"update  tripdetails 
	            set end_reading=@endreading,kilometers=@kilo,enddate=@enddate,toll=@toll,Fare=@fare,status='close',total=@total 
	            where tid=@tid";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@endreading", textBox4.Text);
            cmd.Parameters.AddWithValue("@kilo", textBox5.Text);
            cmd.Parameters.AddWithValue("@enddate", dateTimePicker1.Value.ToString("yyyy-mm-dd"));
            cmd.Parameters.AddWithValue("@toll", textBox6.Text);
            cmd.Parameters.AddWithValue("@fare", textBox2.Text);
            cmd.Parameters.AddWithValue("@total", label13.Text);
            cmd.Parameters.AddWithValue("@tid", comboBox1.Text);
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Trip Closed Successfully");
            this.Close();
         //  comboBox1.Text = "";
          // textBox4.Text="";
           //textBox1.Text = "";
           //textBox8.Text = "";
          // textBox5.Text = "";
           //textBox9.Text = "";
           //textBox3.Text = "";
           //textBox6.Text = "";
          // t/extBox2.Text = "";
           //label13.Text = "";
            //string query = "UPDATE tripdetails SET end_reading='" + textBox4.Text + "', kilometers='" + textBox5.Text + "',enddate='" + dateTimePicker1.Value.ToString("yyyy-mm-dd") + "',Toll='" + textBox6.Text + "',total='" + label13.Text + "',status='close' WHERE did='" + Program.did + "'";
            //con.Open();
            //SqlCommand cmd = new SqlCommand(query, con);
            //con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select * from tripdetails where tid='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[3].ToString();
                textBox8.Text = dr[7].ToString();

            }

            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Display the difference in textBox5

        // Check if the value in textBox4 is less than the value in textBox1
       
         }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            DateTime secondate = dateTimePicker1.Value;
            DateTime firstdate = Convert.ToDateTime(textBox8.Text);
            TimeSpan dt = secondate - firstdate;
            textBox9.Text = dt.Days.ToString();

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                textBox5.Text = ""; // Clear textBox5 if either is empty
                return; // Exit if either textBox is empty
            }

            // Try to parse the values of textBox1 and textBox4
            decimal value1 = Convert.ToDecimal(textBox4.Text);
            decimal value4 = Convert.ToDecimal(textBox1.Text);
            // Calculate the difference
            decimal difference = value1 - value4;

            textBox5.Text = difference.ToString();
            if (dt.Days == 0)
            {
                textBox9.Text = "1";
                textBox3.Text = Convert.ToString(Convert.ToDecimal(textBox9.Text) * Convert.ToDecimal(Program.bata));
            }
            else
            {
                textBox3.Text = Convert.ToString(Convert.ToDecimal(textBox9.Text) * Convert.ToDecimal(Program.bata));
            }
            if (Convert.ToDecimal(textBox5.Text) > 0)
            {
                textBox2.Text = Convert.ToString(Convert.ToDecimal(textBox5.Text) * Convert.ToDecimal(Program.fare));
            }


            label13.Text = Convert.ToString(Convert.ToDecimal(textBox6.Text) + Convert.ToDecimal(textBox2.Text) + Convert.ToDecimal(textBox3.Text));
        }
    }
}
