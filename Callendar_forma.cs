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
    public partial class Callendar_forma : Form
    {
        private SqlConnection SqlConnection = null;

        int month, year;
        public static int static_month, static_year;
        public Callendar_forma()
        {
            InitializeComponent();
            label3.Text = perem.name + " " + perem.surname;
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            SqlConnection.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void callendar_v1_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void displayDays()
        {
            DateTime present = DateTime.Now;

            month = present.Month;
            year = present.Year;

            String monthName = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            static_month = month;
            static_year = year;
            // Получаем первый день месяца.

            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            // Получаем подсчет дней в месяце.

            int days = DateTime.DaysInMonth(year, month);

            // Конвертируем firstDayOfMonth в тип integer

            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d"));

            // Создаем пользовательский элемент управления UserControlBlank. После этого прописываем цикл:

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                Callendar.UserControlBlank UserBlank = new Callendar.UserControlBlank();
                dayContainer.Controls.Add(UserBlank);
            }

            // Потом создаем пользовательский элемент управления UserControlDays. После этого прописываем цикл:

            for (int day = 1; day <= days; day++)
            {
                Callendar.UserControlDays UserDays = new Callendar.UserControlDays();
                UserDays.days(day);
                dayContainer.Controls.Add(UserDays);

                string data = day + "/" + month + "/" + year;

                /*  SqlCommand сonnection = new SqlCommand("SELECT name_event, email, data FROM events WHERE email = N'" + perem.StrokaEmail + "' and data = '" + data + "'", SqlConnection);
                  DataTable dataGet = new DataTable();
                  dataGet.Columns.Add(new DataColumn("name_event", Type.GetType("System.String")));
                  dataGet.Columns.Add(new DataColumn("email", Type.GetType("System.String")));
                  dataGet.Columns.Add(new DataColumn("data", Type.GetType("System.String")));

                  DataRow dataRow = dataGet.NewRow();

                  dataRow["email"] = perem.StrokaEmail;
                  dataRow["data"] = data;
                  dataGet.Rows.Add(dataRow);*/
                string select_event = @"SELECT name_event, email, 
                data FROM events WHERE email = N'"
                + perem.email + "' and data = N'" + data + "'";
                SqlCommand command = new SqlCommand(select_event, SqlConnection);
                SqlDataAdapter proverkaAdaptera = new SqlDataAdapter(command);
                DataTable dataGet = new DataTable();
                proverkaAdaptera.Fill(dataGet);

                if (dataGet.Rows.Count > 0)
                {
                    UserDays.BackColor = Color.Gray;
                }
            }
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();


        }


        private void lbNext_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // Меняем дни при переключении месяца ВПЕРЕД
            if (month == 12)
            {
                month = 0;
                year++;
            }
            month++;
            static_month = month;
            static_year = year;
            String monthName = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                Callendar.UserControlBlank UserBlank = new Callendar.UserControlBlank();
                dayContainer.Controls.Add(UserBlank);

                
            }

            for (int i = 1; i <= days; i++)
            {
                Callendar.UserControlDays UserDays = new Callendar.UserControlDays();
                UserDays.days(i);
                dayContainer.Controls.Add(UserDays);

                string data = i + "/" + month + "/" + year;

                string select_event = @"SELECT name_event, email, 
                data FROM events WHERE email = N'"
                + perem.email + "' and data = N'" + data + "'";
                SqlCommand command = new SqlCommand(select_event, SqlConnection);
                SqlDataAdapter proverkaAdaptera = new SqlDataAdapter(command);
                DataTable dataGet = new DataTable();
                proverkaAdaptera.Fill(dataGet);

                if (dataGet.Rows.Count > 0)
                {
                    UserDays.BackColor = Color.Gray;
                }
            }

        }

        private void LbPrev_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // Меняем дни при переключении месяца НАЗАД
            if (month == 1)
            {
                month = 13;
                year--;
            }
            month--;
            static_month = month;
            static_year = year;
            String monthName = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                Callendar.UserControlBlank UserBlank = new Callendar.UserControlBlank();
                dayContainer.Controls.Add(UserBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                Callendar.UserControlDays UserDays = new Callendar.UserControlDays();
                UserDays.days(i);
                dayContainer.Controls.Add(UserDays);

                string data = i + "/" + month + "/" + year;

                string select_event = @"SELECT name_event, email, 
                data FROM events WHERE email = N'"
                + perem.email + "' and data = N'" + data + "'";
                SqlCommand command = new SqlCommand(select_event, SqlConnection);
                SqlDataAdapter proverkaAdaptera = new SqlDataAdapter(command);
                DataTable dataGet = new DataTable();
                proverkaAdaptera.Fill(dataGet);

                if (dataGet.Rows.Count > 0)
                {
                    UserDays.BackColor = Color.Gray;
                }
            }

        }

    }
}
