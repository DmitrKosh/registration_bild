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
            String LoginUser = textBox1.Text;
            String PassUser = textBox2.Text;

            SqlCommand command = new SqlCommand("SELECT * FROM `TestDB` WRERE 'textBox1' = @email AND 'textBox2' = @password", SqlConnection);//Если что дело в этой строке подключения , я сделал так чтобы небыло старых версий sql , в поле email и password меняй в соотсветсвие с данными из бд 
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PassUser;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                MessageBox.Show("Всё парвильно добро пожаловать!");
            else
                MessageBox.Show("YNo");
            textBox1.Clear();
            textBox2.Clear();

        }
    }
}
