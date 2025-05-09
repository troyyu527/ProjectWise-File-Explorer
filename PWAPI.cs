using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWiseApp
{
    public static class PWAPI
    {

        
        

        //Api Flags
        [Flags]
        public enum DocumentCopyFlags : uint
        {
            AADMS_DOCCOPY_CAN_OVERWRITE = 0x00000001,
            AADMS_DOCCOPY_ATTRS = 0x00000002,
            AADMS_DOCCOPY_NO_ATTRS = 0x00000004, /* attr copy denied      */
            AADMS_DOCCOPY_NO_SETITEM = 0x00000008, /* no set item for master*/
            AADMS_DOCCOPY_MOVE = 0x00000010,  /* move operation        */
            AADMS_DOCCOPY_NOFILE = 0x00000020, /* do not copy file      */
            AADMS_DOCCOPY_NO_HOOKS = 0x00010000, /* dont call pre/post hooks */
            AADMS_DOCCOPY_LOG_MOVE = 0x00020000, /* log audit trail move action */
            AADMS_DOCCOPY_INCLUDE_VERSIONS = 0x00040000, /* move versions if there are any */
            AADMS_DOCCOPY_COPY_ACCESS = 0x00080000, /* copy document access */
            AADMS_DOCCOPY_MOVE_NO_VERSIONS = 0x00100000, /* used with MOVE flag - versions will not be moved */
            AADMS_DOCCOPY_COPY_CONFBLOCKS = 0x00200000, /* copy Managed Workspace Profiles ConfBlock assignments */
            AADMS_DOCCOPY_COPYVERSIONSTR = 0x00400000 /* copy version string */
        }
        [Flags]
        public enum DocumentCreationFlag : uint
        {
            Default = 0x00000000,
            NoAttributeRecord = 0x00000001,
            CreateAttributeRecord = 0x00000002,
            NoAuditTrail = 0x00000004
        }
        [Flags]
        public enum FetchDocumentFlags : uint
        {
            CheckOut = 0x00000000,
            Export = 0x00000001,
            CopyOut = 0x00000002,
            Refresh = 0x00000004,
            Lock = 0x00000008,
            UseUpToDateCopy = 0x00000010,
            AcceptCheckouts = 0x00000020,
            CopyOutMasters = 0x00000040,
            AsSetMembers = 0x00001000,
            ExportReferences = 0x00002000,
            ChangeSetId = 0x00004000,
            UseVaultDirs = 0x00008000,
            IgnoreMasters = 0x00010000,
            GiveOut = 0x00020000,
            MarkAsView = 0x00040000,
            View = 0x00080000,
            NoAuditTrail = 0x00080000,
            AddToMRU = 0x00100000,
            IgnoreExport = 0x00400000,
            DO_NOT_CHANGE_SET_ID_FOR_CHECKED_OUT_REFERENCES = 0x00200000,
            SHARED_CHECKOUT = 0x01000000,
            MASTER_AS_SET = 0x10000000,
            IGNORE_REDLINE_REL = 0x20000000,
            NESTED_REFERENCES = 0x40000000,
            REDLINED_REFERENCES = 0x80000000,
            SEND_TO_FOLDER = 0x00020100,
            SHARED_EXPORT = 0x01000001
        }
        public enum VaultType : int
        {
            Normal = 0,
            Workspace = 1
        }

        public enum DocumentType : int
        {
            Normal = 10,
            History = 11,
            Set = 12,
            Redline = 13,
            ModelerBRP = 14,
            Abstract = 15,
            Unknown = 0
        }
        public enum DocumentDeleteMasks : int
        {
            None = 0x00000000,
            NoSetChild = 0x00000001,
            NoSetParent = 0x00000002,
            MoveAction = 0x00000004,
            IncludeVersions = 0x00000008
        }
        public enum ProjectProperty : int
        {
            ID = 1,
            VersionNo = 2,
            ManagerID = 3,
            StorageID = 4,
            CreatorID = 5,
            UpdaterID = 6,
            WorkflowID = 7,
            StateID = 8,
            Type = 9,
            ArchiveID = 10,
            IsParent = 11,

            Name = 12,
            Desc = 13,
            Code = 14,
            Version = 15,
            CreateTime = 16,
            UpdateTime = 17,
            Config = 18,
            Table = 19,

            EnvironmentID = 21,
            ParentID = 22,
            MgrType = 23,
            Access = 24,
            ProjGuid = 25,
            PprjGuid = 26,
            WSpaceProfID = 27,

            ComponentClassId = 28,
            Flags = 30,
            ComponentInstanceId = 31,
            LocationSource = 32,
        }

        public enum DocumentProperty : int
        {
            ID = 1,
            VersionNumber = 2,
            ProposalNumber = 3,
            CreatorID = 4,
            UpdaterID = 5,
            UserID = 6,
            Size = 7,
            FileType = 8,
            ItemType = 9,
            StorageID = 10,

            SetID = 11,
            SetType = 12,
            WorkFlowID = 13,
            StateID = 14,
            ApplicationID = 15,
            DepartmentID = 16,
            OriginalNumber = 18,
            IsOutToMe = 19,

            Name = 20,
            FileName = 21,
            Desc = 22,
            Version = 23,
            CreateTime = 24,
            UpdateTime = 25,
            DMSStatus = 26,
            DMSDate = 27,
            Node = 28,

            ProjectID = 29,
            Access = 30,
            IsLogicalSetMaster = 31,
            IsRedlineMaster = 32,
            IsRefMaster = 33,
            HasFinalStatus = 35,
            Manager = 36,
            FileUpdater = 37,
            LastRtLocker = 38,
            ItemFlags = 39,
            FileUpdateTime = 40,
            LastRtLockTime = 41,

            Is3DFile = 51, // 42, // old values
            Is2DFile = 52, // 43, // old values
            MgrType = 44,
            IsUrl = 45,
            UrlName = 46,
            DocGuid = 47,
            ProjGuid = 48,
            OrigGuid = 49,
            WSpaceProfID = 50,

            FileRevision = 53, // string
            Overlaps = 54, // numeric
            LocationID = 55, // guid
            MIMEType = 56, // string
            LocationSource = 58 // numeric
        }
        //API DLL Import 
        /// //////////////////////////////////////////////////////////////////////////////////////////
        //Login
        /// //////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_Initialize(int init);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_Uninitialize();

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_LoginWithSecurityToken(string dataSource, string securityToken, bool asAdmin, string hostname, long[] productIds);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_GetRelyingPartyIdentifier(string serverName, ref string relyingPartyIdentifier);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetUserName([Out] StringBuilder lpBuffer, ref int lpnSize);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_SelectDatasources();

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr aaApi_GetActiveDatasource();

        [DllImport("dmscli.dll", EntryPoint = "aaApi_GetDatasourceName", CharSet = CharSet.Unicode)]
        private static extern IntPtr unsafe_aaApi_GetDatasourceName(int index);

        public static string aaApi_GetDatasourceName(int index)
        {
            return Marshal.PtrToStringUni(unsafe_aaApi_GetDatasourceName(index));
        }
        [DllImport("dmscli.dll", EntryPoint = "aaApi_GetDatasourceFullName", CharSet = CharSet.Unicode)]
        private static extern IntPtr unsafe_aaApi_GetDatasourceFullName(int index);

        public static string aaApi_GetDatasourceFullName(int index)
        {
            return Marshal.PtrToStringUni(unsafe_aaApi_GetDatasourceFullName(index));
        }

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_LogoutByHandle(IntPtr dsHandle);

        [DllImport("dmscli.dll", EntryPoint = "aaApi_Logout", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_Logout(string lptstrDataSource);
        //////////////////////////////////////////////////////////////////////////////////////////
        //Data Buffer API
        //////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern System.IntPtr aaApi_SelectProjectDataBufferChilds(int lProjectId);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_DmsDataBufferGetCount(IntPtr hDataBuffer);

        [DllImport("dmscli.dll", EntryPoint = "aaApi_DmsDataBufferGetStringProperty", CharSet = CharSet.Unicode)]
        private static extern IntPtr unsafe_aaApi_DmsDataBufferGetStringProperty(IntPtr hDataBuffer, ProjectProperty lPropertyId, int lIdxRow);

        public static string aaApi_DmsDataBufferGetStringProperty(IntPtr hDataBuffer, ProjectProperty lPropertyId, int lIdxRow)
        {
            return Marshal.PtrToStringUni(unsafe_aaApi_DmsDataBufferGetStringProperty(hDataBuffer, lPropertyId, lIdxRow));
        }

        [DllImport("dmscli.dll", EntryPoint = "aaApi_DmsDataBufferGetNumericProperty", CharSet = CharSet.Unicode)]
        public static extern int aaApi_DmsDataBufferGetNumericProperty(IntPtr hDataBuffer, ProjectProperty lPropertyId, int lIdxRow);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern void aaApi_DmsDataBufferFree(IntPtr hDataBuffer);

        /// //////////////////////////////////////////////////////////////////////////////////////////

        //File Actions
        /// //////////////////////////////////////////////////////////////////////////////////////////
        /// Selecting Projects
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_SelectTopLevelProjects();
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_SelectDocumentsByProjectId(int ProjectId);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_GetDocumentId(int lIndex);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_GetDocumentNumericProperty(DocumentProperty PropertyId, int lIndex);
        /// Getting Projects
        //Get Project Name
        [DllImport("dmscli.dll", EntryPoint = "aaApi_GetProjectStringProperty", CharSet = CharSet.Unicode)]
        private static extern IntPtr unsafe_aaApi_GetProjectStringProperty(ProjectProperty PropertyId, int lIndex);

        public static string aaApi_GetProjectStringProperty(ProjectProperty PropertyId, int lIndex)
        {
            return Marshal.PtrToStringUni(unsafe_aaApi_GetProjectStringProperty(PropertyId, lIndex));
        }
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_DeleteProjectById(int iProjectId);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_DeleteProject
            (
            int lProjectId,     //LONG  lProjectId,  
            uint ulFlags,       //ULONG  ulFlags,  
            IntPtr fpCallBack,  //AAPROC_PROJECTDELETE  fpCallBack,  
            IntPtr aaUserParm,  //AAPARAM  aaUserParam,  
            ref int lplCount    //LPLONG  lplCount   
            );
        //Get Project ID
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern int aaApi_GetProjectNumericProperty(ProjectProperty PropertyId, int lIndex);
        //Get Document Name
        [DllImport("dmscli.dll", EntryPoint = "aaApi_GetDocumentStringProperty", CharSet = CharSet.Unicode)]
        private static extern IntPtr unsafe_aaApi_GetDocumentStringProperty(DocumentProperty PropertyId, int Index);
        public static string aaApi_GetDocumentStringProperty(DocumentProperty PropertyId, int Index)
        {
            return Marshal.PtrToStringUni(unsafe_aaApi_GetDocumentStringProperty(PropertyId, Index));
        }

        //Project Actions
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_CreateProject(ref int createdVaultID, int parentID,
        int storageID, int managerID, VaultType type, int workflowID,
        int workspaceProfileID, int copyAccessFromProject, string name, string description);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_ModifyProject
        (
        int lProjectId,     /* i  Project number to modify       */
        int lStorageId,     /* i  Storage number                 */
        int lManagerId,     /* i  Project manager number         */
        int lType,          /* i  Project type                   */
        string lpctstrName,    /* i  Project name                   */
        string lpctstrDesc    /* i  Project description            */
        );
        /// Manipulating Projects
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_MoveDocument
        (
            int lSourceProjectNo,    /* i  Source project number         */
            int lSourceDocumentId,   /* i  Source document number        */
            int lTargetProjectNo,    /* i  Destination project number    */
            ref int lplTargetDocumentId, /* io Target document number        */
            string lpctstrWorkdir,      /* i  Working directory used in move*/
            string lpctstrFileName,     /* i  File name for the copy        */
            string lpctstrName,         /* i  Name for the copy             */
            string lpctstrDesc,         /* i  Description for the copy      */
            DocumentCopyFlags ulFlags              /* i  Flags for the operation       */
        );
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_CopyDocument
        (
           int lSourceProjectNo,    /* i  Source project identifier     */
           int lSourceDocumentId,   /* i  Source document identifier    */
           int lTargetProjectNo,    /* i  Destination project identifier*/
           ref int lplTargetDocumentId, /* io Target document identifier    */
           string lpctstrWorkdir,      /* i  Working directory used in copy*/
           string lpctstrFileName,     /* i  File name for the copy        */
           string lpctstrName,         /* i  Name for the copy             */
           string lpctstrDesc,         /* i  Description for the copy      */
           DocumentCopyFlags ulFlags              /* i  Flags fro the operation       */
        );
        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        //free up storage space, Metadata remains; document becomes abstract. File size set to 0
        public static extern bool aaApi_DeleteDocumentFile(int vaultID, int documentID);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_DeleteDocument(DocumentDeleteMasks uiFlags, int iProjectId, int iDocumentId);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_FetchDocumentFromServer
        (
           FetchDocumentFlags ulFlags,           /* i  Flags (AADMS_DOCFETCH_*)     */
           int lProjectId,        /* i  Project number               */
           int lDocumentId,       /* i  Document number              */
           string lpctstrWorkdir,    /* i  Working directory            */
           StringBuilder lptstrFileName,    /* o  File name with full path     */
           int lBufferSize        /* i  Buffer size for file name    */
        );

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_ExportDocument(int lProjectNo, int lDocumentId,
        string lpctstrWorkdir, StringBuilder lptstrFileName, int lBufferSize);

        [DllImport("dmscli.dll", CharSet = CharSet.Unicode)]
        public static extern bool aaApi_CreateDocument(ref int documentID, int vaultID,
        int storageID, int fileType, DocumentType itemType, int applicationID,
        int departmentID, int workspaceProfileID, string sourceFilePath, string fileName, string name,
        string description, string version, bool leaveCheckedOut, DocumentCreationFlag creationFlags,
        StringBuilder workingFile, int workingFileBufferSize, ref int attributeID);
        //Error Handling
        /// //////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("dmsgen.dll", EntryPoint = "aaApi_GetLastErrorDetail", CharSet = CharSet.Unicode)]
        public static extern IntPtr unsafe_aaApi_GetLastErrorDetail();

        public static string aaApi_GetLastErrorDetail()
        {
            return Marshal.PtrToStringUni(unsafe_aaApi_GetLastErrorDetail());
        }
        /// //////////////////////////////////////////////////////////////////////////////////////////
        /// 
        //Functions
        public static void Initialize()
        {
            int initResult = aaApi_Initialize(1); // AAMODULE_ALL
            if (initResult == 0)
            {
                MessageBox.Show("Failed to initialize ProjectWise API.");
            }
            else
            {
                //MessageBox.Show("ProjectWise API initialized successfully.");
            }

        }
        public static string GetCurrentUsername()
        {
            int size = 255;
            StringBuilder buffer = new StringBuilder(size);
            if (GetUserName(buffer, ref size))
                return buffer.ToString();
            else
                throw new System.ComponentModel.Win32Exception();
        }


        public static bool LoginIMS(string DataName)
        {
            //Define Variables
            
            string DataSourceName = DataName.Split(':')[1];
            string ServerName = DataName.Split(':')[0];
            string username = GetCurrentUsername();
            string relyingParty = string.Empty;
            bool relyingPartySuccess = aaApi_GetRelyingPartyIdentifier(ServerName, ref relyingParty);

            if (relyingPartySuccess)
            {

                ConnectClientAPI_MSIL connectionClientApi = new ConnectClientAPI_MSIL();
                if (!connectionClientApi.IsLoggedIn())
                {
                    MessageBox.Show("You are not signed into Bentley CONNECTION Client.");
                    return false;
                }
                else
                {
                    //MessageBox.Show("You are signed into Bentley CONNECTION Client.");
                }
                string base64StringToken = connectionClientApi.GetSerializedDelegateSecurityToken(relyingParty);
                byte[] tokenByteArray = Convert.FromBase64String(base64StringToken);
                string token = Encoding.UTF8.GetString(tokenByteArray);

                if (string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Token is empty. CONNECTION Client might not be signed in.");
                    return false;
                }


                long[] productIds = null;
                bool result = aaApi_LoginWithSecurityToken(DataName, token, false, null, productIds);
                if (result)
                {
                    MessageBox.Show($"Successfully logged in to '{DataSourceName}' as '{username}'");
                    return true;
                }
                else
                {
                    MessageBox.Show($"Failed to login to '{DataSourceName}' as '{username}'");
                    return false;
                }

            }
            else
            {
                MessageBox.Show($"Failed to login to '{DataSourceName}'");
                string errorDetail = aaApi_GetLastErrorDetail();
                MessageBox.Show($"Error: {errorDetail}");
                return false;
            }
        }
        public static List<Node> GetTopLevelProjects()
        {
            List<Node> rootNodes = new List<Node>();

            int projCount = aaApi_SelectTopLevelProjects();
            if (projCount == -1)
            {
                MessageBox.Show("Error selecting top-level projects: " + aaApi_GetLastErrorDetail());
                return rootNodes;
            }
            if (projCount == 0)
            {
                MessageBox.Show("No top-level projects found.");
                return rootNodes;
            }
            for (int i = 0; i < projCount; i++)
            {
                string projName = aaApi_GetProjectStringProperty(ProjectProperty.Name, i);
                int projId = aaApi_GetProjectNumericProperty(ProjectProperty.ID, i);
                long isParent = aaApi_GetProjectNumericProperty(ProjectProperty.IsParent, i);

                if (!string.IsNullOrEmpty(projName) && projId != 0)
                {
                    // Check for child documents
                    int docCount = aaApi_SelectDocumentsByProjectId(projId);
                    bool hasChildren = (isParent == 1) || (docCount > 0);

                    Node projectNode = new Node
                    {
                        Name = projName,
                        IsDocument = false,
                        HasChildren = hasChildren,
                        ProjectId = projId,
                        ObjectId = projId,
                    };
                    rootNodes.Add(projectNode);
                }
            }

            return rootNodes;
        }

        public static List<Node> GetChildren(int parentId)
        {
            List<Node> children = new List<Node>();

            //MessageBox.Show($"Attempting to select children for ProjectId: {parentId}");

            // Step 1: Get child projects
            IntPtr hChildBuffer = aaApi_SelectProjectDataBufferChilds(parentId);
            if (hChildBuffer == IntPtr.Zero)
            {
                string errorDetail = aaApi_GetLastErrorDetail();
                //MessageBox.Show($"Error selecting child projects for ProjectId {parentId}: {errorDetail}, hChildBuffer: {hChildBuffer.ToInt64()}");
            }
            else
            {
                long lChildCount = aaApi_DmsDataBufferGetCount(hChildBuffer);
                //MessageBox.Show($"Found {lChildCount} child projects for ProjectId: {parentId}");

                for (int i = 0; i < lChildCount; i++)
                {
                    string childName = aaApi_DmsDataBufferGetStringProperty(hChildBuffer, ProjectProperty.Name, i);
                    long childId = aaApi_DmsDataBufferGetNumericProperty(hChildBuffer, ProjectProperty.ID, i);
                    long lIsParent = aaApi_DmsDataBufferGetNumericProperty(hChildBuffer, ProjectProperty.IsParent, i);

                    if (!string.IsNullOrEmpty(childName) && childId != 0)
                    {
                        // Check for child documents under this project
                        int docCount = aaApi_SelectDocumentsByProjectId((int)childId);
                        bool hasChildren = (lIsParent == 1) || (docCount > 0);

                        Node childNode = new Node
                        {
                            Name = childName,
                            IsDocument = false, // This is a project
                            HasChildren = hasChildren,
                            ProjectId = (int)childId,
                            ObjectId = (int)childId,
                        };

                        children.Add(childNode);
                    }
                    else
                    {
                        //MessageBox.Show($"Failed to retrieve child project properties for index {i}: Name={childName}, ID={childId}, IsParent={lIsParent}");
                    }
                }

                aaApi_DmsDataBufferFree(hChildBuffer);
            }

            // Step 2: Get child documents
            int docCountTotal = aaApi_SelectDocumentsByProjectId(parentId);
            //MessageBox.Show($"Found {docCountTotal} documents for ProjectId: {parentId}");

            if (docCountTotal > 0)
            {
                for (int i = 0; i < docCountTotal; i++)
                {
                    int docId = aaApi_GetDocumentId(i);
                    if (docId == 0)
                    {
                        //MessageBox.Show($"Failed to get DocumentId for index {i}");
                        continue;
                    }

                    string docName = aaApi_GetDocumentStringProperty(DocumentProperty.Name, i);
                    string fileName = aaApi_GetDocumentStringProperty(DocumentProperty.FileName, i);
                    int projId = aaApi_GetDocumentNumericProperty(DocumentProperty.ProjectID, i);
                    if (!string.IsNullOrEmpty(docName) && !string.IsNullOrEmpty(fileName))
                    {
                        // Use the Name property, append extension from FileName if needed
                        string extension = Path.GetExtension(fileName);
                        if (!string.IsNullOrEmpty(extension) && !docName.EndsWith(extension))
                        {
                            docName += extension;
                            //MessageBox.Show($"Appended extension to document: {docName}");
                        }

                        Node docNode = new Node
                        {
                            Name = docName,
                            IsDocument = true,
                            HasChildren = false, // Documents don't have children
                            ProjectId = projId,
                            ObjectId = docId,
                        };

                        children.Add(docNode);
                    }
                    else
                    {
                        //MessageBox.Show($"Failed to retrieve document properties for index {i}: Name={docName}, FileName={fileName}");
                    }
                }
            }

            return children;
        }

        public static int GetDocumentId(int projID, string documentName)
        {
            int docCount = aaApi_SelectDocumentsByProjectId(projID);
            for (int i = 0; i < docCount; i++)
            {
                int docId = aaApi_GetDocumentId(i);
                string name = aaApi_GetDocumentStringProperty(DocumentProperty.Name, i);
                if (name.Equals(documentName, StringComparison.OrdinalIgnoreCase))
                {
                    return docId;
                }
            }
            return -1; // Not found
        }
        public static bool CreateSubProject(ref int createdVaultId, int parentId, string name, string desc)
        {
            int storageId = 1;
            int managerId = 1;
            VaultType type = VaultType.Normal;
            int workflowId = 0;
            int workspaceProfileId = 0;
            int copyAccessFromProject = 0;

            return aaApi_CreateProject(ref createdVaultId, parentId, storageId, managerId, type, workflowId, workspaceProfileId, copyAccessFromProject, name, desc);
        }
        public static int SelectDocumentsByProjectId(int projectId)
        {
            return aaApi_SelectDocumentsByProjectId(projectId);
        }
        public static bool ModifyProject(int lProjId, string newName, string newDesc)
        {
            // Match the signature from the reference code with reserved parameters
            return aaApi_ModifyProject(lProjId, 0, 0, -1, newName, newDesc);
        }


        public static bool DeleteProject(int lProjectId, ref long plCount)
        {
            int count = 0; // Use an integer variable for the count
            bool result = aaApi_DeleteProject(lProjectId, 0, IntPtr.Zero, IntPtr.Zero, ref count);
            plCount = count; // Assign the integer count back to the long variable
            return result;
        }

        public static bool DeleteDocument(int projectId, int documentId)
        {
            return aaApi_DeleteDocument(DocumentDeleteMasks.None, projectId, documentId);
        }
        public static bool DownloadDocument(int projectId, int documentId, string localPath)
        {
            // Buffer for the exported file path
            const int bufferSize = 260; // MAX_PATH size, including null terminator
            StringBuilder filePathBuffer = new StringBuilder(bufferSize);

            // Export the document
            bool exportSuccess = aaApi_ExportDocument(projectId, documentId, localPath, filePathBuffer, bufferSize);
            if (exportSuccess)
            {
                Console.WriteLine($"Document exported successfully to: {localPath}");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to export document.");
                return false;
            }
        }

        public static bool CreateDocument(int projectId, ref int newDocumentId, string localFilePath, string documentName, string documentDesc)
        {

            int storageId = 1; // Default storage ID
            int fileType = 0; // Default file type
            DocumentType itemType = DocumentType.Normal; // Default item type
            int applicationId = 0; // Default application ID
            int departmentId = 0; // Default department ID
            int workspaceProfileID = 0; // Default workspaceProfile ID

            string version = null; // No specific version
            bool leaveCheckedOut = false; // Do not leave checked out
            DocumentCreationFlag flags = DocumentCreationFlag.Default; // Default flags
            const int bufferSize = 260; // MAX_PATH size, including null terminator
            StringBuilder workingFileBuffer = new StringBuilder(bufferSize);
            int attributeID = 0; // Default attribute ID

            return aaApi_CreateDocument(ref newDocumentId, projectId, storageId, fileType, itemType, applicationId, departmentId, workspaceProfileID, localFilePath, documentName, documentName, documentDesc, version, leaveCheckedOut, flags, workingFileBuffer, bufferSize, ref attributeID);
        }
        public static bool Logout(bool hasNotice = true)
        {
            // logout - good practice as it will free up some resources on the server
            if (!aaApi_LogoutByHandle(aaApi_GetActiveDatasource()))
            {
                if (hasNotice)
                {
                    MessageBox.Show($"Error logging out.");
                }

                return false;
            }
            else
            {
                if (hasNotice)
                {
                    MessageBox.Show($"Successfully logged out.");
                }

                return true;
            }
        }
        public static string GetLastErrorDetail()
        {
            // For debugging purposes
            return aaApi_GetLastErrorDetail();
        }


    }
}
