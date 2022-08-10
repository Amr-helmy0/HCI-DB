using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_DB
{
    public partial class DB : Form
    {
        public DB()
        {
            InitializeComponent();
            DisplayData();
        }

        SqlConnection sqlconnection = new SqlConnection(@"Data Source=MAHER23315320\MAHER23320;Initial Catalog=cs;Integrated Security=True");


        private void DB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'csDataSet.emp_data' table. You can move, or remove it, as needed.
            this.emp_dataTableAdapter.Fill(this.csDataSet.emp_data);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void DisplayData()
        {
            sqlconnection.Open();
            string query = "select * from emp_data";
            SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
            sqlcommand.ExecuteNonQuery();
            DataTable db = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcommand);
            dataAdapter.Fill(db);
            dataGridView.DataSource = db;
            sqlconnection.Close();


        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnection.Open();
                string query = "select * from emp_data where id='"+mn_id.Text+"'";
                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
                sqlcommand.ExecuteNonQuery();
                DataTable db = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcommand);
                dataAdapter.Fill(db);
                dataGridView.DataSource = db;
                sqlconnection.Close();
            }
            catch(SqlException ex )
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnection.Open();
                string query = "update emp_data set name ='" + mn_pass.Text+"' where id='"+mn_id.Text+"'";
                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();


                DisplayData();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlconnection.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnection.Open();
                string query = "delete from emp_data where id='" + mn_id.Text + "'";
                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();



                DisplayData();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlconnection.Close();

            }
        }
    }
}
