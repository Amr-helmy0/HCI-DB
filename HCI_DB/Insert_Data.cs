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

namespace HCI_DB
{
    public partial class Insert_Data : Form
    {

        SqlConnection sqlconnection = new SqlConnection(@"Data Source=MAHER23315320\MAHER23320;Initial Catalog=cs;Integrated Security=True");


        public Insert_Data()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnection.Open();
                string query = "insert into emp_data values('" + id.Text + "' , '" + name.Text + "' , '" + email.Text + "' , '" + password.Text + "' , '" + slr.Text + "')";

                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);

                MessageBox.Show("Inserted Succefully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlconnection.Close();
            }

        }
    }
}
