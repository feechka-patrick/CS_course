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

        public static List<List<ThrowList>> dataThrows = new List<List<ThrowList>>();
        public static int current = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public static List<ThrowList> ExcelPackageToList(ExcelPackage excelPackage) //эксель в лист
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

        public static List<List<ThrowList>> ListToList() // заполнение листа листов
        {
            int dataCount = throws.Count / 20 ;
            
            int currentThrow = 0;
            for (int i = 0; i < dataCount; i++)
            {
                var s = new List<ThrowList>();
                for (int j = 0; j < 20; j++, currentThrow++)
                {
                    s.Add(throws[currentThrow]);
                }
                dataThrows.Add(s);
            }

            if (throws.Count % 20 != 0)
            {
                var s = new List<ThrowList>();
                for (int j = 0; currentThrow < throws.Count; j++, currentThrow++)
                {
                    s.Add(throws[currentThrow]);
                }
                dataThrows.Add(s);
            }
            return dataThrows;
        }
        private void Button_download_Click(object sender, RoutedEventArgs e) //загрузить
        {
           
            try
            {
                throws = ExcelPackageToList(new ExcelPackage(xlsx_file));
                dataThrows = ListToList();
                dataGrid.ItemsSource = dataThrows[0];
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
               folderName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xlsx_file.ToString());
               int index = folderName.LastIndexOf('\\');
               folderName = folderName.Remove(index);
               //textBox.Text = index + folderName;

               string path = folderName + "//new_thrlist.xlsx";
               //textBox.Text = path;

               new WebClient().DownloadFile(URLxlsx_file, path);
               

               List<ThrowList> _throws = new List<ThrowList>();
               _throws = ExcelPackageToList(new ExcelPackage(new FileInfo(@path)));
               int count = 0;
               string message_was = "БЫЛО: \n";
               string message_become = "СТАЛО: \n";

                if (throws.Count >= _throws.Count)
                {
                    for (int i = 0; i < throws.Count; i++)
                    {
                        bool change = false;
                        if (throws[i].Id == _throws[i].Id)
                        {
                            if (!Equals(throws[i].Name, _throws[i].Name))
                            {
                                change = true;
                            }
                            if (!Equals(throws[i].Description , _throws[i].Description))
                            {
                                change = true;
                            }
                            if (!Equals(throws[i].Source, _throws[i].Source))
                            {
                                change = true;
                            }
                            if (!Equals(throws[i].ObjectOfInfluence , _throws[i].ObjectOfInfluence))
                            {
                                change = true;
                            }
                            if (!Equals(throws[i].PrivacyPolicy , _throws[i].PrivacyPolicy))
                            {
                                change = true;
                            }
                            if (!Equals(throws[i].Integrity , _throws[i].Integrity))
                            {
                                change = true;
                            }
                            if (!Equals(throws[i].Availability , _throws[i].Availability))
                            {
                                change = true;
                            }
                        }

                        if (change)
                        {
                            count++;
                            message_was += throws[i].ToString() + '\n';
                            message_become += _throws[i].ToString() + '\n';
                        }

                    }
                }
               string message = $"Обнаружено {count} изменений\n";
               if (count != 0) 
               {
                    message += message_was + message_become;
               }

               MessageBox.Show(message, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
               throws = _throws;
               File.Delete(xlsx_file.ToString());
               File.Move(path, xlsx_file.ToString());
               dataThrows = ListToList();
               dataGrid.ItemsSource = dataThrows[current];
            }
            catch (Exception ex)
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
            if (dataGrid.SelectedIndex > 0)
            {
                MessageBox.Show(dataGrid.SelectedItem.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void button_download_test_Click(object sender, RoutedEventArgs e)
        {
            new WebClient().DownloadFile(URLxlsx_file, @"C:\Users\Аня\Downloads\\thrlist.xlsx");
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (current < dataThrows.Count - 1)
            {
                current++;
                dataGrid.ItemsSource = dataThrows[current];
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (current > 0)
            {
                current--;
                dataGrid.ItemsSource = dataThrows[current];
            }
        }
        private void enter_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
