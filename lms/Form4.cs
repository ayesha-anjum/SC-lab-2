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
    public partial class Form4 : Form
    {
        
        public Form4(string name)
        {
            InitializeComponent();
            textBox4.Text = name;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["lms.Properties.Settings.DBfileConnectionString"].ToString();
            connection.Open();
            OleDbCommand command1 = connection.CreateCommand();
            OleDbCommand command2 = connection.CreateCommand();
            command1.CommandType = CommandType.Text;
            command2.CommandType = CommandType.Text;
            command1.CommandText = "update [artifacts] set [avaiable_copies]=[avaiable_copies]-1 where [name]='" + textBox1.Text + "'";
            command2.CommandText = "insert into [issued](artifactname,[username]) values( '" + textBox1.Text + "','" + textBox4.Text + "' )";
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["lms.Properties.Settings.DBfileConnectionString"].ToString();
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select name,author from artifacts where avaiable_copies>0";
                command.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["lms.Properties.Settings.DBfileConnectionString"].ToString();
            connection.Open();
            OleDbCommand command11 = connection.CreateCommand();
            OleDbCommand command12 = connection.CreateCommand();
            command11.CommandType = CommandType.Text;
            command12.CommandType = CommandType.Text;
            command11.CommandText = "update [artifacts] set [avaiable_copies]=[avaiable_copies]+1 where [name]='" + textBox1.Text + "'";
            command12.CommandText = "delete from [issued](artifactname,[username]) values( '" + textBox1.Text + "','" + textBox4.Text + "' )";
            command11.ExecuteNonQuery();
            command12.ExecuteNonQuery();
            connection.Close();
        }
    }
}
