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

        private bool isFormOpening = false;
        // Укажите путь к вашему PDF-файлу
        string filePath = "C:/4 курс/курсачи/ElectronicLibrary/kapitanskaya-dochka.pdf";

        // Установите параметры подключения к базе данных
        private const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12300;Database=postgres";


        public Form1()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
        private void LoadDataIntoDataGridView()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Включите столбец "id" в запрос, чтобы он был доступен для использования в dataGridView1_CellDoubleClick
                    string query = @"
                SELECT 
                    id as ""Код книги"", 
                    title as ""Название книги"", 
                    author as ""Автор"", 
                    release_date as ""Дата релиза""
                FROM public.books_tbl";

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Books");

                        // Замените "dataGridView1" на имя вашего DataGridView
                        dataGridView1.DataSource = dataSet.Tables["Books"];
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных из базы данных: " + ex.Message);
            }
        }




        private bool isFormOpen = false; // Флаг для отслеживания открытости формы

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что двойной клик произошел по ячейке с содержимым PDF (например, по столбцу "Title" или "Author")
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Если форма уже открыта, выходим
                if (isFormOpen)
                {
                    return;
                }

                // Получаем значение столбца "id" для выбранной строки
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Код книги"].Value);

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Выполняем запрос для получения бинарных данных из столбца "file_content" для выбранного id
                    string query = "SELECT file_content FROM public.books_tbl WHERE id = @Id";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        // Получаем бинарные данные файла
                        byte[] fileContent = (byte[])command.ExecuteScalar();

                        // Создаем и открываем форму для просмотра PDF
                        ReadForm pdfViewerForm = new ReadForm(fileContent);
                        this.Hide();
                        pdfViewerForm.FormClosed += (s, args) =>
                        {
                            // Устанавливаем флаг в false при закрытии формы
                            isFormOpen = false;
                            this.Close();
                        };
                        pdfViewerForm.Show();

                        // Устанавливаем флаг в true при открытии формы
                        isFormOpen = true;
                    }

                    connection.Close();
                }
            }
        }



    }
}
