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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Explorer.Models;
using System.Diagnostics;
using Explorer.Enums;

namespace Explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<ListItemView> viewItems = new();
        //private TreeNode Root = new TreeNode();
        private TreeNode Root = new();
        private DeleteDialog dialog = new DeleteDialog();

        private int paginationCount = 2;

        //public TreeViewItem Root { get; private set; } = new TreeViewItem();
        public MainWindow()
        {
            InitializeComponent();
            //foreach(var item in DriveInfo.GetDrives())
            //{
            //    mainList.Items.Add(new ListItemView {Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/drive.png")), Name = item.Name });
            //}
            //foreach(var item in DriveInfo.GetDrives())
            //{
            //    MakeTree(item.RootDirectory,Root);
            //}
            //mainTree.Items.Add(Root);
            //MakeTreeAsync(new DirectoryInfo(@"D:\"), Root);
            //TreeNode Root = new TreeNode();
            //mainTree.ItemsSource = Root.Nodes;
            //TreeAsync(new DirectoryInfo(@"D:\"), Root);
            mainTree.ItemsSource = Root.Nodes;
            //foreach (var item in DriveInfo.GetDrives())
            //{
            TreeNode node = new TreeNode { ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/drive.png")), Header = @"D:\", FullName = @"D:\" };
            Root.Nodes.Add(node);
            TreeAsync(new DriveInfo(@"D:\").RootDirectory, node);
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Anime");
            //    if(!String.IsNullOrEmpty(searchField.Text))
            //    {
            //        mainList.Items.Clear();
            //        DirectoryInfo directory = new DirectoryInfo(searchField.Text);

            //        foreach(var item in directory.GetDirectories())
            //        {
            //            mainList.Items.Add(new ListItemView { Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/directory.png")), Name = item.Name });

            //        }
            //        foreach (var item in directory.GetFiles())
            //        {
            //            mainList.Items.Add(new ListItemView { Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/document.png")), Name = item.Name });
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("String cannot be empty!!!");
            //    }
        }


        //private void mainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    searchField.Text += ((ListItemView)(((ListBox)sender).SelectedItem)).Name;
        //}
        public async Task TreeAsync(DirectoryInfo directory, TreeNode node)
        {
            try
            {
                if (paginationCount != 0)
                {
                    foreach (var item in directory.GetDirectories())
                    {
                        TreeNode nNode = new TreeNode
                        {
                            Id = Guid.NewGuid().ToString(),
                            ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/directory.png")),
                            Header = item.Name,
                            FullName = item.FullName,
                            Parent = node,
                            Type = NodeType.Directory
                        };
                        node.Nodes.Add(nNode);
                        paginationCount--;
                        await TreeAsync(item, nNode);
                    }
                    paginationCount++;
                    foreach (var item in directory.GetFiles())
                    {
                        TreeNode nNode = new TreeNode
                        {
                            Id = Guid.NewGuid().ToString(),
                            ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/file.png")),
                            Header = item.Name,
                            FullName = item.FullName,
                            Parent = node,
                            Type = NodeType.File
                        };
                        node.Nodes.Add(nNode);
                    }
                }

            }
            catch { }
        }
        //public async Task MakeTreeAsync(DirectoryInfo directory, TreeViewItem viewItem)
        //{
        //    foreach (var item in directory.GetDirectories())
        //    {
        //        TreeViewItem nItem = new TreeViewItem();
        //        nItem.Header = item.Name;
        //        viewItem.Items.Add(nItem);
        //        await MakeTreeAsync(item, nItem);
        //    }
        //    foreach (var item in directory.GetFiles())
        //    {
        //        TreeViewItem nItem = new TreeViewItem();
        //        nItem.Header = item.Name;
        //        viewItem.Items.Add(nItem);
        //    }
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //TreeNode root = new TreeNode();
            //mainTree.ItemsSource = root.Nodes;
            //TreeAsync(new DirectoryInfo(@"D:\Tikhon\Proga\Wpf\Explorer\Test"), root);
        }

        private void mainTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            TreeNode node = (TreeNode)mainTree.SelectedItem/*((TreeView)sender).SelectedItem*/;
            if (node.Header.Contains(".cs"))
            {
                groupBox1.Visibility = Visibility.Hidden;
                groupBox2.Visibility = Visibility.Visible;
                using (StreamReader reader = new StreamReader(node.FullName))
                {
                    csText.Text = reader.ReadToEnd();
                }
            }
            if (node.Header.Contains(".exe"))
            {
                Process.Start(node.FullName);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            groupBox1.Visibility = Visibility.Visible;
            groupBox2.Visibility = Visibility.Hidden;
            csText.Text = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TreeNode node = (TreeNode)mainTree.SelectedItem;
            dialog.SetLabelContent($"Delete {node.Header}?");
            if (dialog.ShowDialog() == true)
            {
                Task.Run(() =>
                {
                    node.Nodes.Clear();
                    if (node.Type == NodeType.File)
                        File.Delete(node.FullName);
                    else
                        //Directory.Delete(node.FullName);
                        DeleteFolder(new DirectoryInfo(node.FullName));
                    node.Parent.Nodes.Remove(node);
                    MessageBox.Show($"{node.Header} has been deleted");
                });
            }
            dialog.Close();
        }
        private void DeleteFolder(DirectoryInfo dir)
        {    
            foreach(var item in dir.GetDirectories())
            {
                DeleteFolder(item);
            }
            foreach (var item in dir.GetFiles())
            {
                File.Delete(item.FullName);
            }
            if (dir.GetDirectories().Length == 0 && dir.GetFiles().Length == 0)
            {
                Directory.Delete(dir.FullName);
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TreeNode node = (TreeNode)mainTree.SelectedItem;
            if(node.Type == NodeType.Directory)
            {
                DirInformation dirInformation = new DirInformation();
                DirectoryInfo info = new DirectoryInfo(node.FullName);
                double dirSize = 0.0;
                int dirCount = 0;
                int fileCount = 0;
                GetDirectorySizeAndCounts(info, ref dirSize, ref dirCount, ref fileCount);
                dirSize /= 1073741824;
                Math.Round(dirSize,2);
                dirInformation.Initialize("Папка с файлами", ((DirectoryInfo)info).FullName, dirSize.ToString(), $"Файлов: {fileCount}     Папок: {dirCount}", ((DirectoryInfo)info).CreationTime.ToString());
                dirInformation.ShowDialog();
            }
            else
            {
                FileInformation fileInformation = new FileInformation();
                FileInfo fileInfo = new FileInfo(node.FullName);
                double dirSize = fileInfo.Length;
                dirSize /= 1073741824;
                fileInformation.Initialize("Файл", fileInfo.FullName, dirSize.ToString(),fileInfo.CreationTime.ToString(),fileInfo.LastWriteTime.ToString(),"");
                fileInformation.ShowDialog();
            }
        }
        private void GetDirectorySizeAndCounts(DirectoryInfo dir,ref double size,ref int dirCount,ref int fileCount)
        {
            foreach(var item in dir.GetDirectories())
            {
                dirCount++;
                GetDirectorySizeAndCounts(item,ref size, ref dirCount, ref fileCount);
            }
            foreach(var item in dir.GetFiles())
            {
                fileCount++;
                size += item.Length;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Create createWindow = new Create();
            if(createWindow.ShowDialog() == true)
            {
                string[] data = createWindow.GetData().Split(';');
                TreeNode node = ((TreeNode)mainTree.SelectedItem);
                if (data[1] == "0")
                {
                    Directory.CreateDirectory(node.FullName + "\\" + data[0]);
                    TreeNode nNode = new TreeNode
                    {
                        Id = Guid.NewGuid().ToString(),
                        Header = data[0],
                        FullName = node.FullName + "\\" + data[0],
                        ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/directory.png")),
                        Type = NodeType.Directory,
                        Parent = node
                    };
                    node.Nodes.Add(nNode);
                }
                else
                {
                    File.Create(node.FullName + "\\" + data[0]);
                    TreeNode nNode = new TreeNode
                    {
                        Id = Guid.NewGuid().ToString(),
                        Header = data[0],
                        FullName = node.FullName + "\\" + data[0],
                        ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/../../../img/file.png")),
                        Type = NodeType.File,
                        Parent = node
                    };
                    node.Nodes.Add(nNode);
                }
            }
            createWindow.Clear();
        }

        //private TreeNode SearchNode(TreeNode parent,TreeNode child)
        //{
        //    if(parent.Nodes.FirstOrDefault(n=>n.Id == ))
        //    return null;
        //}

        //private bool DeleteNode(TreeNode node)
        //{
        //    return true;
        //}
    }
}
