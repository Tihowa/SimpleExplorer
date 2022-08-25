using Explorer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Explorer.Models
{
    public class TreeNode
    {
        public string Id { get; set; }
        public BitmapImage ImageSource { get; set; }
        public string Header { get; set; }
        public string FullName { get; set; }
        public TreeNode Parent { get; set; }
        public NodeType Type { get; set; }
        
        public List<TreeNode> Nodes { get; set; } = new();
    }
}
