using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace VigenereCryptorCourse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CryptorMode currentMode = CryptorMode.Encrypt;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCryptedTextBox();
        }

        private void OriginalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCryptedTextBox();
        }

        private void DoWeEncrypt_Checked(object sender, RoutedEventArgs e)
        {
            currentMode = CryptorMode.Encrypt;
            UpdateCryptedTextBox();
        }

        private void DoWeDecrypt_Checked(object sender, RoutedEventArgs e)
        {
            currentMode = CryptorMode.Decrypt;
            UpdateCryptedTextBox();
        }

        public void UpdateCryptedTextBox()
        {
            if (!string.IsNullOrWhiteSpace(KeyTextBox.Text) && !string.IsNullOrWhiteSpace(OriginalTextBox.Text))
            {
                try
                {
                    CryptedTextBox.Text = VigenereCryptor.Crypt(OriginalTextBox.Text, KeyTextBox.Text, currentMode);
                }
                catch (FormatException a)
                {
                    CryptedTextBox.Text = a.Message;
                }
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                OriginalTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CryptedTextBox.Text))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, CryptedTextBox.Text);
                }
            }
            else
            {
                MessageBox.Show("А сохранять-то нечего!");
            }

        }
    }
}
