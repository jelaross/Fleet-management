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
using System.IO;
namespace fleetmanagementsystem
{
    public partial class assign_vechicles : Form
    {

        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public assign_vechicles()
        {
            InitializeComponent();
            fillcombo1();
            fillcombo();
        }
        public void fillcombo()
        {
            string query = "Select did from driverdetails";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            con.Close();
        }
        private void assign_vechicles_Load(object sender, EventArgs e)
        {

        }
        public void fillcombo1()
        {
            string query = "Select vid from vehiclesdetails";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());

            }
            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select * from driverdetails where did='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                pictureBox1.Image = Image.FromFile("E:/fleet project/fleetmanagementsystem/bin/Debug" + dr[6].ToString());
              
            
            }

            con.Close();
        
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string query = "Select * from vehiclesdetails where vid='" + comboBox2.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr[3].ToString();
                pictureBox2.Image = Image.FromFile("E:/fleet project/fleetmanagementsystem/bin/Debug" + dr[4].ToString());
            }

            con.Close();
        }                                                       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == ""  || comboBox1.Text == "" || comboBox2.Text == ""  )
            {
                MessageBox.Show("Fill");
                return;
            }



            string q1 = "insert into assignvechicle values('" + comboBox1.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "')";
            SqlCommand cmd = new SqlCommand(q1, con);
            con.Open();

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show(" Vehicle Assigned Successfully");
                textBox1.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
               

                
            }
            con.Close();
            
            

          
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
