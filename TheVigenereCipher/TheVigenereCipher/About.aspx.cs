using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Wordprocessing;

namespace TheVigenereCipher
{
    public partial class About : Page
    {
        public static string converted;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void textbox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void keybox_TextChanged(object sender, EventArgs e)
        {
            if (keybox.BorderColor == System.Drawing.Color.Red)
            {
                if (keybox.Text != null || keybox.Text != "")
                {
                    keybox.BorderColor = System.Drawing.Color.Empty;
                }
            }
        }
        protected void download_Click(object sender, EventArgs e)
        {            
            StringBuilder sb = new StringBuilder();

            if (fileUpload.HasFile)
            {
                try
                {
                    sb.AppendFormat(" Uploading file: {0}", fileUpload.FileName);

                    string pathToFile = System.Reflection.Assembly.GetExecutingAssembly().Location + fileUpload.FileName;

                    fileUpload.SaveAs(pathToFile);

                    //Showing the file information
                    sb.AppendFormat("\n Save As: {0}", fileUpload.PostedFile.FileName);
                    sb.AppendFormat("\n File type: {0}", fileUpload.PostedFile.ContentType);
                    sb.AppendFormat("\n File length: {0}", fileUpload.PostedFile.ContentLength);
                    sb.AppendFormat("\n File name: {0}", fileUpload.PostedFile.FileName);

                    if (fileUpload.PostedFile.ContentType.ToString().ToLower() == "text/plain")
                    {
                        textbox.Text = File.ReadAllText(pathToFile, Encoding.Default);
                    }
                    else if (fileUpload.PostedFile.ContentType.ToString().ToLower() == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || fileUpload.PostedFile.ContentType.ToString().ToLower() == "doc")
                    {
                        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                        object path = pathToFile;
                        Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path);
                        string text = "";                    

                        text = docs.Content.Text;

                        docs.Close();
                        word.Quit();

                        while (text[0] == ' ')
                        {
                            text.Remove(0, 1);
                        }

                        textbox.Text = text;
                    }
                    else
                    {
                        textbox.Text = fileUpload.PostedFile.ContentType.ToString().ToLower();
                    }

                }
                catch (Exception ex)
                {
                    sb.Append("\n Error \n");
                    sb.AppendFormat("Unable to save file \n {0}", ex.Message);
                    textbox.Text = sb.ToString();
                }
            }
            else
            {
                lblmessage.Text = sb.ToString();
            }
        }

        protected void calculate_Click(object sender, EventArgs e)
        {
            string message = textbox.Text;
            string key = keybox.Text;

            if (key == null || key == "")
            {
                keybox.BorderColor = System.Drawing.Color.Red;
            }
            else 
            {
                try
                {
                    if (encrypt.Checked)
                    {
                        converted = Encrypt(message, key);
                        convertedtext.Text = converted;
                    }
                    else
                    {
                        converted = Decrypt(message, key);
                        convertedtext.Text = converted;
                    }
                }
                catch (Exception)
                {

                }
               
            }            
        }

        public static string Encrypt(string message, string key) //зашифровать
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string encrypt = "";

            for (int i = 0; i < message.Length; i++)
            {
                int index = i % key.Length;
                encrypt += alphabet[(alphabet.IndexOf(message[i]) + alphabet.IndexOf(key[index])) % 33];
            }
            return encrypt;
        }
        public static string Decrypt(string message, string key) //расшифровать
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string decrypt = "";

            int count = 0;
            for (int i = 0; i < message.Length; i++)
            {
                try
                {
                    if (alphabet.IndexOf(message[i]) > -1)
                    {
                        int index = count % key.Length;
                        if (alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[index]) < 0)
                        {
                            decrypt += alphabet[33 + alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[index])];
                        }
                        else
                        {
                            decrypt += alphabet[alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[index])];
                        }
                        count++;
                    }
                    else
                    {
                        decrypt += message[i];
                    }
                }
                catch(Exception ex)
                {
                    var s = alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[count % key.Length]);
                }
            }
            return decrypt;
        }

        protected void decrypt_CheckedChanged(object sender, EventArgs e) //расшифровать
        {
            encrypt.Checked = !decrypt.Checked;
        }

        protected void encrypt_CheckedChanged(object sender, EventArgs e) //зашифровать
        {
            decrypt.Checked = !encrypt.Checked;
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string filepath = filePath.Text;
            //string filepath = System.Reflection.Assembly.GetExecutingAssembly().Location + "converted";

            try
            {
                if (doc_button.Checked)
                {
                    string path = filepath + ".doc";
                    File.WriteAllText(path, convertedtext.Text);
                }
                else
                {
                    string path = filepath + ".txt";
                    File.WriteAllText(path, convertedtext.Text);
                }
            }
            catch
            {
                filePath.BorderColor = System.Drawing.Color.Red;
            }
            
            
        }

        protected void txt_button_CheckedChanged(object sender, EventArgs e)
        {
            doc_button.Checked = !txt_button.Checked;
        }

        protected void doc_button_CheckedChanged(object sender, EventArgs e)
        {
            txt_button.Checked = !doc_button.Checked;
        }

        protected void filePath_TextChanged(object sender, EventArgs e)
        {
            if (filePath.BorderColor == System.Drawing.Color.Red)
            {
                filePath.BorderColor = System.Drawing.Color.Empty;
            }
        }
    }
}