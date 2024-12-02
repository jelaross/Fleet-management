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
    public partial class tripdetails : Form
    {
        public tripdetails()
        {
            InitializeComponent();
            textBox3.Text = Program.did;
            
            gettid();
            gettvid();
            textBox8.Text = System.DateTime.Now.ToShortDateString();
        }

        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
       
        public void gettid()
        {
            con.Open();
            string query = "select isnull(MAX(tid),5000)+1 from tripdetails";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            con.Close();

        }
        public void gettvid()
        {
            comboBox1.Items.Clear();
            con.Open();
            string query = "select distinct(vid) from assignvechicle where did='"+Program.did+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tripdetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text==""|| textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox8.Text == "" )
            {
                MessageBox.Show("Fill");
                return;
            }
            string q1 = "insert into tripdetails values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','','','" + textBox4.Text + "','" + textBox8.Text + "','','','','active','')";
            SqlCommand cmd = new SqlCommand(q1, con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Trip Added Successfully");
                textBox1.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
                
                textBox3.Text = "";
                textBox8.Text = "";

           
            }
            con.Close();
            this.Close();
        
        }

    }
}
