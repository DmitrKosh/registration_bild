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

namespace registration
{
    public partial class registration : Form
    {
        private SqlConnection SqlConnection = null;

        public registration()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            SqlConnection.Open();

            if (SqlConnection.State == ConnectionState.Open)
                MessageBox.Show("БД включена");
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            //DataTable table = new DataTable();

            perem.StrokaEmail = txtEmail.Text;
            perem.StrokaName = txtName.Text;
            perem.StrokaSurname = txtSurname.Text;
            perem.StrokaPassword = txtPassword.Text;
            

           SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT email, password FROM Users WHERE email = '" + txtEmail.Text + "'", SqlConnection);



            DataTable proverka = new DataTable();

            dataAdapter.Fill(proverka); 

            if (proverka.Rows.Count > 0)
            {
                MessageBox.Show("Логин уже занят");
            }
            else if
            

             (perem.StrokaName.Length < 2 || perem.StrokaName.Length > 10)
                MessageBox.Show("Имя слишком короткое или длинное!");
            else if
                (perem.StrokaSurname.Length < 3 || perem.StrokaSurname.Length > 15)
            {
                MessageBox.Show("фамилия слишком короткая или длинная!");
            }

            else if
                (perem.StrokaPassword.Length < 5 || perem.StrokaPassword.Length > 15)
            {
                MessageBox.Show("Пароль должен быть не менее 5 символов и не более 15 символов!");
            }
            else if              
                (perem.StrokaEmail.Length < 5 || perem.StrokaEmail.Length > 20)
            {
                MessageBox.Show("Логин должен включать от 5 до 20 символов");
            }

           
            else
            {


                SqlCommand command = new SqlCommand($"INSERT INTO [Users] (name, surname, password, email) VALUES (@name, @surname, @password, @email)", SqlConnection);


                command.Parameters.AddWithValue("name", txtName.Text);
                command.Parameters.AddWithValue("surname", txtSurname.Text);
                command.Parameters.AddWithValue("password", txtPassword.Text);
                command.Parameters.AddWithValue("email", txtEmail.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Регистрация прошла успешно.");
                  Form ifrm = Application.OpenForms[0];
                  ifrm.Show();
                  this.Close();

            }
        }




    }
}
