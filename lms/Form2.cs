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
    public partial class Form2 : Form
    {
        public Form2()
        {

            DataTable dt = new DataTable(); 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["lms.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [admin] where [username]='" + textBox1.Text + "' and [password]='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Username or Password Invalid!");
            }

            else
            {
                MessageBox.Show("Login Successful!");
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
