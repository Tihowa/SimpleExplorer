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
    /// Логика взаимодействия для FileInformation.xaml
    /// </summary>
    public partial class FileInformation : Window
    {
        public FileInformation()
        {
            InitializeComponent();
        }
        public void Initialize(string type, string direction, string size, string createdDate, string editedDate,string openedDate)
        {
            this.type.Content = type;
            this.Direction.Content = direction;
            this.Size.Content = size;
            this.CreatedDate.Content = createdDate;
            this.OpenedDate.Content = openedDate;
            this.EditedDate.Content = editedDate;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.type.Content = "";
            this.Direction.Content = "";
            this.Size.Content = "";
            this.CreatedDate.Content = "";
            this.OpenedDate.Content = "";
            this.EditedDate.Content = "";
        }
    }
}
