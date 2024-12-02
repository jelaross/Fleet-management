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
    public partial class addvehicles : Form
    {
        private Dictionary<string, List<string>> vehicleModels = new Dictionary<string, List<string>>();
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public addvehicles()
        {
            InitializeComponent();
           
            comboBox1.Items.Add("Light-Duty");
            comboBox1.Items.Add("Medium-Duty");
            comboBox1.Items.Add("Medium-Duty");
            comboBox1.Items.Add("Heavy-Duty");
            comboBox1.Items.Add("Service Vehicles");

            // Add sub-items for each vehicle type to the dictionary
            vehicleModels.Add("Light-Duty", new List<string> { "Ford Transit", "Mercedes-Benz Sprinter", "Ram ProMaster" });
            vehicleModels.Add("Medium-Duty", new List<string> { "Isuzu N-Series", "Hino 195", "Freightliner M2 106" });
            vehicleModels.Add("Heavy-Duty", new List<string> { "Freightliner Cascadia", "Volvo VNL", "Kenworth T680" });
            vehicleModels.Add("Service Vehicles", new List<string> { "Ford F-550", "Chevrolet Silverado 3500HD", "Ram 5500" });
            gettid();
        }
        public void gettid()
        {
            con.Open();
            string query = "select isnull(MAX(vid),30100)+1 from vehiclesdetails";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            con.Close();
        }
      
       

        private void button1_Click(object sender, EventArgs e)
        {
            string extension = Path.GetExtension(textBox6.Text);
            string filename = textBox1.Text + extension;
            string actualpath = Application.StartupPath + "\\vehiclepicss\\" + filename;
            string virtualpath = "\\vehiclepicss\\" + filename;
            File.Copy(textBox6.Text, actualpath, overwrite: true);



            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Fill");
                return;
            }
            string q1 = "insert into vehiclesdetails values('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','"+virtualpath+"')";
            SqlCommand cmd = new SqlCommand(q1, con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Vechicle Added successfully");
                textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
                comboBox2.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
            }
            con.Close();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            // Get selected item from ComboBox1
            string selectedVehicleType = comboBox1.SelectedItem.ToString();

            // Populate ComboBox2 with the corresponding sub-items
            if (vehicleModels.ContainsKey(selectedVehicleType))
            {
                comboBox2.Items.AddRange(vehicleModels[selectedVehicleType].ToArray());
            }

            // Optionally, select the first item in ComboBox2 automatically
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
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

        private void addvehicles_Load(object sender, EventArgs e)
        {

        }
    }
}
