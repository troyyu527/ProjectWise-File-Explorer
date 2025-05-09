using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWiseApp
{
    partial class PWExplorer
    {

        private void treeViewPW_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            Node nodeData = (Node)node.Tag; // Retrieve the Node object from Tag
            int projectId = nodeData.ProjectId;

            //MessageBox.Show($"Expanding ProjectId: {projectId}, Name: {node.Text}");

            // Always clear existing child nodes to prevent duplicates
            node.Nodes.Clear();

            var children = PWAPI.GetChildren(projectId);
            //MessageBox.Show($"Fetched {children.Count} children for ProjectId: {projectId}");

            foreach (var child in children)
            {
                string imageKey = child.IsDocument ? GetDocumentIconKey(Path.GetExtension(child.Name).ToLower()) : "folder";

                TreeNode childNode = new TreeNode(child.Name)
                {
                    Tag = child,
                    ImageKey = imageKey,
                    SelectedImageKey = imageKey // Use the same icon when selected
                };

                if (child.HasChildren && !child.IsDocument)
                {
                    childNode.Nodes.Add("Loading...");
                }

                node.Nodes.Add(childNode);
            }
        }
        private void GetInitialhierarchy()
        {
            var topLevelProjects = PWAPI.GetTopLevelProjects();
            foreach (var projectNode in topLevelProjects)
            {
                TreeNode treeNode = new TreeNode(projectNode.Name)
                {

                    Tag = projectNode,
                    ImageKey = "folder", // All top-level nodes are projects
                    SelectedImageKey = "folder"
                };

                // Debug: Check if the project has children
                //bool hasChildren = projectNode.HasChildren;
                //MessageBox.Show($"Project: {projectNode.Name}, HasChildren: {hasChildren}");

                if (projectNode.HasChildren)
                {
                    treeNode.Nodes.Add("Loading...");
                }

                treeViewPW.Nodes.Add(treeNode);
            }
        }
        private string GetDocumentIconKey(string extension)
        {
            // Map extensions to icon keys
            switch (extension)
            {
                case ".dwg":
                    return "dwg";
                case ".rvt":
                    return "rvt";
                case ".dgn":
                    return "dgn";
                case ".pdf":
                    return "pdf";
                default:
                    return "document"; // Default icon for unknown file types
            }
        }

        public bool IsValidFolderPath(string folderPath)
        {
            try
            {
                // Check for invalid characters
                var isPathValid = !string.IsNullOrWhiteSpace(folderPath) &&
                                  folderPath.IndexOfAny(Path.GetInvalidPathChars()) == -1;

                return isPathValid && Directory.Exists(folderPath);
            }
            catch
            {
                // Handles cases like path too long, etc.
                return false;
            }
        }
    }
}
