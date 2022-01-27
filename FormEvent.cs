using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySqlConnector;

namespace registration
{
    public partial class FormEvent : Form
    {

        // Создаем строку подключения (Дима, Валя, это временно! Чисто проверить!)

        String connString = "server=localhost;user id=root; database=db_calendar;sslmode=none";


        public FormEvent()
        {
            InitializeComponent();
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {
            txtDate.Text = Callendar.UserControlDays.static_day + "/" + callendar_v1.static_month + "/" + callendar_v1.static_year;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);

            // ЭТО ТОЖЕ ВРЕМЕННО

            String sql = "INSERT INTO tbl_calendar(date,event)value(?,?)";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", txtDate.Text);
            cmd.Parameters.AddWithValue("date", txtEvent.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Сохранено!");
            cmd.Dispose();
            conn.Close();
        }
    }
}
