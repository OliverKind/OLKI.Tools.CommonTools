/*
 * Filename:        clsColorTools.cs
 * Created:         2018-10-20
 * Last modified:   2018-10-20
 * Copyright:       Oliver Kind - 2018
 * License:         LGPL
 * 
 * File Content:
 * 1. FileAssociation
 *  a. FindApplication
 *  b. CheckMatchWithApplication
 *  c. CheckMatchWithApplicationAndSet
 *  d. Set
 * 
 * Desctiption:
 * Class that provides tool to handle file assiciations
 * 
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Text;
using System.Windows.Forms;

namespace OLKI.Tools.CommonTools.DirectoryAndFile
{
    /// <summary>
    /// Class that provides tool to handle file assiciations
    /// </summary>
    public static class FileAssociation
    {
        #region Constants
        /// <summary>
        /// Specifies the default usertype whrere fileassociation should be defined
        /// </summary>
        private const UserType DEFAULT_FILE_ASSOCIATION_USER_TYPE = UserType.CuttenUser;
        /// <summary>
        /// Specifies the defaukt value if a messagebox should be shown, if a file is associated to the specified applicaiton
        /// </summary>
        private const bool DEFAULT_FILE_ASSOCIATION_SHOW_MESSAGE_IF_FILE_IS_ASSOCIATED = true;

        #region return values for FindExecutableA function
        private const int SE_ERR_FNF = 2;
        private const int SE_ERR_PNF = 3;
        private const int SE_ERR_ACCESSDENIED = 5;
        private const int SE_ERR_OOM = 8;
        private const int SE_ERR_NOASSOC = 31;
        private const int SE_FIND_MATCH = 32;
        #endregion
        #endregion

        #region Members
        /// <summary>
        /// Use to access resource file
        /// </summary>
        private static System.ComponentModel.ComponentResourceManager _resource = new System.ComponentModel.ComponentResourceManager(typeof(FileAssociation));

        /// <summary>
        /// An Enumeration ths specifies user types
        /// </summary>
        public enum UserType
        {
            /// <summary>
            /// Current logged in user
            /// </summary>
            CuttenUser,
            /// <summary>
            /// All User
            /// </summary>
            AllUser,
        }
        #endregion


        #region Methods
        #region FindApplication
        /// <summary>
        /// Retrieves the name of and handle to the executable (.exe) file associated with a specific document file.
        /// </summary>
        /// <param name="lpFile">The address of a null-terminated string that specifies a file name. This file should be a document.</param>
        /// <param name="lpDirectory">The address of a null-terminated string that specifies the default directory. This value can be NULL.</param>
        /// <param name="lpResult">The address of a buffer that receives the file name of the associated executable file. This file name is a null-terminated string that specifies the executable file started when an "open" by association is run on the file specified in the lpFile parameter. Put simply, this is the application that is launched when the document file is directly double-clicked or when Open is chosen from the file's shortcut menu. This parameter must contain a valid non-null value and is assumed to be of length MAX_PATH. Responsibility for validating the value is left to the programmer.</param>
        /// <returns>Returns a value greater than 32 if successful, or a value less than or equal to 32 representing an error.</returns>
        [System.Runtime.InteropServices.DllImport("shell32.dll", EntryPoint = "FindExecutable")]
        private static extern long FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);

        /// <summary>
        /// Find the applications it is associated by windows default to a file. Don't throw an exception if ther is no file association.
        /// </summary>
        /// <param name="filePath">The address of a null-terminated string that specifies the file to find the associated application</param>
        /// <returns>Execution path to the application, they is associated to the file or an empty string if no application is associated</returns>
        public static string FindApplication(string filePath)
        {
            return FindApplication(filePath, false);
        }

        /// <summary>
        /// Find the applications it is associated by windows default to a file
        /// </summary>
        /// <param name="filePath">The address of a null-terminated string that specifies the file to find the associated application</param>
        /// <param name="throwExceptionIfNoAssiciation">Specifies if an exception should been thrown if ther is no filce assiciation</param>
        /// <returns>Execution path to the application, they is associated to the file or an empty string if no application is associated</returns>
        public static string FindApplication(string filePath, bool throwExceptionIfNoAssiciation)
        {
            try
            {
                StringBuilder objResult = new StringBuilder(1024);
                long lngResult = FindExecutable(filePath, string.Empty, objResult);

                //Return application path if there is an file association
                lngResult = SE_ERR_FNF;
                if (lngResult > SE_FIND_MATCH)
                {
                    return objResult.ToString();
                }

                // Handle exceptions
                switch (lngResult)
                {
                    case SE_ERR_FNF:
                        throw new Exception(_resource.GetString("FindApplication_SE_ERR_FNF"));
                    case SE_ERR_PNF:
                        throw new Exception(_resource.GetString("FindApplication_SE_ERR_PNF"));
                    case SE_ERR_ACCESSDENIED:
                        throw new Exception(_resource.GetString("FindApplication_SE_ERR_ACCESSDENIED"));
                    case SE_ERR_OOM:
                        throw new Exception(_resource.GetString("FindApplication_SE_ERR_OOM"));
                    case SE_ERR_NOASSOC:
                        if (throwExceptionIfNoAssiciation)
                        {
                            throw new Exception(_resource.GetString("FindApplication_SE_ERR_NOASSOC"));
                        }
                        break;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(_resource.GetString("FindApplication_Exception_Message"), new object[] { filePath, ex.Message }), _resource.GetString("FindApplication_Exception_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        #endregion

        #region CheckMatchWithApplication
        /// <summary>
        /// Matches if the specified application executable is associated with the specified file
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="filePath">The address of a null-terminated string that specifies a file name. This file should be a document.</param>
        /// <returns>True if the defined application is associated wit  h the defined file</returns>
        public static bool CheckMatchWithApplication(string appPath, string filePath)
        {
            appPath = OLKI.Tools.CommonTools.DirectoryAndFile.Path.Repair(appPath);
            filePath = OLKI.Tools.CommonTools.DirectoryAndFile.Path.Repair(filePath);

            string FileAssociation = FindApplication(filePath);
            if (string.IsNullOrEmpty(FileAssociation) || string.IsNullOrEmpty(appPath) || string.Compare(appPath, FileAssociation, true) != 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region CheckMatchWithApplicationAndSet
        /// <summary>
        /// Matches if the specified file is associated to the specified application executable is and set the file association of the spicified file to the specified application executable, if requested, if the specified is not associated to the specified application
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="filePath">The address of a null-terminated string that specifies a file name. This file should be a document.</param>
        /// <param name="applicationFiletype">The file type of the application, as example "txt.text"</param>
        /// <param name="description">The description of the file type, as example "Textwriter Textfile"</param>
        /// <param name="iconPath">The address of a null-terminated string that specifies the icon which should be associated to the specified file type. This value can be NULL.</param>
        public static void CheckMatchWithApplicationAndSet(string appPath, string filePath, string applicationFiletype, string description, string iconPath)
        {
            CheckMatchWithApplicationAndSet(appPath, filePath, applicationFiletype, description, iconPath, DEFAULT_FILE_ASSOCIATION_SHOW_MESSAGE_IF_FILE_IS_ASSOCIATED);
        }
        /// <summary>
        /// Matches if the specified file is associated to the specified application executable is and set the file association of the spicified file to the specified application executable, if requested, if the specified is not associated to the specified application
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="filePath">The address of a null-terminated string that specifies a file name. This file should be a document.</param>
        /// <param name="applicationFiletype">The file type of the application, as example "txt.text"</param>
        /// <param name="description">The description of the file type, as example "Textwriter Textfile"</param>
        /// <param name="iconPath">The address of a null-terminated string that specifies the icon which should be associated to the specified file type. This value can be NULL.</param>
        /// <param name="showMessageIfConnected">A boolean value it specifies if an message shold been shown if the specified file is associated to specified application</param>
        public static void CheckMatchWithApplicationAndSet(string appPath, string filePath, string applicationFiletype, string description, string iconPath, bool showMessageIfConnected)
        {
            CheckMatchWithApplicationAndSet(appPath, filePath, System.IO.Path.GetExtension(filePath), applicationFiletype, description, iconPath);
        }
        /// <summary>
        /// Matches if the specified file is associated to the specified application executable is and set the file association of the spicified file to the specified application executable, if requested, if the specified is not associated to the specified application
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="filePath">The address of a null-terminated string that specifies a file name. This file should be a document.</param>
        /// <param name="extension">The extension of the file to associate, as example ".txt"</param>
        /// <param name="applicationFiletype">The file type of the application, as example "txt.text"</param>
        /// <param name="description">The description of the file type, as example "Textwriter Textfile"</param>
        /// <param name="iconPath">The address of a null-terminated string that specifies the icon which should be associated to the specified file type. This value can be NULL.</param>
        public static void CheckMatchWithApplicationAndSet(string appPath, string filePath, string extension, string applicationFiletype, string description, string iconPath)
        {
            CheckMatchWithApplicationAndSet(appPath, filePath, extension, applicationFiletype, description, iconPath, DEFAULT_FILE_ASSOCIATION_SHOW_MESSAGE_IF_FILE_IS_ASSOCIATED);
        }
        /// <summary>
        /// Matches if the specified file is associated to the specified application executable is and set the file association of the spicified file to the specified application executable, if requested, if the specified is not associated to the specified application
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="filePath">The address of a null-terminated string that specifies a file name. This file should be a document.</param>
        /// <param name="extension">The extension of the file to associate, as example ".txt"</param>
        /// <param name="applicationFiletype">The file type of the application, as example "txt.text"</param>
        /// <param name="description">The description of the file type, as example "Textwriter Textfile"</param>
        /// <param name="iconPath">The address of a null-terminated string that specifies the icon which should be associated to the specified file type. This value can be NULL.</param>
        /// <param name="showMessageIfFileisAccociated">A boolean value it specifies if an message shold been shown if the specified file is associated to specified application</param>
        public static void CheckMatchWithApplicationAndSet(string appPath, string filePath, string extension, string applicationFiletype, string description, string iconPath, bool showMessageIfFileisAccociated)
        {
            if (!CheckMatchWithApplication(appPath, filePath))
            {
                if (MessageBox.Show(string.Format("Das zur Anwendung zugehörige Dateiformat *.{0} ist nicht mit dieser Anwendung verknüpft.\n\nMöchten Sie es jetzt mit der Anwendung verknüpfen?", new object[] { extension }), "Datei nicht verknüpft.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Set(appPath, extension, applicationFiletype, description, iconPath);
                }
            }
            else
            {
                if (showMessageIfFileisAccociated)
                {
                    MessageBox.Show(string.Format("Das zur Anwendung zugehörige Dateiformat *.{0} ist mit dieser Anwendung verknüpft.", new object[] { extension }), "Datei verknüpft.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Set
        /// <summary>
        /// Associates the specified file type the the specified  application
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="extension">The extension of the file to associate, as example ".txt"</param>
        /// <param name="applicationFiletype">The file type of the application, as example "txt.text"</param>
        /// <param name="description">The description of the file type, as example "Textwriter Textfile"</param>
        /// <param name="iconPath">The address of a null-terminated string that specifies the icon which should be associated to the specified file type. This value can be NULL.</param>
        /// <returns>True if the it was possible to associate the specified file type to the specified application or fale if not</returns>
        public static bool Set(string appPath, string extension, string applicationFiletype, string description, string iconPath)
        {
            return Set(appPath, extension, applicationFiletype, description, iconPath, DEFAULT_FILE_ASSOCIATION_USER_TYPE);
        }
        /// <summary>
        /// Associates the specified file type the the specified  application. It can be specified if it is for all users or only for the current user
        /// </summary>
        /// <param name="appPath">The address of a null-terminated string that specifies a application which where the specified file shold be associated with</param>
        /// <param name="extension">The extension of the file to associate, as example ".txt"</param>
        /// <param name="applicationFiletype">The file type of the application, as example "txt.text"</param>
        /// <param name="description">The description of the file type, as example "Textwriter Textfile"</param>
        /// <param name="iconPath">The address of a null-terminated string that specifies the icon which should be associated to the specified file type. This value can be NULL.</param>
        /// <param name="userType">An Enumeration it specifies if the fil type is associated for the specified application for all user or only for the current user</param>
        /// <returns>True if the it was possible to associate the specified file type to the specified application or fale if not</returns>
        public static bool Set(string appPath, string extension, string applicationFiletype, string description, string iconPath, UserType userType)
        {
            List<string> CreatedKeys = new List<string> { };

            appPath = OLKI.Tools.CommonTools.DirectoryAndFile.Path.Repair(appPath);
            iconPath = OLKI.Tools.CommonTools.DirectoryAndFile.Path.Repair(iconPath);

            // Set fileassociation for all users
            try
            {
                if (userType == UserType.AllUser || (userType & UserType.AllUser) == UserType.AllUser)
                {
                    RegistryKey FileKey = Registry.LocalMachine.OpenSubKey(@"Software\Classes\", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    FileKey.CreateSubKey("." + extension, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", applicationFiletype);
                    CreatedKeys.Add("Key: " + FileKey.Name + "." + extension + "    Value: " + applicationFiletype);

                    RegistryKey AppKey = Registry.LocalMachine.OpenSubKey(@"Software\Classes\", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    AppKey.CreateSubKey(applicationFiletype).SetValue("", description);
                    CreatedKeys.Add("Key: " + AppKey.Name + applicationFiletype + "    Value: " + description);
                    AppKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\" + applicationFiletype, RegistryKeyPermissionCheck.ReadWriteSubTree);

                    if (!string.IsNullOrEmpty(iconPath))
                    {
                        AppKey.CreateSubKey("DefaultIcon").SetValue("", iconPath);
                        CreatedKeys.Add("Key: " + AppKey.Name + "DefaultIcon" + "    Value: " + iconPath);
                    }
                    AppKey.CreateSubKey(@"Shell\Open\Command").SetValue("", "\"" + appPath + "\" \"%1\"");
                    CreatedKeys.Add("Key: " + AppKey.Name + @"Shell\Open\Command" + "    Value: " + "\"" + appPath + "\" \"%1\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Beim Verknüpfen des Dateityps *.{0}, für alle Benutzer, mit der Anwendung ist ein Fehler aufgetreten.\n\nBitte Versuchen Sie es erneut, jedoch mit Administratorrechten.\n\n{1}", new object[] { extension, ex.Message }), "Fehler beim ändern der Dateizuordnung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Set fileassociation for current user
            try
            {
                if (userType == UserType.CuttenUser || (userType & UserType.CuttenUser) == UserType.CuttenUser)
                {
                    RegistryKey FileKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    FileKey.CreateSubKey("." + extension, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", applicationFiletype);
                    CreatedKeys.Add("Key:\n" + FileKey.Name + "." + extension + "    Value: " + applicationFiletype);

                    RegistryKey AppKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    AppKey.CreateSubKey(applicationFiletype).SetValue("", description);
                    CreatedKeys.Add("Key: " + AppKey.Name + applicationFiletype + "    Value: " + description);
                    AppKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\" + applicationFiletype, RegistryKeyPermissionCheck.ReadWriteSubTree);

                    if (!string.IsNullOrEmpty(iconPath))
                    {
                        AppKey.CreateSubKey("DefaultIcon").SetValue("", iconPath);
                        CreatedKeys.Add("Key: " + AppKey.Name + "DefaultIcon" + "    Value: " + iconPath);
                    }
                    AppKey.CreateSubKey(@"Shell\Open\Command").SetValue("", "\"" + appPath + "\" \"%1\"");
                    CreatedKeys.Add("Key: " + AppKey.Name + @"Shell\Open\Command" + "    Value: " + "\"" + appPath + "\" \"%1\"");
                }
                MessageBox.Show(string.Format("Der Dateityp *.{0} wurde erfolgreich der Anwendung zugeordnet.\n\nMöglicherweise müssen Sie Windows neu starten bevor die Änderung aktiv wird.", new object[] { extension }), "Dateizuordnung geändert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Beim Verknüpfen des Dateityps *.{0}, für den aktuellen Benutzer, mit der Anwendung ist ein Fehler aufgetreten.\n\n{1}", new object[] { extension, ex.Message }), "Fehler beim ändern der Dateizuordnung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
        #endregion
    }
}