using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Explorer
{
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
            type.SelectedIndex = 0;
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBoxItem)type.SelectedItem).Content.ToString() == "File")
                labelName.Content = "File's name: ";
            else
                labelName.Content = "Folder's name: ";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text))
                MessageBox.Show("Name's field is empty!!!");
            else
                this.DialogResult = true;
        }
        public string GetData()
        {
            return name.Text + ";" + type.SelectedIndex.ToString();
        }
        public void Clear()
        {
            name.Text = "";
            type.SelectedIndex = 0;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
