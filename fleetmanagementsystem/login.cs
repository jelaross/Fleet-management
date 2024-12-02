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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public login()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            string query = "Select * from logindetails where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string utype = dr[2].ToString();
                if (utype == "owner")
                {
                    Program.username = dr[0].ToString();
                    ownerlogin obj = new ownerlogin(dr[0].ToString());
                    dr.Close();
                    ActiveForm.Hide();
                    obj.Show();
                }
                else if (utype == "driver")
                {

                    Program.username = dr[0].ToString();

                    dr.Close();
                    string query1 = "Select * from driverdetails where name='" + textBox1.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        Program.did = dr1[0].ToString();
                        Program.dname = dr1[1].ToString();
                        driverlogin obj1 = new driverlogin(dr1[1].ToString());
                        ActiveForm.Hide();
                        obj1.Show();


                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username or password ");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                con.Close();
            }
            else
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
