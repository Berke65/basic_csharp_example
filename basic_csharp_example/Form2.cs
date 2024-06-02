using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace basic_csharp_example
{
    public partial class Form2 : Form
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter adapter;
        public Form2()
        {
            InitializeComponent();
        }

        void listele()
        {

            string baglan = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\beke.mdb";
            string sorgu = "SELECT * FROM ders WHERE sorumu_ogr_sifre = @sifre";
            connection = new OleDbConnection(baglan);

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sorgu, connection);
                command.Parameters.AddWithValue("@sifre", textBox1.Text);
                adapter = new OleDbDataAdapter(command);
                DataSet al = new DataSet();
                adapter.Fill(al, "abc");
                dataGridView1.DataSource = al.Tables[0];

               dataGridView1.Columns["ogr_sifre"].Visible = false;
          

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

     

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listele();
        }
    }
}
