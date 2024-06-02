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
using basic_csharp_example;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace basic_csharp_example
{
    public partial class Form1 : Form // aa
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();
        }

        private bool login(string username, string password)
        {
            string baglan, sorgu;
            baglan = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\beke.mdb";
            sorgu = "SELECT COUNT(*) FROM ogrenci_giris WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
            connection = new OleDbConnection(baglan);

            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@KullaniciAdi", username);
                command.Parameters.AddWithValue("@Sifre", password);

                connection.Open();
                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Giriş başarılı");
                    return true;
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre");
                    return false;
                }
            }
        }

        private bool login2(string username, string password)
        {
            string baglan, sorgu;
            baglan = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\beke.mdb";
            sorgu = "SELECT COUNT(*) FROM ogretmen_giris WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
            connection = new OleDbConnection(baglan);

            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@KullaniciAdi", username);
                command.Parameters.AddWithValue("@Sifre", password);

                connection.Open();
                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Giriş başarılı");
                    return true;
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre");
                    return false;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş geçmeyiniz");
            }

            else
            {
                if (password.Length < 2)
                {
                    MessageBox.Show("Şifreniz en az 2 karakter olmalıdır");
                }
                else
                {
                    if (login2(username, password))
                    {
                        Form2 form2gecis = new Form2();
                        form2gecis.ShowDialog();
                    }


                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş geçmeyiniz");
            }

            else
            {
                if (password.Length < 2)
                {
                    MessageBox.Show("Şifreniz en az 2 karakter olmalıdır");
                }
                else
                {
                    if (login(username, password))
                    {
                        Form3 form3gecis = new Form3();
                        form3gecis.ShowDialog();
                    }

                }
            }
        }
    }
}
