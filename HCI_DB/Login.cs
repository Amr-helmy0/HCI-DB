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
    public partial class Login : Form
    {
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=MAHER23315320\MAHER23320;Initial Catalog=cs;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }
        Me me = new Me();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dd(object sender, MouseEventArgs e)
        {
            me.MouseControl(this.Handle);
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnection.Open();
                string query = "select * from emp_data where email='" + login_email.Text + "' and password='" + login_pass.Text + "' ";

                SqlCommand sqlcm = new SqlCommand(query, sqlconnection);
                SqlDataReader dataReader = sqlcm.ExecuteReader();


                if (dataReader.Read())
                {

                    this.Hide();
                    Home h = new Home();
                    h.Show();
                    
                }
                else
                {
                    MessageBox.Show("Please Try Again", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlconnection.Close();

                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, " Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlconnection.Close();


            }
            sqlconnection.Close();
        }


    }
}
