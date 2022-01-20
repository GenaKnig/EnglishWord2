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
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EnglishBase"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                //MessageBox.Show("Брат братан братішка подключенія є");

            }
            else
            {
                MessageBox.Show("Немає підключення до бази даних.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxEnglish.Text == "" || textBoxTranslate.Text == "")
            {
                MessageBox.Show("Неохідно вести слово і його переклад.");
            }
            else
            {
SqlCommand command = new SqlCommand(
                $"INSERT INTO [Worlds] (Word, Translate) VALUES (N'{textBoxEnglish.Text}',N'{textBoxTranslate.Text}' )" , sqlConnection);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }
    }
}
