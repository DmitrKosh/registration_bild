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
using System.Data.Common;
using System.Data.OleDb;
using System.Data.Entity;

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
           SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString); 
           SqlConnection.Open(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form registration_form = new registration();
            registration_form.Show();  
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        [Obsolete]
        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT id, name, surname, email, password FROM Users WHERE email = N'" + textBox1.Text + "' and password = N'" + textBox2.Text + "'", SqlConnection);
            DataTable dataSet = new DataTable();
            dataAdapter.Fill(dataSet);

            using (UserContext db = new UserContext())
            {
                var userEmail = db.Users.Where(p => p.email == textBox1.Text && p.password == textBox2.Text).ToList();
                if (userEmail.Count > 0)
                {
                    perem.name = Convert.ToString(dataSet.Rows[0]["name"]);
                    perem.surname = Convert.ToString(dataSet.Rows[0]["surname"]);
                    perem.email = textBox1.Text;
                    this.Hide();
                    Callendar_forma callendar_form = new Callendar_forma();

                    callendar_form.Show(); 
                    this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                  MessageBox.Show("Неправильно введённые имя или пароль");
                }
            }
            

           
        }
    }
}
