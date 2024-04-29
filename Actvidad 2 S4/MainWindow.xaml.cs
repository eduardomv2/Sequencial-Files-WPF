using System;
using System.IO;
using System.Windows;

namespace SequentialFileOperations
{
    public partial class MainWindow : Window
    {
        // Ruta del archivo secuencial
        private const string filePath = "sequentialFile.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Evento para escribir en el archivo secuencial
        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene el texto del TextBox
            string textToWrite = txtInput.Text;

            // Abre el archivo en modo de anexar (append), y escribe el texto
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(textToWrite);
            }

            // Limpia el TextBox
            txtInput.Clear();

            txtOutput.Text = "Text written to file.";
        }

        // Evento para leer desde el archivo secuencial
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si el archivo existe
            if (File.Exists(filePath))
            {
                // Lee todo el contenido del archivo
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    txtOutput.Text = "File content:\n" + content;
                }
            }
            else
            {
                txtOutput.Text = "File does not exist.";
            }
        }

        // Evento para eliminar el archivo secuencial
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si el archivo existe
            if (File.Exists(filePath))
            {
                // Elimina el archivo
                File.Delete(filePath);
                txtOutput.Text = "File deleted.";
            }
            else
            {
                txtOutput.Text = "File does not exist.";
            }
        }
    }
}