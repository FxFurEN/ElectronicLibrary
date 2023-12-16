using Npgsql;
using System;
using System.Windows.Forms;

namespace ElectronicLibrary
{
    public partial class LoginForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=12300;Database=postgres";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            long userId = IsValidUser(login, password);

            if (userId != -1)
            {
                MessageBox.Show("Авторизация успешна!");
                Form1 mainForm = new Form1();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Неверные учетные данные. Пожалуйста, повторите попытку.");
            }
        }

        private long IsValidUser(string login, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT id FROM user_tbl WHERE login = @login AND password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt64(result);
                        }
                        else
                        {
                            return -1; // Или другое значение, которое будет обозначать неудачу.
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                        return -1; // Или другое значение, которое будет обозначать неудачу.
                    }
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.FormClosed += (s, args) => this.Close();
            registerForm.Show();
        }
    }
}
