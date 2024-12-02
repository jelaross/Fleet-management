


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
    public partial class driverregistration : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public driverregistration()
        {
            InitializeComponent();
            gettid();
        }
        public void gettid()
        {
            con.Open();
            string query = "select isnull(MAX(did),10100)+1 from driverdetails";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            con.Close();

        }

        private void driverregistration_Load(object sender, EventArgs e)
        {
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Fill");
                return;
            }
            string shin1 = "select * from logindetails where username='" + textBox2.Text + "'";
            SqlCommand cmd2 = new SqlCommand(shin1, con);
            
            con.Open();
            SqlDataReader shin = cmd2.ExecuteReader();

            if (shin.Read())
            {
                MessageBox.Show("username already exist");
                return;
            }
            con.Close();

            string extension = Path.GetExtension(textBox6.Text);
            string filename = textBox1.Text + extension;
            string actualpath = Application.StartupPath + "\\driverpics\\" + filename;
            string virtualpath = "\\driverpics\\" + filename;
            File.Copy(textBox6.Text,actualpath, overwrite: true);




            string q1 = "insert into driverdetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','"+virtualpath+"')";
            SqlCommand cmd = new SqlCommand(q1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            string usertype = "driver";
            string q2 = "insert into logindetails values('" + textBox2.Text + "','" + textBox7.Text + "','" + usertype + "')";
            SqlCommand cmd1 = new SqlCommand(q2, con);
            con.Open();

            if (cmd1.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Driver Created successfully");
                textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
                textBox5.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
               
                textBox7.Text = "";
                comboBox1.Text = "";
            }
            con.Close();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image File";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            

                // Show the dialog and check if the user clicked OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox6.Text = openFileDialog.FileName;
                    pictureBox1.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
