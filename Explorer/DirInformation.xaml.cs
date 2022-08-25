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
    /// Логика взаимодействия для DirInformation.xaml
    /// </summary>
    public partial class DirInformation : Window
    {
        public DirInformation()
        {
            InitializeComponent();
        }
        public void Initialize(string type,string direction,string size,string contains,string createdDate)
        {
            this.type.Content = type;
            this.Direction.Content = direction;
            this.Size.Content = size;
            this.Contains.Content = contains;
            this.CreatedDate.Content = createdDate;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.type.Content = "";
            this.Direction.Content = "";
            this.Size.Content = "";
            this.Contains.Content = "";
            this.CreatedDate.Content = "";
        }
    }
}
