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
using System.Configuration;


namespace registration
{
    public partial class FormEvent : Form
    {
        

        private SqlConnection SqlConnection = null;

        // Создаем строку подключения (Дима, Валя, это временно! Чисто проверить!)

       // String connString = "server=localhost;user id=root; database=db_calendar;sslmode=none";


        public FormEvent()
        {
            InitializeComponent();
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {
            txtDate.Text = Callendar.UserControlDays.static_day + "/" + callendar_v1.static_month + "/" + callendar_v1.static_year;
           
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            SqlConnection.Open();
        }

        
        private void btSave_Click(object sender, EventArgs e)
        {
           // SqlConnection conn = new SqlConnection(connString);


            string StrokaNameEvent = txtNameEvent.Text;

  

            if (StrokaNameEvent.Length < 2 || StrokaNameEvent.Length > 20)
                MessageBox.Show("Имя события слишком короткое или длинное!"); //валидация на имя события, РАБОТАЕТ - НЕ ТРОЖ

            else
            {
                SqlCommand command = new SqlCommand($"INSERT INTO [Events] (name_event, type_event, description, data, email) VALUES (@name_event, @type_event, @description, @data, @email)", SqlConnection);
                command.Parameters.AddWithValue("name_event", txtNameEvent.Text);
                command.Parameters.AddWithValue("type_event", txtTypeEvent.Text);
                command.Parameters.AddWithValue("description", txtDescription.Text);
                command.Parameters.AddWithValue("data", txtDate.Text);
                //command.Parameters.AddWithValue("email", txtEmail2);


                MessageBox.Show(command.ExecuteNonQuery().ToString());
            }
            // ЭТО ТОЖЕ ВРЕМЕННО
            /*
            String sql = "INSERT INTO tbl_calendar(date,event)value(?,?)";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", txtDate.Text);
            cmd.Parameters.AddWithValue("date", txtEvent.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Сохранено!");
            cmd.Dispose();
            conn.Close(); */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
