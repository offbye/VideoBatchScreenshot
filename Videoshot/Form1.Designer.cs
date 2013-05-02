namespace Videoshot
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelProcessStatus = new System.Windows.Forms.Label();
            this.textBoxDisplaySize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonBatchShot = new System.Windows.Forms.Button();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.buttonShot = new System.Windows.Forms.Button();
            this.buttonSelectDir = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.buttonSelectSavePath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSelectSavePath);
            this.groupBox1.Controls.Add(this.labelProcessStatus);
            this.groupBox1.Controls.Add(this.textBoxDisplaySize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonBatchShot);
            this.groupBox1.Controls.Add(this.buttonSelectFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNum);
            this.groupBox1.Controls.Add(this.textBoxInterval);
            this.groupBox1.Controls.Add(this.textBoxStart);
            this.groupBox1.Controls.Add(this.buttonShot);
            this.groupBox1.Controls.Add(this.buttonSelectDir);
            this.groupBox1.Controls.Add(this.textBoxSavePath);
            this.groupBox1.Controls.Add(this.textBoxPath);
            this.groupBox1.Location = new System.Drawing.Point(28, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "视频批量截图";
            // 
            // labelProcessStatus
            // 
            this.labelProcessStatus.AutoSize = true;
            this.labelProcessStatus.Location = new System.Drawing.Point(12, 108);
            this.labelProcessStatus.Name = "labelProcessStatus";
            this.labelProcessStatus.Size = new System.Drawing.Size(53, 12);
            this.labelProcessStatus.TabIndex = 9;
            this.labelProcessStatus.Text = "处理状态";
            // 
            // textBoxDisplaySize
            // 
            this.textBoxDisplaySize.Location = new System.Drawing.Point(392, 77);
            this.textBoxDisplaySize.Name = "textBoxDisplaySize";
            this.textBoxDisplaySize.Size = new System.Drawing.Size(91, 21);
            this.textBoxDisplaySize.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "截图尺寸";
            // 
            // buttonBatchShot
            // 
            this.buttonBatchShot.Location = new System.Drawing.Point(575, 77);
            this.buttonBatchShot.Name = "buttonBatchShot";
            this.buttonBatchShot.Size = new System.Drawing.Size(75, 21);
            this.buttonBatchShot.TabIndex = 6;
            this.buttonBatchShot.Text = "批量截图";
            this.buttonBatchShot.UseVisualStyleBackColor = true;
            this.buttonBatchShot.Click += new System.EventHandler(this.buttonBatchShot_Click);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(576, 17);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 5;
            this.buttonSelectFile.Text = "选择文件";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "截图数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "间隔(秒)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "视频文件路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "截图时间点";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(298, 77);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(38, 21);
            this.textBoxNum.TabIndex = 3;
            this.textBoxNum.Text = "1";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(197, 77);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(41, 21);
            this.textBoxInterval.TabIndex = 3;
            this.textBoxInterval.Text = "100";
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(80, 77);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(59, 21);
            this.textBoxStart.TabIndex = 3;
            this.textBoxStart.Text = "10";
            // 
            // buttonShot
            // 
            this.buttonShot.Location = new System.Drawing.Point(493, 77);
            this.buttonShot.Name = "buttonShot";
            this.buttonShot.Size = new System.Drawing.Size(75, 21);
            this.buttonShot.TabIndex = 2;
            this.buttonShot.Text = "截图";
            this.buttonShot.UseVisualStyleBackColor = true;
            this.buttonShot.Click += new System.EventHandler(this.buttonShot_Click);
            // 
            // buttonSelectDir
            // 
            this.buttonSelectDir.Location = new System.Drawing.Point(492, 17);
            this.buttonSelectDir.Name = "buttonSelectDir";
            this.buttonSelectDir.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectDir.TabIndex = 1;
            this.buttonSelectDir.Text = "选择目录";
            this.buttonSelectDir.UseVisualStyleBackColor = true;
            this.buttonSelectDir.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(87, 20);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(396, 21);
            this.textBoxPath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(28, 189);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(189, 231);
            this.treeView1.TabIndex = 1;
            this.treeView1.Visible = false;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(87, 47);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(396, 21);
            this.textBoxSavePath.TabIndex = 0;
            // 
            // buttonSelectSavePath
            // 
            this.buttonSelectSavePath.Location = new System.Drawing.Point(493, 48);
            this.buttonSelectSavePath.Name = "buttonSelectSavePath";
            this.buttonSelectSavePath.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectSavePath.TabIndex = 10;
            this.buttonSelectSavePath.Text = "选择目录";
            this.buttonSelectSavePath.UseVisualStyleBackColor = true;
            this.buttonSelectSavePath.Click += new System.EventHandler(this.buttonSelectSavePath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "截图保存路径";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 476);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "批量截图工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSelectDir;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.Button buttonShot;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonBatchShot;
        private System.Windows.Forms.TextBox textBoxDisplaySize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelProcessStatus;
        private System.Windows.Forms.Button buttonSelectSavePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSavePath;
    }
}

