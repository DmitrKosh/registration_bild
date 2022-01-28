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

namespace registration
{
    public partial class authorization : Form
    {
        private SqlConnection SqlConnection = null;

        public authorization()
        {
            InitializeComponent();
        }

        private void authorization_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString); //конектим бд

            SqlConnection.Open(); //открываем бд

            if (SqlConnection.State == ConnectionState.Open) //проверяем открылась ли БД
            {
                MessageBox.Show("Подключение к Базе Данных установлено");
            }
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


            SqlCommand command = new SqlCommand("Select id,email,password From Users where email = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", SqlConnection);//Если что дело в этой строке подключения , я сделал так чтобы небыло старых версий sql , в поле email и password меняй в соотсветсвие с данными из бд 

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable dt = new DataTable();

            if (dt.Rows.Count > 0)  // Проверяем, что количество строк из БД больше нуля
            {
                // Нужный Вам ID
                string id = dt.Rows[0][0].ToString();
                this.Hide();
                authorization ss = NewMethod();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Неправильно введённые имя или пароль");
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private static authorization NewMethod()
        {
            return new authorization();
        }
    }
}
