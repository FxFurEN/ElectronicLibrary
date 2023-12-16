using System;
using System.Windows.Forms;
using Patagames.Pdf.Net.Controls.WinForms;

namespace ElectronicLibrary
{
    public partial class ReadForm : Form
    {
        private PdfViewer pdfViewer;

        public ReadForm()
        {
            InitializeComponent();
            InitializePdfViewer();
        }

        public ReadForm(byte[] fileContent)
        {
            InitializeComponent();
            InitializePdfViewer();

            // Загрузка PDF из байтов
            pdfViewer.LoadDocument(fileContent);
        }

        private void InitializePdfViewer()
        {
            // Создание экземпляра PdfViewer и добавление его на форму
            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            Controls.Add(pdfViewer);
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.FormClosed += (s, args) => this.Close();
            form.Show();
        }
    }
}
