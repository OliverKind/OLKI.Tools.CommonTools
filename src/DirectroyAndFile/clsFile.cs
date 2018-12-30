/*
 * Filename:        clsFile.cs
 * Created:         2018-10-20
 * Last modified:   2018-10-20
 * Copyright:       Oliver Kind - 2018
 * License:         LGPL
 * 
 * File Content:
 * 1. File
 *  a. Copy
 *  b. Create
 *  c. Cut (empthy)
 *  d. Create
 *  e. OpenToString
 * 
 * Desctiption:
 * Class that provides tool to handle files
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
    /// Class that provides tool to handle files
    /// </summary>
    public static class File
    {
        #region Constants
        /// <summary>
        /// Specifies by default if an existing wile should been overwrite withouzt question by File_Copy
        /// </summary>
        private const bool DEFUALT_COPY_OVERWRITE = false;
        /// <summary>
        /// Specifies the defaukt value if a security question should been shown before deleting a file by File_Delete
        /// </summary>
        private const bool DEFUALT_DELETE_SHOW_SECURITY_QUESTION = true;
        /// <summary>
        /// Specifies the defaukt value to return if the specified file does not exists by File_OpenToString
        /// </summary>
        private const string DEFUALT_OPEN_FILE_TO_STRING_VALUE_IF_FILE_NOT_EXISTS = "";
        #endregion

        #region Methods
        #region Copy
        /// <summary>
        /// Copies the specified file to the specified destination and ask to overwrite if the destination file already exists
        /// </summary>
        /// <param name="sourcePath">An null-terminated string that specifies the source file path</param>
        /// <param name="destPath">An null-terminated string that specifies the destination file path</param>
        /// <returns>True if copy was successful and false if not</returns>
        public static bool Copy(string sourcePath, string destPath)
        {
            return Copy(sourcePath, destPath, DEFUALT_COPY_OVERWRITE);
        }
        /// <summary>
        /// Copies the specified file to the specified destination
        /// </summary>
        /// <param name="sourcePath">An null-terminated string that specifies the source file path</param>
        /// <param name="destPath">An null-terminated string that specifies the destination file path</param>
        /// <param name="overwrite">Set true to overwrite an existing file without question</param>
        /// <returns>True if copy was successful and false if not</returns>
        public static bool Copy(string sourcePath, string destPath, bool overwrite)
        {
            try
            {
                if (!overwrite && System.IO.File.Exists(destPath))
                {
                    if (MessageBox.Show(string.Format(src.DirectroyAndFile.resClsFile.Copy_Exists_Message, new object[] { destPath }), src.DirectroyAndFile.resClsFile.Copy_Exists_Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        overwrite = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                System.IO.File.Copy(sourcePath, destPath, overwrite);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(src.DirectroyAndFile.resClsFile.Copy_Exception_Message, new object[] { sourcePath, destPath, ex.Message }), src.DirectroyAndFile.resClsFile.Copy_Exception_Caoption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Creates an empty file with the specified name in the specified directory
        /// </summary>
        /// <param name="directoryPath">An null-terminated string that specifies the directory where the file shoukd be created</param>
        /// <param name="fileName">An null-terminated string that specifies the file name of the file to create</param>
        /// <returns>True if creation of the specified file was successful and false if not</returns>
        public static bool Create(string directoryPath, string fileName)
        {
            try
            {
                directoryPath = OLKI.Tools.CommonTools.DirectoryAndFile.Path.Repair(directoryPath);
                System.IO.Directory.CreateDirectory(directoryPath);
                using (StreamWriter sw = System.IO.File.CreateText(directoryPath + fileName))
                {
                    //sw.WriteLine(string.Empty); -- Create empty file
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(src.DirectroyAndFile.resClsFile.Create_Exception_Message, new object[] { directoryPath + fileName, ex.Message }), src.DirectroyAndFile.resClsFile.Create_Exception_Caoption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region Cut
        //TODO: Add functionality
        #endregion

        #region Delete
        /// <summary>
        /// Delete the specified file an shows a security question
        /// </summary>
        /// <param name="path">An null-terminated string that specifies the file to delete</param>
        /// <returns>True if deleting of the specified file was successful and false if not</returns>
        public static bool Delete(string path)
        {
            return Delete(path, DEFUALT_DELETE_SHOW_SECURITY_QUESTION);
        }
        /// <summary>
        /// Delete the specified file an shows a security question if specified
        /// </summary>
        /// <param name="path">An null-terminated string that specifies the file to delete</param>
        /// <param name="showSecurityQuestion">Specifies if a security question should been shown before the file will be deleted</param>
        /// <returns>True if deleting of the specified file was successful and false if not</returns>
        public static bool Delete(string path, bool showSecurityQuestion)
        {
            try
            {
                if ((!showSecurityQuestion || MessageBox.Show(string.Format(src.DirectroyAndFile.resClsFile.Delete_Confirm_Message, new object[] { path }), src.DirectroyAndFile.resClsFile.Delete_Confirm_Caoption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) == DialogResult.Yes) && System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(src.DirectroyAndFile.resClsFile.Delete_Exception_Message, new object[] { path, ex.Message }), src.DirectroyAndFile.resClsFile.Delete_Exceptionn_Caoption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region OpenToString
        /// <summary>
        /// Opens the specified file and returns the content as string. If the file can not open an empty string will returned
        /// </summary>
        /// <param name="path">An null-terminated string that specifies the file top open</param>
        /// <returns>The content of the specified file as string or an empty string if file can not be opened</returns>
        public static string OpenToString(string path)
        {
            return OpenToString(path, DEFUALT_OPEN_FILE_TO_STRING_VALUE_IF_FILE_NOT_EXISTS);
        }
        /// <summary>
        /// Opens the specified file and returns the content as string
        /// </summary>
        /// <param name="path">An null-terminated string that specifies the file top open</param>
        /// <param name="valueIfFileNotExists">An null-terminated string that specifies the string to return if the file can not be opened</param>
        /// <returns>The content of the specified file as string or the specified string if file can not be opened</returns>
        public static string OpenToString(string path, string valueIfFileNotExists)
        {
            try
            {
                string FileString = string.Empty;
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        while (streamReader.Peek() != -1)
                        {
                            FileString += streamReader.ReadLine();
                        }
                    }
                }
                return FileString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(src.DirectroyAndFile.resClsFile.OpenToString_Exception_Message, new object[] { path, ex.Message }), src.DirectroyAndFile.resClsFile.OpenToString_Exceptionn_Caoption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return valueIfFileNotExists;
            }
        }
        #endregion
        #endregion
    }
}