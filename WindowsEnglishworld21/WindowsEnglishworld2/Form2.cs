using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WindowsEnglishworld2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private SqlConnection sqlnwire = null;

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlnwire = new SqlConnection(ConfigurationManager.ConnectionStrings["NotwingDB"].ConnectionString);
            sqlnwire.Open();

            if (sqlnwire.State == ConnectionState.Open)
            {
                //MessageBox.Show("Брат братан братішка подключенія є");

            }
            else
            {
                MessageBox.Show("Братан шухер менти подключенія нет");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(textBox1.Text, sqlnwire);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM Worlds", sqlnwire);
            DataSet dataSet = new DataSet();
            dataAdapter2.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $" DELETE FROM Worlds  WHERE Id = N'{textBox2.Text}'", sqlnwire);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }
    }
}
