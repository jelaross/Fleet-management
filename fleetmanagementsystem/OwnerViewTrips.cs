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
using System.Windows.Forms.DataVisualization.Charting;

namespace fleetmanagementsystem
{
    public partial class OwnerViewTrips : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-PBIP1KS; database=fleet; Integrated Security=true; ");
       
        public OwnerViewTrips()
        {
            InitializeComponent();
            filltotal();
            fillactive();
            fillclosed();
            fillgrid1();
            fillgrid2();
            fillrevenue();
            fillgraph1();
        }
        public void filltotal()
        {
            string query = "Select count(tid) from tripdetails";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               label4.Text=dr[0].ToString();

            }
            con.Close();
        }
        public void fillgraph1()
        {
            string query = "SELECT did, SUM(Fare) AS TotalFare FROM tripdetails GROUP BY did";
            con.Open();
            DataTable dataTable = new DataTable();

           
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(dataTable);
           

            // Plot the data
            PlotBarGraph1(dataTable);
            con.Close();
        }


        private void PlotBarGraph1(DataTable dataTable)
        {
            // Create a new chart
           

            // Create a series and add data points
            Series series = new Series
            {
                Name = "Fare",
              
            };
            chart1.Series.Add(series);

            // Add data points from DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                string driverId = row["did"].ToString();
                decimal totalFare = Convert.ToDecimal(row["TotalFare"]);

                series.Points.AddXY(driverId, totalFare);
            }

            // Add the chart to the form
           
        }
        public void fillactive()
        {
            string query = "Select count(tid) from tripdetails where status='active'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label5.Text = dr[0].ToString();

            }
            con.Close();
        }
        public void fillrevenue()
        {
            string query = "Select sum(fare) from tripdetails where status='close'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label8.Text = dr[0].ToString();

            }
            con.Close();
        }
        public void fillclosed()
        {
            string query = "Select count(tid) from tripdetails where status='close'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label6.Text = dr[0].ToString();

            }
            con.Close();
        }

        public void fillgrid1()
        {
            con.Open();
            string query = "Select * from tripdetails where status='active'";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        public void fillgrid2()
        {
            con.Open();
            string query = "Select * from tripdetails where status='close'";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void OwnerViewTrips_Load(object sender, EventArgs e)
        {

        }
    }
}
