using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ProjectWiseApp
{
    public static class FileIconHelper
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        public const uint SHGFI_ICON = 0x000000100;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        public const uint SHGFI_SMALLICON = 0x000000001;
        public const uint SHGFI_LARGEICON = 0x000000000;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public static Icon GetFileIcon(string extension, bool smallIcon = true)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | (smallIcon ? SHGFI_SMALLICON : SHGFI_LARGEICON);
            uint fileAttribute = 0x80; // FILE_ATTRIBUTE_NORMAL

            SHGetFileInfo(extension, fileAttribute, ref shinfo, (uint)Marshal.SizeOf(shinfo), flags);
            if (shinfo.hIcon != IntPtr.Zero)
            {
                return Icon.FromHandle(shinfo.hIcon);
            }

            return null;
        }

        public static Icon GetFolderIcon()
        {
            //index 3 is the folder icon in shell32.dll
            IntPtr hIcon = ExtractIcon(IntPtr.Zero, "shell32.dll", 3);
            if (hIcon != IntPtr.Zero)
            {
                return Icon.FromHandle(hIcon);
            }
            return null;
            

            
        }
    }
}
