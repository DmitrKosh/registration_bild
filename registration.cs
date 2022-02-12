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
using System.Data.SqlClient;
using MySqlConnector;
using System.Windows.Input;
using System.Data.Entity;

namespace registration
{
    public partial class registration : Form
    {
        private SqlConnection SqlConnection = null;
        private readonly Validation validation;
        public registration()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            Connection.Open();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            perem.email = txtEmail.Text;
            perem.name = txtName.Text;
            perem.surname = txtSurname.Text;
            string password = txtPassword.Text;

            using (UserContext db = new UserContext()) 
            {
                var proverka = db.Users.Where(p => p.email == txtEmail.Text).ToList();
                if (proverka.Count == 1)
                {
                    MessageBox.Show("Логин уже занят");
                }
                else if
                 (perem.name.Length < 2 || perem.name.Length > 10)
                    MessageBox.Show("Имя слишком короткое или длинное!");
                else if
                    (perem.surname.Length < 3 || perem.surname.Length > 15)
                    MessageBox.Show("фамилия слишком короткая или длинная!");

                else if
                    (password.Length < 5 || password.Length > 15)
                    MessageBox.Show("Пароль должен быть не менее 5 символов и не более 15 символов!");

                else if
                    (perem.email.Length < 5 || perem.email.Length > 20)
                    MessageBox.Show("Логин должен включать от 5 до 20 символов");

                else
                {
                    
                    Users user1 = new Users { name = txtEmail.Text, surname = txtSurname.Text, password = txtPassword.Text, email = txtEmail.Text };
                    db.Users.Add(user1);
                    db.SaveChanges();

                    MessageBox.Show("Регистрация прошла успешно.");
                    Form ifrm = Application.OpenForms[0];
                    ifrm.Show();
                    this.Close();
                }
            }            
        }

    }
}
