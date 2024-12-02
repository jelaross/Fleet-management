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
    public partial class ownerlogin : Form
    {
        public ownerlogin(string username_from_login)
        {
            InitializeComponent();
            greeting();
        }

        public void greeting()
        {
            int hour = DateTime.Now.Hour;

            // Determine greeting based on the hour
            if (hour >= 0 && hour < 12)
            {
                label1.Text="Good Morning "+Program.username ;
            }
            else if (hour >= 12 && hour < 17)
            {
                label1.Text = "Good Afternoon " + Program.username;
            }
            else
            {
                label1.Text = "Good Evening " + Program.username;
            }
        }
        private void ownerlogin_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
            driverregistration obj = new driverregistration();
           
            obj.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            driverdetailsview obj = new driverdetailsview();
           
            obj.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
           
            addvehicles obj = new addvehicles();
            obj.Show();
         
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          
            updatedetails obj = new updatedetails();
            obj.Show();
          
          
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           
            assign_vechicles obj = new assign_vechicles();
            
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            

            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ownerpasswordchange obj = new ownerpasswordchange();


            obj.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {

            OwnerViewTrips obj = new OwnerViewTrips();
            obj.Show();
        }
    }
}
