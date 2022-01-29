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

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (!(i == 8 || (i >= 48 && i <= 57) || (i >= 65 && i <= 70)))
                e.Handled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            DataTable table = new DataTable();

            string StrokaEmail = txtEmail.Text;
            string StrokaName = txtName.Text;
            string StrokaSurname = txtSurname.Text;
            string StrokaPassword = txtPassword.Text;
            

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT email, password FROM Users WHERE email = '" + txtEmail.Text + "'", SqlConnection);



            DataTable dataSet = new DataTable();

            dataAdapter.Fill(dataSet);

            if (dataSet.Rows.Count > 0)
            {
                MessageBox.Show("Логин уже занят");
            }
            else if

             (StrokaName.Length < 2 || StrokaName.Length > 10)
                MessageBox.Show("Имя слишком короткое или длинное!");
            else if
                (StrokaSurname.Length < 3 || StrokaSurname.Length > 15)
            {
                MessageBox.Show("фамилия слишком короткая или длинная!");
            }

            else if
                (StrokaPassword.Length < 5 || StrokaPassword.Length > 15)
            {
                MessageBox.Show("Пароль должен быть не менее 5 символов и не более 15 символов!");
            }
            else if              
                (StrokaEmail.Length < 5 || StrokaEmail.Length > 20)
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

                MessageBox.Show("Пользователь зарегистрирован");

            }
        }




    }
}
