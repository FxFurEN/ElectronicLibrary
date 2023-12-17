using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicLibrary
{
    public partial class Form1 : Form
    {

        private bool isFormOpen = false; // Флаг для отслеживания открытости формы
       

        // Установите параметры подключения к базе данных
        private const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12300;Database=postgres";


        public Form1()
        {
            InitializeComponent();
            LoadDataIntoListBox();
        }


        // метод для добалвение книги в бд 
        private void button2_Click(object sender, EventArgs e)
        {
            // Укажите путь к вашему PDF-файлу
            string filePath = "C:/4 курс/курсачи/ElectronicLibrary/kapitanskaya-dochka.pdf";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Читаем бинарные данные файла
                byte[] fileContent = File.ReadAllBytes(filePath);

                // Выполняем параметризованный запрос
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;

                    // Замените "books_tbl" на имя вашей таблицы
                    command.CommandText = "INSERT INTO public.books_tbl(title, author, release_date, file_content) VALUES (@Title, @Author, @ReleaseDate, @FileContent)";

                    // Добавляем параметры
                    command.Parameters.AddWithValue("@Title", "Капитанская дочка");
                    command.Parameters.AddWithValue("@Author", "Александр Пушкин");
                    command.Parameters.AddWithValue("@ReleaseDate", new DateTime(1836, 1, 1)); // Замените на фактическую дату
                    command.Parameters.AddWithValue("@FileContent", fileContent);

                    // Выполняем запрос
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void buttonOpenReadForm_Click(object sender, EventArgs e)
        {
            // Проверяем, что в ListBox выбран элемент
            if (listBox1.SelectedItem != null)
            {
                if (isFormOpen)
                {
                    return;
                }
                // Получаем информацию о выбранной книге
                BookInfo selectedBook = (BookInfo)listBox1.SelectedItem;

                // Получаем id выбранной книги
                int selectedBookId = selectedBook.Id;

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Выполняем запрос для получения бинарных данных из столбца "file_content" для выбранного id
                    string query = "SELECT file_content FROM public.books_tbl WHERE id = @Id";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedBookId);

                        // Получаем бинарные данные файла
                        byte[] fileContent = (byte[])command.ExecuteScalar();

                        // Создаем и открываем форму для просмотра PDF
                        ReadForm pdfViewerForm = new ReadForm(fileContent);
                        this.Hide();
                        pdfViewerForm.FormClosed += (s, args) => this.Close();
                        pdfViewerForm.Show();
                    }

                    connection.Close();
                }
            }
        }



        private void LoadDataIntoListBox()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
            SELECT 
                id as ""Код книги"",
                title as ""Название книги""
            FROM public.books_tbl";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Добавляем в ListBox объект с информацией о книге (название и id)
                                BookInfo bookInfo = new BookInfo
                                {
                                    Title = reader["Название книги"].ToString(),
                                    Id = Convert.ToInt32(reader["Код книги"])
                                };
                                listBox1.Items.Add(bookInfo);
                            }
                        }
                    }

                    connection.Close();
                }

                // Автоматически выбираем первый элемент в ListBox
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных из базы данных: " + ex.Message);
            }
        }
        // ...

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что в ListBox выбран элемент
            if (listBox1.SelectedItem != null)
            {
                // Получаем информацию о выбранной книге
                BookInfo selectedBook = (BookInfo)listBox1.SelectedItem;

                // Используем id выбранной книги для запроса дополнительной информации из БД
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                SELECT 
                    author as ""Автор"",
                    description as ""Описание"",
                    release_date as ""Дата релиза""
                FROM public.books_tbl
                WHERE id = @Id";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedBook.Id);

                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Выводим информацию об авторе и дате выхода в Label
                                    label2.Text = $"{reader["Автор"].ToString()}";
                                    // Отображаем только год, месяц и день
                                    DateTime releaseDate = Convert.ToDateTime(reader["Дата релиза"]);
                                    label4.Text = $"{releaseDate.ToString("yyyy-MM-dd")}";

                                    // Выводим описание в RichTextBox
                                    richTextBox1.Text = reader["Описание"].ToString();
                                }
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке дополнительных данных из базы данных: " + ex.Message);
                }
            }
        }
    }
}
