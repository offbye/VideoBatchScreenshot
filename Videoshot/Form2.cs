using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videoshot
{
    public partial class Form2 : Form
    {
        private string[] currentImages;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DriveInfo[] Drives = DriveInfo.GetDrives();//得到本机上所有驱动器
            TreeNode[] cRoot = new TreeNode[Drives.Length];
            //LocalView.ImageList = imageList1;
            foreach (DriveInfo di in Drives)
            {
                if (di.IsReady)//如果驱动器已经准备好，即驱动器可以使用，不是dvd，A:\等盘
                {
                    TreeNode DriveNode = new TreeNode(di.Name);
                    treeView1.Nodes.Add(DriveNode);
                    getSubNode(DriveNode, true);//得到子节点
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int i = 0;
            imageList1.Images.Clear();
            listView1.Items.Clear();
            if (Directory.Exists(e.Node.FullPath)) {

                DirectoryInfo curDir = new DirectoryInfo(e.Node.FullPath);
                FileInfo[] images = curDir.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
                currentImages = new string[images.Length];

                foreach (FileInfo f in images)
                {
                    currentImages[i] = f.FullName;
                    imageList1.Images.Add(Image.FromFile(f.FullName));

                    ListViewItem item = new ListViewItem(f.Name, i);
                    listView1.Items.Add(item);
                    listView1.LargeImageList = imageList1;
                    i++;
                }
            }
            
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)//点击treeview上的+号时触发
        {
            try
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if (Directory.Exists(tn.FullPath))//判断路径是否是一个目录，文件的话就不展开了
                    {
                        getSubNode(tn, true);
                      
                    }
                }
            }
            catch { ;}//错误未处理
        }


        private void getSubNode(TreeNode PathName, bool isEnd)
        {
            if (!isEnd)
                return; //退出
            TreeNode curNode;
            FileSystemInfo[] subDir = null;
            FileInfo[] subFiles = null;
            DirectoryInfo curDir = new DirectoryInfo(PathName.FullPath);
            try
            {
                subDir = curDir.GetFileSystemInfos();//目录下所有的文件和目录
                //subFiles = curDir.GetFiles();
                foreach (FileSystemInfo d in subDir)
                {
                    if (d.Attributes != (FileAttributes.Hidden | FileAttributes.System))//如果文件或者目录属性是隐藏和系统就不挂接到节点上
                    {
                        curNode = new TreeNode(d.Name);
                        PathName.Nodes.Add(curNode);
                        //getSubNode(curNode, false);
                        curNode.ImageIndex = 0;//treeview控件已经和一个imagelist控件关联了，所以可以加载imagelist内的一个图标
                    }

                }
            }
            catch (System.UnauthorizedAccessException e)//捕捉错误
            {
                
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0) {
                this.pictureBox1.ImageLocation = currentImages[this.listView1.SelectedItems[0].Index];
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                string destDir = this.textBox1.Text;
                String image = currentImages[this.listView1.SelectedItems[0].Index];
                FileInfo f = new FileInfo(image);
                if (Directory.Exists(destDir))
                {
                    File.Copy(image, destDir + "//" + f.Name);
                    MessageBox.Show("图片以及复制到:" + destDir + "//" + f.Name, "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else {
                    MessageBox.Show("目标文件夹不存在:" + destDir , "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "双击图片复制到的目标文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.textBox1.Text = foldPath;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
