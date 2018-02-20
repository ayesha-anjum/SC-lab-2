using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lms
{
    public partial class Form3 : Form
    {

        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["lms.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [user] where [username]='" + textBox1.Text + "' and [password]='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable(); 
            da.Fill(dt);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Username or Password Invalid!");
            }

            else
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                Form4 f4 = new Form4(textBox1.Text);
                f4.Show();

            }
        }
    }
}
