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

namespace registration.Callendar
{
    public partial class UserControlDays : UserControl
    {

        String connString = "server=localhost;user id=root; database=db_calendar;sslmode=none";

        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            FormEvent eventForm = new FormEvent();
            eventForm.Show();

        }

        // Создаем новый метод для отображения ивентов на календаре (Тут тоже устаревший код)

        private void displayEvent()
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            String sql = "SELECT * FROM tbl_calendar where date = ?";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", lbdays.Text + "/" + callendar_v1.static_month + "/" + callendar_v1.static_year);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbEvent.Text = reader["event"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }
        
    }
}
