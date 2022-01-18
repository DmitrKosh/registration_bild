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


namespace registration
{
    public partial class registration : Form
    {
        private SqlConnection SqlConnection = null;

        public registration()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            SqlConnection.Open();

            if (SqlConnection.State == ConnectionState.Open)
                {
                MessageBox.Show("Подключение к Базе Данных установлено");
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO [Users] (name, sername, phone, password, email) VALUES (@name, @sername, @phone, @password, @email)", SqlConnection);


            command.Parameters.AddWithValue("name", txtName.Text);
            command.Parameters.AddWithValue("sername", txtSername.Text);
            command.Parameters.AddWithValue("phone", txtPhone.Text);
            command.Parameters.AddWithValue("password", txtPassword.Text);
            command.Parameters.AddWithValue("email", txtEmail.Text);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }
    }
}
