namespace ProjectWiseApp
{
    partial class PWSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveNCloseBt = new System.Windows.Forms.Button();
            this.ServerTb = new System.Windows.Forms.TextBox();
            this.DatasourceTb = new System.Windows.Forms.TextBox();
            this.DefaultBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current User:";
            // 
            // UserLb
            // 
            this.UserLb.AutoSize = true;
            this.UserLb.Location = new System.Drawing.Point(140, 21);
            this.UserLb.Name = "UserLb";
            this.UserLb.Size = new System.Drawing.Size(28, 13);
            this.UserLb.TabIndex = 1;
            this.UserLb.Text = "XXX";
            this.UserLb.Click += new System.EventHandler(this.UserLb_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ProjectWise Server:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ProjectWise Datasource:";
            // 
            // SaveNCloseBt
            // 
            this.SaveNCloseBt.Location = new System.Drawing.Point(39, 131);
            this.SaveNCloseBt.Name = "SaveNCloseBt";
            this.SaveNCloseBt.Size = new System.Drawing.Size(111, 23);
            this.SaveNCloseBt.TabIndex = 4;
            this.SaveNCloseBt.Text = "Save and Close";
            this.SaveNCloseBt.UseVisualStyleBackColor = true;
            this.SaveNCloseBt.Click += new System.EventHandler(this.SaveNCloseBt_Click);
            // 
            // ServerTb
            // 
            this.ServerTb.Location = new System.Drawing.Point(143, 48);
            this.ServerTb.Name = "ServerTb";
            this.ServerTb.Size = new System.Drawing.Size(164, 20);
            this.ServerTb.TabIndex = 5;
            // 
            // DatasourceTb
            // 
            this.DatasourceTb.Location = new System.Drawing.Point(143, 87);
            this.DatasourceTb.Name = "DatasourceTb";
            this.DatasourceTb.Size = new System.Drawing.Size(164, 20);
            this.DatasourceTb.TabIndex = 6;
            // 
            // DefaultBt
            // 
            this.DefaultBt.Location = new System.Drawing.Point(177, 131);
            this.DefaultBt.Name = "DefaultBt";
            this.DefaultBt.Size = new System.Drawing.Size(111, 23);
            this.DefaultBt.TabIndex = 7;
            this.DefaultBt.Text = "Set Default";
            this.DefaultBt.UseVisualStyleBackColor = true;
            this.DefaultBt.Click += new System.EventHandler(this.DefaultBt_Click);
            // 
            // PWSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 166);
            this.Controls.Add(this.DefaultBt);
            this.Controls.Add(this.DatasourceTb);
            this.Controls.Add(this.ServerTb);
            this.Controls.Add(this.SaveNCloseBt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserLb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PWSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PWSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveNCloseBt;
        private System.Windows.Forms.TextBox ServerTb;
        private System.Windows.Forms.TextBox DatasourceTb;
        private System.Windows.Forms.Button DefaultBt;
    }
}