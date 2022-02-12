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
using System.Data.Common;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace registration.Callendar
{
    public partial class UserControlDays : UserControl
    {

        private SqlConnection SqlConnection = null;

        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();           
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
    }
}
