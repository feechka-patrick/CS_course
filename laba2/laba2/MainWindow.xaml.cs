using Microsoft.Win32;
using OfficeOpenXml;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string URLxlsx_file = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";

        public static List<ThrowList> throws = new List<ThrowList>();
        public static FileInfo xlsx_file;
        public static string folderName;
        public MainWindow()
        {
            InitializeComponent();
        }

        public static List<ThrowList> ExcelPackageToList(ExcelPackage excelPackage)
        {
            List<ThrowList> dt = new List<ThrowList>();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet"];
            try
            {
                if (worksheet.Dimension == null)
                {
                    return dt;
                }

                for (int i = 3; i <= worksheet.Dimension.End.Row; i++)
                {
                    ThrowList newThrow = new ThrowList();
                    newThrow.Id = worksheet.Cells[i, 1].Value.ToString();
                    newThrow.Name = worksheet.Cells[i, 2].Value.ToString();
                    newThrow.Description = worksheet.Cells[i, 3].Value.ToString();
                    newThrow.Source = worksheet.Cells[i, 4].Value.ToString();
                    newThrow.ObjectOfInfluence = worksheet.Cells[i, 5].Value.ToString();
                    newThrow.PrivacyPolicy = worksheet.Cells[i, 6].Value.ToString();
                    newThrow.Integrity = worksheet.Cells[i, 7].Value.ToString();
                    newThrow.Availability = worksheet.Cells[i, 8].Value.ToString();

                    dt.Add(newThrow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return dt;
            }
            return dt;
        }
        private void Button_download_Click(object sender, RoutedEventArgs e) //загрузить
        {
            try
            {                
                throws = ExcelPackageToList(new ExcelPackage(xlsx_file));
                dataGrid.ItemsSource = throws;
                dataGrid.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }

        private void Button_update_Click(object sender, RoutedEventArgs e)  //обновить
        {
            try
            {
                string path = folderName + "//new_thrlist.xlsx";
                new WebClient().DownloadFile(URLxlsx_file, path);

                List<ThrowList> _throws = new List<ThrowList>();
                _throws = ExcelPackageToList(new ExcelPackage(new FileInfo(@path)));

                var update = throws.Except(_throws);

               string message = "";
               foreach(var s in update)
                {
                    message += "\n" + s.ToString();
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
            }
        }

        private void Button_save_as_Click(object sender, RoutedEventArgs e) //сохранить как
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "(*.xlsx)|*.xlsx";

            if (dialog.ShowDialog() == true)
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    try
                    {
                    var new_xlsx_file = new FileInfo(dialog.FileName);
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet");

                        int j = 2;
                        ThrowList title_throw = new ThrowList();
                        worksheet.Cells[j, 1].Value = title_throw.Id;
                        worksheet.Cells[j, 2].Value = title_throw.Name;
                        worksheet.Cells[j, 3].Value = title_throw.Description;
                        worksheet.Cells[j, 4].Value = title_throw.Source;
                        worksheet.Cells[j, 5].Value = title_throw.ObjectOfInfluence;
                        worksheet.Cells[j, 6].Value = title_throw.PrivacyPolicy;
                        worksheet.Cells[j, 7].Value = title_throw.Integrity;
                        worksheet.Cells[j, 8].Value = title_throw.Availability;

                        int index = 0;
                    for (int i = 3; i < throws.Count; i++)
                    {
                        ThrowList _throw = throws[index];
                        worksheet.Cells[i, 1].Value = _throw.Id;
                        worksheet.Cells[i, 2].Value = _throw.Name;
                        worksheet.Cells[i, 3].Value = _throw.Description;
                        worksheet.Cells[i, 4].Value = _throw.Source;
                        worksheet.Cells[i, 5].Value = _throw.ObjectOfInfluence;
                        worksheet.Cells[i, 6].Value = _throw.PrivacyPolicy;
                        worksheet.Cells[i, 7].Value = _throw.Integrity;
                        worksheet.Cells[i, 8].Value = _throw.Availability;
                        index++;
                    }

                    
                        excelPackage.SaveAs(new_xlsx_file);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                       
            }
        }
        private void Button_save_Click(object sender, RoutedEventArgs e) // сохранить изменения
        {
            dataGrid.IsReadOnly = true;
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage(xlsx_file))
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet");
                    excelPackage.Save();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
      
       
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void enter_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_download_test_Click(object sender, RoutedEventArgs e)
        {
            new WebClient().DownloadFile(URLxlsx_file, @"C:\Users\Аня\Downloads\\thrlist.xlsx");
        }
    }
}
