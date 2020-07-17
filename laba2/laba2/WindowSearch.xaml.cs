using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba2
{
    /// <summary>
    /// Логика взаимодействия для WindowSearch.xaml
    /// </summary>
    public partial class WindowSearch : Window
    {
        string URLxlsx_file = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";

        public WindowSearch()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            folderBrowser.Description = "Выберете папку хранения базы";
            folderBrowser.ShowNewFolderButton = false;
            string folderName = "Адрес папки";

            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderName = folderBrowser.SelectedPath;
            }

            if (folderName != "Адрес папки" && folderName != "" && folderName != null)
            {
                string file = folderName + "\\thrlist.xlsx";
                new WebClient().DownloadFile(URLxlsx_file, file);

                MainWindow.xlsx_file = new FileInfo(@file);
                MainWindow.folderName = folderName;

                new MainWindow().Show();
                this.Close();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "(*.xlsx)|*.xlsx";
            dialog.ShowDialog();
            if (dialog.ShowDialog() == true)
            {
                MainWindow.xlsx_file = new FileInfo(@dialog.FileName);
            }
            if (MainWindow.xlsx_file != null)
            {
                string folderName = System.IO.Path.GetDirectoryName(MainWindow.xlsx_file.ToString());
                new MainWindow().Show();
                this.Close();
            }
                
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
