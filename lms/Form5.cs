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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["lms.Properties.Settings.DBfileConnectionString"].ToString();
            connection.Open();
            OleDbCommand cmmd = connection.CreateCommand();
            cmmd.CommandType = CommandType.Text;
            cmmd.CommandText = "insert into [user]([username],[password]) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            
            cmmd.ExecuteNonQuery();
            connection.Close();

            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
