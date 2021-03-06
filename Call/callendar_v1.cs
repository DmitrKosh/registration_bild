using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registration.Callendar
{
    public partial class callendar_v1 : Form
    {

        int month, year;

        public callendar_v1()
        {
            InitializeComponent();
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

            // Получаем первый день месяца.

            DateTime firstDayOfMonth = new DateTime(year, month,1);

            // Получаем подсчет дней в месяце.

            int days = DateTime.DaysInMonth(year, month);

            // Конвертируем firstDayOfMonth в тип integer

            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d"));

            // Создаем пользовательский элемент управления UserControlBlank. После этого прописываем цикл:

            for(int i=1;i<dayOfTheWeek;i++)
            {
                UserControlBlank UserBlank = new UserControlBlank();
                dayContainer.Controls.Add(UserBlank);
            }

            // Потом создаем пользовательский элемент управления UserControlDays. После этого прописываем цикл:

            for (int i=1;i<=days;i++)
            {
                UserControlDays UserDays = new UserControlDays();
                UserDays.days(i);
                dayContainer.Controls.Add(UserDays);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbNext_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // Меняем дни при переключении месяца ВПЕРЕД

            month++;

            String monthName = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank UserBlank = new UserControlBlank();
                dayContainer.Controls.Add(UserBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays UserDays = new UserControlDays();
                UserDays.days(i);
                dayContainer.Controls.Add(UserDays);
            }
        }

        private void lbPrev_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            // Меняем дни при переключении месяца НАЗАД

            month--;

            String monthName = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank UserBlank = new UserControlBlank();
                dayContainer.Controls.Add(UserBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays UserDays = new UserControlDays();
                UserDays.days(i);
                dayContainer.Controls.Add(UserDays);
            }
        }
    }
}
