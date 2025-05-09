using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Bentley.Connect.Client.API.V1;
using Bentley.Connect.Client.API.V1.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ProjectWiseApp
{
    public partial class PWExplorer : Form
    {
        public PWExplorer()
        {
            InitializeComponent();

            
            //Add plus sign event to the treeview
            treeViewPW.BeforeExpand += treeViewPW_BeforeExpand;
            this.Controls.Add(treeViewPW);

            // Add icons to the ImageList (in a real application, load these from resources or files)
            //imageList_icon.Images.Add("folder", SystemIcons.WinLogo); // Placeholder for folder icon
            imageList_icon.Images.Add("dwg", FileIconHelper.GetFileIcon(".dwg")); 
            imageList_icon.Images.Add("rvt", FileIconHelper.GetFileIcon(".rvt")); 
            imageList_icon.Images.Add("pdf", FileIconHelper.GetFileIcon(".pdf")); 
            imageList_icon.Images.Add("dgn", FileIconHelper.GetFileIcon(".dgn")); 
            imageList_icon.Images.Add("document", FileIconHelper.GetFileIcon(".txt"));
            imageList_icon.Images.Add("folder", FileIconHelper.GetFolderIcon());

            DownloadPathLb.Text = "Select a folder Path";
            UploadPathLb.Text = "Select a File Path";
        }
     
   
        private void LoginBt_Click(object sender, EventArgs e)
        {
            LoginBt.Text = "Logging in...";
            LoginBt.Enabled = false;
            string server = Properties.Settings.Default.Server;
            string datasource = Properties.Settings.Default.Datasource;
            string DataName = server+":"+datasource;
            PWAPI.Initialize();
            string user = PWAPI.GetCurrentUsername();
            //MessageBox.Show("Current user: " + user);
            //PWAPI.PrintAvailableDatasources();
            
            if (PWAPI.LoginIMS(DataName))
            {
                treeViewPW.Nodes.Clear();
                GetInitialhierarchy();
                LoginBt.Text = "Connecting...";
            }
            else
            {
                LoginBt.Text = "Login";
                LoginBt.Enabled = true;
            }
                

        }
        

        private void ExitBt_Click(object sender, EventArgs e)
        {
            PWAPI.Logout();
            treeViewPW.Nodes.Clear();
            LoginBt.Enabled = true;
            LoginBt.Text = "Login";
        }

        private void RefreshBt_Click(object sender, EventArgs e)
        {
            treeViewPW.Nodes.Clear();
            GetInitialhierarchy();
        }

        private void UploadDirBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //If OpenFileDialog is added from toolbox, this line can be ignored. 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                // Perform upload operation here
                UploadPathLb.Text = filePath;
                //MessageBox.Show($"Selected file: {filePath}");
            }
        }

        private void DownloadDirBt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                // Perform download operation here
                DownloadPathLb.Text = folderPath;
                //MessageBox.Show($"Selected folder: {folderPath}");
            }
        }

        private void ModifyFolderBt_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewPW.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a project to modify.");
                return;
            }
            // Check if the selected node is a project (not a document) 
            Node nodeData = (Node)selectedNode.Tag;
            if (nodeData.IsDocument)
            {
                MessageBox.Show("Cannot modify a document. Please select a project.");
                return;
            }
            int projectId = nodeData.ProjectId;
            string newName = UserInputTb_Name.Text.Trim();
            string newDesc = UserInputTb_Description.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Please enter a new project name.");
                return;
            }
            bool bRetVal = PWAPI.ModifyProject(projectId, newName, newDesc);
            if (bRetVal)
            {
                nodeData.Name = newName; // Update the TreeView with the new name
                selectedNode.Text = newName;
                //MessageBox.Show($"Project {projectId} modified successfully with name: {newName}, description: {newDesc}");
            }
            else
            {
                MessageBox.Show($"Failed to modify project {projectId}. Error: {PWAPI.GetLastErrorDetail()}");
            }
        }

        private void CreateFolderBt_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewPW.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a parent project to create a subfolder under.");
                return;
            }

            // Check if the selected node is a project (not a document) 
            Node nodeData = (Node)selectedNode.Tag;
            if (nodeData.IsDocument)
            {
                MessageBox.Show("Cannot modify a document. Please select a project.");
                return;
            }

            int parentId = nodeData.ProjectId;
            string newName = UserInputTb_Name.Text.Trim();
            string newDesc = UserInputTb_Description.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Please enter a name for the new subfolder.");
                return;
            }

            int createdVaultId = 0;
            bool bRetVal = PWAPI.CreateSubProject(ref createdVaultId, parentId, newName, newDesc);
            if (bRetVal)
            {
                Node newNodeData = new Node
                {
                    Name = newName,
                    ProjectId = createdVaultId,
                    IsDocument = false,
                    HasChildren = false // Initially no children, will be updated on expand
                };

                TreeNode newNode = new TreeNode(newName)
                {
                    Tag = newNodeData,
                    ImageKey = "folder",
                    SelectedImageKey = "folder"
                };

                int docCount = PWAPI.SelectDocumentsByProjectId(createdVaultId);
                bool hasChildren = (docCount > 0);
                if (hasChildren)
                {
                    newNode.Nodes.Add("Loading...");
                }

                selectedNode.Nodes.Add(newNode);
                selectedNode.Expand();
            }
            else
            {
                MessageBox.Show($"Failed to create subfolder. Error: {PWAPI.GetLastErrorDetail()}");
            }
        }

        private void DeleteFolderBt_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewPW.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a project to delete.");
                return;
            }


            Node nodeData = (Node)selectedNode.Tag;
            if (nodeData.IsDocument)
            {
                MessageBox.Show("Cannot delete a document. Please select a project.");
                return;
            }
            DeleteFolderBt.Text = "Deleting...";
            DeleteFolderBt.Enabled = false;
            int projectId = nodeData.ProjectId;
            long lCount = 0;
            bool bRetVal = PWAPI.DeleteProject(projectId, ref lCount);
            if (bRetVal)
            {
                //string strMsg = $"You deleted {lCount} projects.";
                //MessageBox.Show(strMsg);
                treeViewPW.Nodes.Remove(selectedNode);
            }
            else
            {
                string strError = PWAPI.GetLastErrorDetail();
                MessageBox.Show(strError);
            }
            DeleteFolderBt.Text = "Delete Folder";
            DeleteFolderBt.Enabled = true;
        }

        private void DeleteDocumentBt_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewPW.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a document to delete.");
                return;
            }

            Node nodeData = (Node)selectedNode.Tag;
            if (!nodeData.IsDocument)
            {
                MessageBox.Show("Cannot delete a project. Please select a document.");
                return;
            }
            DeleteDocumentBt.Text = "Deleting...";
            DeleteDocumentBt.Enabled = false;
            int projectId = nodeData.ProjectId;
            int documentId = nodeData.ObjectId;
            bool bRetVal = PWAPI.DeleteDocument(projectId, documentId);

            if (bRetVal)
            {
                //MessageBox.Show($"Document {selectedItem.Name} deleted successfully.");
                treeViewPW.Nodes.Remove(selectedNode);
            }
            else
            {
                string strError = PWAPI.GetLastErrorDetail();
                MessageBox.Show($"Failed to delete document. Error: {strError}");
            }
            DeleteDocumentBt.Text = "Delete Document";
            DeleteDocumentBt.Enabled = true;
        }

        private void DownloadBt_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewPW.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a document to download.");
                return;
            }
            Node nodeData = (Node)selectedNode.Tag;
            if (!nodeData.IsDocument)
            {
                MessageBox.Show("Cannot download a project. Please select a document.");
                return;
            }
            string savedPath = DownloadPathLb.Text;
            if (!IsValidFolderPath(savedPath))
            {
                MessageBox.Show("Please select a valid folder path to save the document.");
                return;
            }
            DownloadBt.Text = "Downloading...";
            DownloadBt.Enabled = false;
            string documentName = nodeData.Name;
            int projectId = nodeData.ProjectId;
            int documentId = nodeData.ObjectId;
            
            
            bool bRetVal = PWAPI.DownloadDocument(projectId, documentId, savedPath);
            DownloadBt.Enabled = true;
            DownloadBt.Text = "Download";
            if (bRetVal)
            {
                MessageBox.Show($"Document {documentName} downloaded successfully to {savedPath}.");
            }
            else
            {
                string strError = PWAPI.GetLastErrorDetail();
                MessageBox.Show($"Failed to download document. Error: {strError}");
            }
            
        }
        
        private void UploadBt_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewPW.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a project to upload the document to.");
                return;
            }

            Node nodeData = (Node)selectedNode.Tag;
            if (nodeData.IsDocument)
            {
                MessageBox.Show("Cannot upload to a document. Please select a project.");
                return;
            }

            int projectId = nodeData.ProjectId;

            // Use the file path from UploadPathLb (set by UploadDirBt_Click)
            string localFilePath = UploadPathLb.Text;
            if (string.IsNullOrEmpty(localFilePath) || !File.Exists(localFilePath))
            {
                MessageBox.Show("Please select a valid file to upload.");
                return;
            }
            UploadBt.Text = "Uploading...";
            UploadBt.Enabled = false;
            string documentName = Path.GetFileName(localFilePath);
            string documentDesc = $"Uploaded document: {documentName}";
            int newDocumentId = 0;
            
            bool bRetVal = PWAPI.CreateDocument(projectId, ref newDocumentId ,localFilePath, documentName, documentDesc);
            UploadBt.Enabled = true;
            UploadBt.Text = "Upload";
            if (bRetVal)
            {
                // Add the new document to the TreeView
                string imageKey = GetDocumentIconKey(Path.GetExtension(documentName).ToLower());
                Node newDocNodeData = new Node
                {
                    Name = documentName,
                    IsDocument = true,
                    HasChildren = false,
                    ProjectId = projectId,
                    ObjectId = newDocumentId
                };

                TreeNode newDocNode = new TreeNode(documentName)
                {
                    Tag = newDocNodeData,
                    ImageKey = imageKey,
                    SelectedImageKey = imageKey
                };

                selectedNode.Nodes.Add(newDocNode);
                selectedNode.Expand();
                
                MessageBox.Show($"Document {documentName} uploaded successfully with ID: {newDocumentId}.");
            }
            else
            {
                string strError = PWAPI.GetLastErrorDetail();
                MessageBox.Show($"Failed to upload document. Error: {strError}");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PWAPI.Logout(false);
            this.Close();
        }

        private void projectWiseSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PWSetting settingForm = new PWSetting();
            settingForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "About\n\n" +
                "Author: Troy Yu\n" +
                "Email: troy.yu@aecom.com\n\n" +
                "This software can be shared and used for educational purposes only.\n" +
                "Commercial use or marketing is not allowed.\n\n" +
                "Copyright © AECOM",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
    
    
    


    
}
