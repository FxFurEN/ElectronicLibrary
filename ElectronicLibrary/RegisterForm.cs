using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace ElectronicLibrary
{
    public partial class RegisterForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=12300;Database=postgres";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user_login = textBox1.Text;
            string user_password = textBox2.Text;

            if (RegisterUser(user_login, user_password))
            {
                MessageBox.Show("Регистрация успешна!");
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Не удалось зарегистрировать пользователя. Пожалуйста, повторите попытку.");
            }
        }

        private bool RegisterUser(string login, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                // Проверка, существует ли аккаунт с указанным логином
                string checkQuery = "SELECT COUNT(*) FROM user_tbl WHERE login = @login";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@login", login);
                    long existingAccountsCount = (long)checkCommand.ExecuteScalar();

                    if (existingAccountsCount > 0)
                    {
                        // Аккаунт с указанным логином уже существует
                        MessageBox.Show("Пользователь с таким логином уже существует. Выберите другой логин.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Если аккаунта с указанным логином нет, добавляем новый аккаунт
                string insertQuery = "INSERT INTO User_tbl (login, password) VALUES (@login, @password)";
                using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Успешная регистрация
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
