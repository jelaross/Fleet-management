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
    public partial class updatedetails : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public updatedetails()
        {
            InitializeComponent();
            fillcombo();
            fillgrid();
            fillcombo3();
        }
        public updatedetails(string id)
        {
            InitializeComponent();
            comboBox1.Text = id;
           
            comboBox2.Text = id;
            string query = "Select * from driverdetails where did='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();

               comboBox3.Text = dr[5].ToString();
            }
            dataGridView1.Visible = false;
            con.Close();
            
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
        public void fillcombo3()
        {
            string query = "Select did from driverdetails";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());

            }
            con.Close();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void updatedetails_Load(object sender, EventArgs e)
        {

        }
        public void fillgrid()
        {
            con.Open();
            string str = "select * from driverdetails";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(str, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "update driverdetails set name='" + textBox1.Text + "',age='" + textBox2.Text + "',mobile='" + textBox3.Text + "',gender='" + comboBox3.Text + "'where did='"+comboBox1.Text+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Value updated successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox3.Text = "";
                comboBox1.Text = "";
            }
            con.Close();
            fillgrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                comboBox3.Text = dr[5].ToString();
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "delete from driverdetails where did='" + comboBox2.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("driver details deleted");
                this.Close();
                
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
              string query = "Select * from driverdetails where did='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
                }

            con.Close();
        }
        }
    }

