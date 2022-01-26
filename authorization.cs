﻿using System;
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


        [Obsolete]
        private void button3_Click(object sender, EventArgs e)
        {
            String LoginUser = textBox1.Text;
            String PassUser = textBox2.Text;


            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand($"INSERT INTO [Users] (name, surname, phone, password, email) VALUES (@name, @surname, @phone, @password, @email)", SqlConnection);
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PassUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");
        }
    }
}
