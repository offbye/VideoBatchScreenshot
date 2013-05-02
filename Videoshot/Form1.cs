using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videoshot
{
    public partial class Form1 : Form
    {
        public const string FFMPEG = "D:\\Program Files\\FreeTime\\FormatFactory\\FFModules\\Encoder\\ffmpeg.exe ";
       // public const string FFARG = " -i {0}  -y -f image2  -ss {1} -vframes {2}   -loop  -s 400x300  {1}-%2d.jpg ";
        public const string FFARG = " -ss {1}  -i {0}  -y -f image2 -vframes 1 -an  {2}  {3}.jpg ";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择视频文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.textBoxPath.Text = foldPath;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSelectSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择保存截图路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.textBoxSavePath.Text = foldPath;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonShot_Click(object sender, EventArgs e)
        {
            mAll = 0;
            mRunning = 0;
            mFinished = 0;

            int startTime = 10;
            if (this.textBoxStart.Text.Trim().Equals(""))
            {

            }
            else if (IsInt(this.textBoxStart.Text.Trim()))
            {
                startTime = Convert.ToInt32(this.textBoxStart.Text.Trim());
            }
            else if (IsTime(this.textBoxStart.Text.Trim()))
            {
                startTime = TimeToSeconds(this.textBoxStart.Text.Trim());
            }
            else
            {
                MessageBox.Show("截图时间请按正确格式输入，请直接输入秒数或按HH:mm:ss格式输入", "截图时间输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string displaySize = "";
            if (this.textBoxDisplaySize.Text.Trim().Equals(""))
            {

            }
            else if (IsDisplay(this.textBoxDisplaySize.Text))
            {
                displaySize = " -s " + this.textBoxDisplaySize.Text;
            }
            else
            {
                MessageBox.Show("图片尺寸请按正确格式输入，例如720x480", "图片尺寸输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int num = 1;
            if (IsInt(this.textBoxNum.Text))
            {
                num = Convert.ToInt32(this.textBoxNum.Text.Trim());
            }
            else
            {
                MessageBox.Show("截图次数请输入数字", "输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int interval = 100;
            if (IsInt(this.textBoxInterval.Text))
            {
                interval = Convert.ToInt32(this.textBoxInterval.Text.Trim());
            }
            else
            {
                MessageBox.Show("截图次数请输入数字", "输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string savePath = "";            

            if (!this.textBoxSavePath.Text.Trim().Equals("")) {

                savePath = this.textBoxSavePath.Text.Trim();
            }

            String file = this.textBoxPath.Text.Trim();
            if (file.Equals("") || !File.Exists(file))
            {
                MessageBox.Show("文件输入错误", "输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                FileInfo fi = new FileInfo(file);
                string name =fi.Name;
                name = name.Substring(0,name.LastIndexOf("."));
                if (savePath.Equals(""))
                {
                    savePath = fi.DirectoryName + "\\" + name;
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    savePath = savePath + "\\" + name;
                }
                else {
                    savePath = savePath + "\\" + name;
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    savePath = savePath + "\\" + name;
                }

            }
           

            for (int i = 0; i < num; i++)
            {
                mAll += 1;
                mRunning += 1;
                extractImage(this.textBoxPath.Text.Trim(), startTime + i * interval, displaySize, savePath + "_" + i);
            }
            
        }
        private static int mAll;
        private static int mRunning;
        private static int mFinished;

        private void extractImage(string videoPath, int startTime, string size, string outFileName)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.CreateNoWindow = true;

            p.StartInfo.FileName = FFMPEG;//需要启动的程序名 
            p.StartInfo.Arguments = String.Format(FFARG, videoPath, startTime,size,outFileName);//启动参数
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardInput = true;
            //p.StartInfo.RedirectStandardOutput = true;

            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(myProcess_HasExited);

            p.Start();//启动 
            //string netMessage = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();
            //Console.Write(netMessage);
            //p.Close();

            if (p.HasExited)
            {
                p.Kill();
                //MessageBox.Show("已完成", "截图提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void myProcess_HasExited(object sender, System.EventArgs e)
        {
            Console.WriteLine("Process has exited."  );
            mFinished += 1;
            mRunning -= 1;
            labelProcessStatus.BeginInvoke(new InvokeDelegate(setStatus));
        }

        public delegate void InvokeDelegate();
        public void setStatus()
        {
            this.labelProcessStatus.Text = String.Format("截图总共{0}个，{1}个正在处理中，已经完成{2}个",mAll,mRunning,mFinished);
        }



        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                this.textBoxPath.Text = file;
                //MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //string[] Drives = Directory.GetLogicalDrives();
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

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)//点击treeview上的+号时触发
        {
            try
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if (Directory.Exists(tn.FullPath))//判断路径是否是一个目录，文件的话就不展开了
                        getSubNode(tn, true);
                }
            }
            catch { ;}//错误未处理
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

       
        private void buttonBatchShot_Click(object sender, EventArgs e)
        {
            int startTime = 10;
            if (this.textBoxStart.Text.Trim().Equals(""))
            {

            }
            else if (IsInt(this.textBoxStart.Text.Trim()))
            {
                startTime = Convert.ToInt32(this.textBoxStart.Text.Trim());
            }
            else if (IsTime(this.textBoxStart.Text.Trim()))
            {
                startTime = TimeToSeconds(this.textBoxStart.Text.Trim());
            }
            else
            {
                MessageBox.Show("截图时间请按正确格式输入，请直接输入秒数或按HH:mm:ss格式输入", "截图时间输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string displaySize = "";
            if (this.textBoxDisplaySize.Text.Trim().Equals(""))
            {

            }
            else if (IsDisplay(this.textBoxDisplaySize.Text))
            {
                displaySize = " -s " + this.textBoxDisplaySize.Text;
            }
            else
            {
                MessageBox.Show("图片尺寸请按正确格式输入，例如720x480", "图片尺寸输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int num = 1;
            if (IsInt(this.textBoxNum.Text))
            {
                num = Convert.ToInt32(this.textBoxNum.Text.Trim());
            }
            else
            {
                MessageBox.Show("截图次数请输入数字", "输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int interval = 100;
            if (IsInt(this.textBoxInterval.Text))
            {
                interval = Convert.ToInt32(this.textBoxInterval.Text.Trim());
            }
            else
            {
                MessageBox.Show("截图次数请输入数字", "输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string savePath = "";

            if (!this.textBoxSavePath.Text.Trim().Equals(""))
            {

                savePath = this.textBoxSavePath.Text.Trim();
            }


            if (this.textBoxPath.Text.Trim().Equals(""))
            {
                MessageBox.Show("请先选择视频所在目录", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DirectoryInfo di = new DirectoryInfo(this.textBoxPath.Text);
            if (di == null)
            {
                MessageBox.Show("视频所在目录不存在", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //init status
            mAll = 0;
            mRunning = 0;
            mFinished = 0;

            foreach (FileInfo file in di.GetFiles())
            {
                if (file != null)
                {                   
                    //Console.Write("\n" + file.Name);
                    sFiles.Add(file.FullName);
                    string name = file.Name;
                    name = name.Substring(0,name.LastIndexOf("."));
                    string directory = file.DirectoryName;
                    if (!savePath.Equals(""))
                    {
                        directory = savePath + "\\" + name;
                    }
                    else {
                        directory = directory + "\\" + name;
                    }
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    for (int i = 0; i < num; i++) {
                        mAll += 1;
                        mRunning += 1;
                        extractImage(file.FullName, startTime + i * interval, displaySize, directory + "\\" + name + "_" + i);
                    }
                   
                }
              
            }

        }

        List<String> sFiles = new List<String>();

         
        void ListDirectoriesAndFiles(FileSystemInfo[] FSInfo, string SearchString)
        {
            // Check the parameters.
            if (FSInfo == null)
            {
                throw new ArgumentNullException("FSInfo");
            }
            if (SearchString == null || SearchString.Length == 0)
            {
                throw new ArgumentNullException("SearchString");
            }

            // Iterate through each item.
            foreach (FileSystemInfo i in FSInfo)
            {
                // Check to see if this is a DirectoryInfo object.
                if (i is DirectoryInfo)
                {
                    // Add one to the directory count.
                    //directories++;

                    // Cast the object to a DirectoryInfo object.
                    DirectoryInfo dInfo = (DirectoryInfo)i;

                    // Iterate through all sub-directories.
                    ListDirectoriesAndFiles(dInfo.GetFileSystemInfos(SearchString), SearchString);
                }
                // Check to see if this is a FileInfo object.
                else if (i is FileInfo)
                {
                    // Add one to the file count.
                    //files++;
                  //  files.Add(i);

                }

            }
        }

        public static bool IsInt(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^[0-9]*$");
        }

        public static bool IsDisplay(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^[0-9]{2,4}[x,X][0-9]{2,4}$");
        }

        public static bool IsTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }

        public static int TimeToSeconds(string time)
        {
            String[] str = time.Split(':');
            return Convert.ToInt32(str[0]) * 3600 + Convert.ToInt32(str[1]) * 60 + Convert.ToInt32(str[0]);
        }


    }
}
