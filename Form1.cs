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
    public partial class callendar_v1 : Form
    {
        private SqlConnection SqlConnection = null;

        int month, year;
        public static int static_month, static_year;
        public callendar_v1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void callendar_v1_Load(object sender, EventArgs e)
        {
            displayDays();

            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            SqlConnection.Open();



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

            for (int i = 1; i <= days; i++)
            {
                Callendar.UserControlDays UserDays = new Callendar.UserControlDays();
                UserDays.days(i);
                dayContainer.Controls.Add(UserDays);
            }
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbNext_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // Меняем дни при переключении месяца ВПЕРЕД

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
            }

        }

        private void LbPrev_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // Меняем дни при переключении месяца НАЗАД

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
            }

        }

    }
}
