ProjectWise File Explorer WinForms Application

Overview

The ProjectWise Explorer is a Windows Forms application designed to interact with the Bentley ProjectWise system and using ProjectWise API to manipulate the folders and documents in ProjectWise, allowing users to manage projects, documents, and folders. This application provides a graphical interface to log in, navigate the ProjectWise hierarchy, upload/download documents, and perform various management tasks such as creating, modifying, and deleting projects and documents.

Features

Login/Logout Functionality: Connect and disconnect from the ProjectWise server using Bentley CONNECTION Client authentication.

Hierarchy Navigation: Browse and expand the ProjectWise project and document tree using a TreeView control.

Document Management: Upload new documents, download existing ones, and delete documents.

Project Management: Create, modify, and delete projects/folders within the ProjectWise structure.

Status Indicator: Visual feedback with a green light for logged-in status and a red light for logged-out status.

Menu Bar: Includes options like "File > Exit" and "Refresh" for easy navigation and application control.

Prerequisites

Windows Operating System: The application is built for Windows using .NET Framework.

Bentley ProjectWise SDK: Requires dmscli.dll and dmsgen.dll for API interactions (ensure these are accessible in the project directory or system PATH).

Bentley CONNECTION Client: Must be installed and logged in for IMS authentication.

.NET Framework: Compatible with .NET Framework 4.7.2 or later (adjust based on your project settings).

Visual Studio: Recommended for development and debugging (2019 or later).

Installation

Clone the repository or download the source code.

Open the solution file (WindowsFormsApp1.sln) in Visual Studio.

Ensure the required DLLs (dmscli.dll, dmsgen.dll) are referenced or located in the project directory.

Restore any NuGet packages if prompted.

Build the solution (Build > Build Solution).

Run the application (F5 or Debug > Start Debugging).

Usage

Launch the Application: Start the app from Visual Studio or the compiled executable.

Login: Click the "Login" button to authenticate with ProjectWise using your CONNECTION Client credentials. The status light turns green upon success.

Navigate Hierarchy: Use the TreeView to expand projects and view documents. Click "+" to load child nodes.

Manage Content:

Upload: Select a file path using "Upload Directory" and upload to a selected project.

Download: Choose a folder path using "Download Directory" and download a selected document.

Create Folder: Enter a name and description to create a subfolder under a selected project.

Modify Folder: Update the name and description of a selected project.

Delete: Remove selected projects or documents.

Refresh: Click "Refresh" or use the menu to reload the project hierarchy.

Exit: Click "Exit" button or select "File > Exit" to log out and close the application.

Configuration

Login: The application is preconfigured to use IMS login.

Data Source: The application is preconfigured to connect to DataName = :. Modify the ProjectWise Setting in app to Connect to different server or datasource.

Status Light: Positioned at the top-left (adjust Location in Form1 constructor if needed).

Menu Customization: Add more menu items or shortcuts by modifying the MenuStrip setup in the Form1 constructor.

Troubleshooting

Login Fails: Ensure Bentley CONNECTION Client is running and logged in. Check the error message for details.

DLL Not Found: Verify dmscli.dll and dmsgen.dll are in the project directory or system PATH.

Application Doesn’t Close: Use Task Manager to terminate WindowsFormsApp1.exe if Exit fails, and consider using Application.Exit() instead of this.Close().

License

This project is licensed under the MIT License. See the LICENSE file for details.

Contact

For issues or questions, please open an issue on the repository or contact the project maintainer.