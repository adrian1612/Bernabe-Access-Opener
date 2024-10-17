using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Bernabe_Access_Opener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitFolder();
            GetAllFile();
            treeView1.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Node.Tag as string))
            {
                Process.Start(e.Node.Tag as string);
            }
        }

        void GetAllFile()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("top", "Double Click to Run the Application");
            Directory.GetFiles("_System/").ToList().ForEach(r =>
            {
                FileInfo info = new FileInfo(r);
                treeView1.Nodes["top"].Nodes.Add(info.Name.Replace(info.Extension, "")).Tag = info.FullName;
            });
            treeView1.Nodes["top"].Expand();
        }

        void InitFolder()
        {
            if (!Directory.Exists("_System"))
            {
                Directory.CreateDirectory("_System").Attributes = FileAttributes.Hidden;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O && e.Control)
            {
                Process.Start("_System");
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                GetAllFile();
            }
        }
    }
}
