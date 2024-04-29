using System;
using System.IO;
using System.Windows;

namespace SequentialFileOperations
{
    public partial class MainWindow : Window
    {
        // Path to the file
        private const string filePath = "sequentialFile.txt";

        public MainWindow()
        {
            InitializeComponent();
        }
        //Event to write in the sequential fil
        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            // Get the text to write
            string textToWrite = txtInput.Text;

            //Open the file in mode append, and write the text
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(textToWrite);
            }

            // Clear textbox
            txtInput.Clear();

            txtOutput.Text = "Text written to file.";
        }

        // Event to delete the file
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            // Verify if the file exists
            if (File.Exists(filePath))
            {
                // Read all text from the file
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

        // Event to delete the file
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Verify if the file exists
            if (File.Exists(filePath))
            {
                // Delete the file
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