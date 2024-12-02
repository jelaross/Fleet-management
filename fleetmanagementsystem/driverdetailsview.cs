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
    public partial class driverdetailsview : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
        public driverdetailsview()
        {
            InitializeComponent();
            fillgrid();
            fillgrid1();
            fillgrid2();
            fillgrid3();
            LoadImagesFromFolder(Application.StartupPath + "\\vehiclepicss");
            LoadImagesFromFolder2(Application.StartupPath + "\\driverpics");
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
        
             public void fillgrid3()
        {
            
        }
         private void LoadImagesFromFolder(string folderPath)
        {
            // Clear existing images
            imageList1.Images.Clear();
            listView1.Items.Clear();

            // Get all image files in the specified folder
            string[] imageFiles = Directory.GetFiles(folderPath, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jfif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string file in imageFiles)
            {
                try
                {
                    // Load the image and add it to the ImageList
                    Image img = Image.FromFile(file);
                    imageList1.Images.Add(img);

                    // Add an item to the ListView
                    ListViewItem item = new ListViewItem
                    {
                        ImageIndex = imageList1.Images.Count - 1, // Set
                        Text = Path.GetFileNameWithoutExtension(file) // Display the file name
                    };
                    listView1.Items.Add(item);
                }
                catch (Exception )
                {
                   
                }
            }

            // Set the ImageList for the ListView
            listView1.LargeImageList = imageList1;
        }
         private void LoadImagesFromFolder2(string folderPath)
         {
             // Clear existing images
             imageList2.Images.Clear();
             listView2.Items.Clear();

             // Get all image files in the specified folder
             string[] imageFiles = Directory.GetFiles(folderPath, "*.*")
                 .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                             f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                             f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                             f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                             f.EndsWith(".jfif", StringComparison.OrdinalIgnoreCase) ||
                             f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                 .ToArray();

             foreach (string file in imageFiles)
             {
                 try
                 {
                     // Load the image and add it to the ImageList
                     Image img = Image.FromFile(file);
                     imageList2.Images.Add(img);

                     // Add an item to the ListView
                     ListViewItem item = new ListViewItem
                     {
                         ImageIndex = imageList2.Images.Count - 1, // Set the image index
                         Text = Path.GetFileNameWithoutExtension(file) // Display the file name
                     };
                     listView2.Items.Add(item);
                 }
                 catch (Exception )
                 {

                 }
             }

             // Set the ImageList for the ListView
             listView2.LargeImageList = imageList2;
         }
    
        public void fillgrid1()
        {
            con.Open();
            string str = "select * from vehiclesdetails";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(str, con);
            sqlda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        public void fillgrid2()
        {
            con.Open();
            string str = "select * from assignvechicle";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(str, con);
            sqlda.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = listView2.SelectedItems[0];

                // Get the text of the selected item
                string selectedText = selectedItem.Text;
                persondeatilsdriver obj = new persondeatilsdriver(selectedText);
                ActiveForm.Hide();
                obj.Show();
            }
        }

        private void driverdetailsview_Load(object sender, EventArgs e)
        {

        }
    }
}
