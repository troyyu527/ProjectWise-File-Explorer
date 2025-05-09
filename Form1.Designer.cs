namespace ProjectWiseApp
{
    partial class PWExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PWAPI.Logout(false);
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LoginBt = new System.Windows.Forms.Button();
            this.ExitBt = new System.Windows.Forms.Button();
            this.treeViewPW = new System.Windows.Forms.TreeView();
            this.imageList_icon = new System.Windows.Forms.ImageList(this.components);
            this.RefreshBt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserInputTb_Description = new System.Windows.Forms.TextBox();
            this.CreateFolderBt = new System.Windows.Forms.Button();
            this.UserInputTb_Name = new System.Windows.Forms.TextBox();
            this.DeleteFolderBt = new System.Windows.Forms.Button();
            this.ModifyFolderBt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UploadBt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UploadPathLb = new System.Windows.Forms.Label();
            this.UploadDirBt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadBt = new System.Windows.Forms.Button();
            this.DownloadPathLb = new System.Windows.Forms.Label();
            this.DownloadDirBt = new System.Windows.Forms.Button();
            this.DeleteDocumentBt = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.projectWiseSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBt
            // 
            this.LoginBt.Location = new System.Drawing.Point(40, 30);
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.Size = new System.Drawing.Size(114, 50);
            this.LoginBt.TabIndex = 0;
            this.LoginBt.Text = "Login";
            this.LoginBt.UseVisualStyleBackColor = true;
            this.LoginBt.Click += new System.EventHandler(this.LoginBt_Click);
            // 
            // ExitBt
            // 
            this.ExitBt.Location = new System.Drawing.Point(278, 30);
            this.ExitBt.Name = "ExitBt";
            this.ExitBt.Size = new System.Drawing.Size(64, 50);
            this.ExitBt.TabIndex = 1;
            this.ExitBt.Text = "Logout";
            this.ExitBt.UseVisualStyleBackColor = true;
            this.ExitBt.Click += new System.EventHandler(this.ExitBt_Click);
            // 
            // treeViewPW
            // 
            this.treeViewPW.FullRowSelect = true;
            this.treeViewPW.ImageIndex = 0;
            this.treeViewPW.ImageList = this.imageList_icon;
            this.treeViewPW.Location = new System.Drawing.Point(40, 95);
            this.treeViewPW.Name = "treeViewPW";
            this.treeViewPW.SelectedImageIndex = 0;
            this.treeViewPW.Size = new System.Drawing.Size(302, 360);
            this.treeViewPW.TabIndex = 3;
            // 
            // imageList_icon
            // 
            this.imageList_icon.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_icon.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_icon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // RefreshBt
            // 
            this.RefreshBt.Location = new System.Drawing.Point(173, 30);
            this.RefreshBt.Name = "RefreshBt";
            this.RefreshBt.Size = new System.Drawing.Size(81, 50);
            this.RefreshBt.TabIndex = 4;
            this.RefreshBt.Text = "Refresh";
            this.RefreshBt.UseVisualStyleBackColor = true;
            this.RefreshBt.Click += new System.EventHandler(this.RefreshBt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.UserInputTb_Description);
            this.groupBox2.Controls.Add(this.CreateFolderBt);
            this.groupBox2.Controls.Add(this.UserInputTb_Name);
            this.groupBox2.Location = new System.Drawing.Point(378, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 117);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Sub Folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Desc.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // UserInputTb_Description
            // 
            this.UserInputTb_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.UserInputTb_Description.Location = new System.Drawing.Point(50, 57);
            this.UserInputTb_Description.Name = "UserInputTb_Description";
            this.UserInputTb_Description.Size = new System.Drawing.Size(160, 20);
            this.UserInputTb_Description.TabIndex = 2;
            // 
            // CreateFolderBt
            // 
            this.CreateFolderBt.Location = new System.Drawing.Point(67, 83);
            this.CreateFolderBt.Name = "CreateFolderBt";
            this.CreateFolderBt.Size = new System.Drawing.Size(75, 28);
            this.CreateFolderBt.TabIndex = 1;
            this.CreateFolderBt.Text = "Create";
            this.CreateFolderBt.UseVisualStyleBackColor = true;
            this.CreateFolderBt.Click += new System.EventHandler(this.CreateFolderBt_Click);
            // 
            // UserInputTb_Name
            // 
            this.UserInputTb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.UserInputTb_Name.Location = new System.Drawing.Point(50, 19);
            this.UserInputTb_Name.Name = "UserInputTb_Name";
            this.UserInputTb_Name.Size = new System.Drawing.Size(160, 20);
            this.UserInputTb_Name.TabIndex = 0;
            // 
            // DeleteFolderBt
            // 
            this.DeleteFolderBt.Location = new System.Drawing.Point(606, 383);
            this.DeleteFolderBt.Name = "DeleteFolderBt";
            this.DeleteFolderBt.Size = new System.Drawing.Size(99, 30);
            this.DeleteFolderBt.TabIndex = 6;
            this.DeleteFolderBt.Text = "Delete Folder";
            this.DeleteFolderBt.UseVisualStyleBackColor = true;
            this.DeleteFolderBt.Click += new System.EventHandler(this.DeleteFolderBt_Click);
            // 
            // ModifyFolderBt
            // 
            this.ModifyFolderBt.Location = new System.Drawing.Point(606, 347);
            this.ModifyFolderBt.Name = "ModifyFolderBt";
            this.ModifyFolderBt.Size = new System.Drawing.Size(99, 30);
            this.ModifyFolderBt.TabIndex = 7;
            this.ModifyFolderBt.Text = "Modify Folder";
            this.ModifyFolderBt.UseVisualStyleBackColor = true;
            this.ModifyFolderBt.Click += new System.EventHandler(this.ModifyFolderBt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UploadBt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.UploadPathLb);
            this.groupBox1.Controls.Add(this.UploadDirBt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DownloadBt);
            this.groupBox1.Controls.Add(this.DownloadPathLb);
            this.groupBox1.Controls.Add(this.DownloadDirBt);
            this.groupBox1.Location = new System.Drawing.Point(378, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 302);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download/Upload Document";
            // 
            // UploadBt
            // 
            this.UploadBt.Location = new System.Drawing.Point(119, 273);
            this.UploadBt.Name = "UploadBt";
            this.UploadBt.Size = new System.Drawing.Size(97, 23);
            this.UploadBt.TabIndex = 7;
            this.UploadBt.Text = "Upload";
            this.UploadBt.UseVisualStyleBackColor = true;
            this.UploadBt.Click += new System.EventHandler(this.UploadBt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Upload from";
            // 
            // UploadPathLb
            // 
            this.UploadPathLb.AutoSize = true;
            this.UploadPathLb.Location = new System.Drawing.Point(6, 185);
            this.UploadPathLb.MaximumSize = new System.Drawing.Size(270, 85);
            this.UploadPathLb.Name = "UploadPathLb";
            this.UploadPathLb.Size = new System.Drawing.Size(66, 13);
            this.UploadPathLb.TabIndex = 5;
            this.UploadPathLb.Text = "Upload Path";
            // 
            // UploadDirBt
            // 
            this.UploadDirBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadDirBt.Location = new System.Drawing.Point(289, 179);
            this.UploadDirBt.Name = "UploadDirBt";
            this.UploadDirBt.Size = new System.Drawing.Size(32, 23);
            this.UploadDirBt.TabIndex = 4;
            this.UploadDirBt.Text = "...";
            this.UploadDirBt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UploadDirBt.UseVisualStyleBackColor = true;
            this.UploadDirBt.Click += new System.EventHandler(this.UploadDirBt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Download to";
            // 
            // DownloadBt
            // 
            this.DownloadBt.Location = new System.Drawing.Point(119, 128);
            this.DownloadBt.Name = "DownloadBt";
            this.DownloadBt.Size = new System.Drawing.Size(97, 23);
            this.DownloadBt.TabIndex = 2;
            this.DownloadBt.Text = "Download";
            this.DownloadBt.UseVisualStyleBackColor = true;
            this.DownloadBt.Click += new System.EventHandler(this.DownloadBt_Click);
            // 
            // DownloadPathLb
            // 
            this.DownloadPathLb.AutoSize = true;
            this.DownloadPathLb.Location = new System.Drawing.Point(6, 42);
            this.DownloadPathLb.MaximumSize = new System.Drawing.Size(270, 85);
            this.DownloadPathLb.Name = "DownloadPathLb";
            this.DownloadPathLb.Size = new System.Drawing.Size(80, 13);
            this.DownloadPathLb.TabIndex = 1;
            this.DownloadPathLb.Text = "Download Path";
            // 
            // DownloadDirBt
            // 
            this.DownloadDirBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadDirBt.Location = new System.Drawing.Point(289, 36);
            this.DownloadDirBt.Name = "DownloadDirBt";
            this.DownloadDirBt.Size = new System.Drawing.Size(32, 23);
            this.DownloadDirBt.TabIndex = 0;
            this.DownloadDirBt.Text = "...";
            this.DownloadDirBt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DownloadDirBt.UseVisualStyleBackColor = true;
            this.DownloadDirBt.Click += new System.EventHandler(this.DownloadDirBt_Click);
            // 
            // DeleteDocumentBt
            // 
            this.DeleteDocumentBt.Location = new System.Drawing.Point(606, 421);
            this.DeleteDocumentBt.Name = "DeleteDocumentBt";
            this.DeleteDocumentBt.Size = new System.Drawing.Size(99, 28);
            this.DeleteDocumentBt.TabIndex = 9;
            this.DeleteDocumentBt.Text = "Delete Document";
            this.DeleteDocumentBt.UseVisualStyleBackColor = true;
            this.DeleteDocumentBt.Click += new System.EventHandler(this.DeleteDocumentBt_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.projectWiseSettingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // projectWiseSettingToolStripMenuItem
            // 
            this.projectWiseSettingToolStripMenuItem.Name = "projectWiseSettingToolStripMenuItem";
            this.projectWiseSettingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.projectWiseSettingToolStripMenuItem.Text = "ProjectWise Setting";
            this.projectWiseSettingToolStripMenuItem.Click += new System.EventHandler(this.projectWiseSettingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // PWExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 486);
            this.Controls.Add(this.DeleteDocumentBt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ModifyFolderBt);
            this.Controls.Add(this.DeleteFolderBt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RefreshBt);
            this.Controls.Add(this.treeViewPW);
            this.Controls.Add(this.ExitBt);
            this.Controls.Add(this.LoginBt);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PWExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectWise File Explorer";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginBt;
        private System.Windows.Forms.Button ExitBt;
        private System.Windows.Forms.TreeView treeViewPW;
        private System.Windows.Forms.ImageList imageList_icon;
        private System.Windows.Forms.Button RefreshBt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CreateFolderBt;
        private System.Windows.Forms.TextBox UserInputTb_Name;
        private System.Windows.Forms.Button DeleteFolderBt;
        private System.Windows.Forms.Button ModifyFolderBt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DownloadPathLb;
        private System.Windows.Forms.Button DownloadDirBt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownloadBt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UploadPathLb;
        private System.Windows.Forms.Button UploadDirBt;
        private System.Windows.Forms.Button UploadBt;
        private System.Windows.Forms.TextBox UserInputTb_Description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteDocumentBt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectWiseSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

