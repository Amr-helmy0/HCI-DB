using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_DB
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Me me = new Me();
        private void MouseControl(object sender, MouseEventArgs e)
        {
            me.MouseControl(this.Handle);
        }

        public void Change(object item)
        {
            if (this.HomePicture.Controls.Count > 0)
            {
                this.HomePicture.Controls.RemoveAt(0);
                Form form = item as Form;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                this.HomePicture.Controls.Add(form);
                this.HomePicture.Tag = form;
                form.Show();
            }
            else
            {

                Form form = item as Form;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                this.HomePicture.Controls.Add(form);
                this.HomePicture.Tag = form;
                form.Show();
            }

        }

        private void search_Click(object sender, EventArgs e)
        {
            Change(new Insert_Data());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change(new DB());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/MAHER23320");
        }
    }


}
