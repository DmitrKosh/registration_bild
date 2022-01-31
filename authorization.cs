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
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data.OleDb;

namespace registration
{
    public partial class authorization : Form
    {
        private SqlConnection SqlConnection = null;

        [Obsolete]
        public authorization()
        {
            InitializeComponent();
        }

        private void authorization_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString); //конектим бд

            SqlConnection.Open(); //открываем бд
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = new registration();
            ifrm.Show(); //отображение формы регистрации 
            this.Hide(); //скрываем текущую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT id, name, surname, email, password FROM Users WHERE email = N'" + textBox1.Text + "' and password = N'" + textBox2.Text + "'", SqlConnection);



            DataTable dataSet = new DataTable();

            dataAdapter.Fill(dataSet);

            

            if (dataSet.Rows.Count > 0)
            {
                
                perem.name = Convert.ToString(dataSet.Rows[0]["name"]);
                perem.surname = Convert.ToString(dataSet.Rows[0]["surname"]);
                perem.StrokaEmail = textBox1.Text;
                this.Hide();
                callendar_v1 ifrmn = new callendar_v1();

                
                

                ifrmn.Show(); //отображение формы регистрации 
                this.Hide();
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Неправильно введённые имя или пароль");
            }
          


        }

    }
}
