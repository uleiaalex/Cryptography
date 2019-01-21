using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            HashLabel.Visibility = Visibility.Hidden;
            comboBox1.Items.Add("MD5");
            comboBox1.Items.Add("RIPEMD160");
            comboBox1.Items.Add("SHA1");
            comboBox1.Items.Add("SHA256");
            comboBox1.Items.Add("SHA384");
            comboBox1.Items.Add("SHA512");
            comboBox1.SelectedIndex = 0;
            Update();
        }

        void Update()
        {
           // while(true)
            //{
                if (textBoxShowDirectorFile.Text == "")
                {
                    //selectFileDialogButton.ena
                }
           // }
        }

        public static string GetSHA1(string s)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        public static string GetSHA256(string s)
        {
            SHA256CryptoServiceProvider sh = new SHA256CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public static string GetSHA384(string s)
        {
            SHA384CryptoServiceProvider sh = new SHA384CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        public static string GetSHA512(string s)
        {
            SHA512CryptoServiceProvider sh = new SHA512CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public static string GetMD5(string s)
        {
            MD5CryptoServiceProvider sh = new MD5CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public static string GetRIPEMD160(string s)
        {
            RIPEMD160Managed sh = new RIPEMD160Managed();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        void ReadDataFromFile()
        {
            StreamReader dt = new StreamReader(textBoxShowDirectorFile.Text);
            string buffer;string t = "";
            while ((buffer = dt.ReadLine()) != null)
                t += buffer;
            inputBox.Text = t;
        }

        //Ready for async
        async Task ToHash()
        {
            string text = "";
            if (comboBox1.Text == "MD5")
            {
                text = inputBox.Text;
                textbox1.Text = (GetMD5(text));
            }
            else if (comboBox1.Text == "RIPEMD160")
            {
                text = inputBox.Text;
                textbox1.Text = (GetRIPEMD160(text));
            }
            else if (comboBox1.Text == "SHA1")
            {
                text = inputBox.Text;
                textbox1.Text = (GetSHA1(text));
            }
            else if (comboBox1.Text == "SHA256")
            {
                text = inputBox.Text;
                textbox1.Text = (GetSHA256(text));
            }
            else if (comboBox1.Text == "SHA384")
            {
                text = inputBox.Text;
                textbox1.Text = (GetSHA384(text));
            }
            else if (comboBox1.Text == "SHA512")
            {
                text = inputBox.Text;
                textbox1.Text = (GetSHA512(text));
            }
            HashLabel.Content = "Hashed";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HashLabel.Content = "Hashing";
            HashLabel.Visibility = Visibility.Visible;

            await ToHash(); //Async

        }

        async Task SFD()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "TXT Files (*.txt)|*.txt";



            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                textBoxShowDirectorFile.Text = filename;
                ReadDataFromFile();
            }
        }

        private async void SelectFileDialog(object sender, RoutedEventArgs e)
        {
            await SFD();
        }

        private void textBoxShowDirectorFile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
