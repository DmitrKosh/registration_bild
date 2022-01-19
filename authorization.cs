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
    }
}
