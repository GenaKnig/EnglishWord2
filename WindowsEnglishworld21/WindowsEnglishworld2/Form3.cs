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

namespace WindowsEnglishworld2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private SqlConnection sqlnwire = null;
        int a = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // string a = "1";
            // SqlCommand command = new SqlCommand(
            //    $"SELECT Word FROM Worlds  VALUES (N'{a}' )" , sqlnwire);
            //textBox1.Text  = a;

            //$"SELECT Word FROM Worlds WHERE Id = N'{i}' VALUES   ", sqlnwire);
            //dataGridView1.DataSource = dataSet.Tables[0];
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Potfolio\WindowsEnglishworld2\WindowsEnglishworld2\DatabaseEnglish.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                //textBox3.Text = queryResult.Skip(10).First();
                //var ids = queryResult.Select(x => x.Id);
                
                int b = ++a;
                using (SqlCommand cmd = new SqlCommand($"SELECT Id, Word, Translate FROM Worlds WHERE Id='{b}' "))
                { 
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox3.Text = sdr["Id"].ToString();
                        textBox1.Text = sdr["Word"].ToString();
                        textBox2.Text = sdr["Translate"].ToString();
                        

                    }
                    con.Close();
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Potfolio\WindowsEnglishworld2\WindowsEnglishworld2\DatabaseEnglish.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                //textBox3.Text = queryResult.Skip(10).First();
                //var ids = queryResult.Select(x => x.Id);

                int b = --a;
                using (SqlCommand cmd = new SqlCommand($"SELECT Id, Word, Translate FROM Worlds WHERE Id='{b}' "))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox3.Text = sdr["Id"].ToString();
                        textBox1.Text = sdr["Word"].ToString();
                        textBox2.Text = sdr["Translate"].ToString();


                    }
                    con.Close();
                }
            }
        }
    }
}
