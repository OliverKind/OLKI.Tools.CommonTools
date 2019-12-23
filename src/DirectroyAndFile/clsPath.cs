/*
 * Filename:        clsPath.cs
 * Created:         2018-10-20
 * Last modified:   2018-10-20
 * Copyright:       Oliver Kind - 2018
 * License:         LGPL
 * 
 * 1. Path
 *  a. Repair
 * 
 * Desctiption:
 * Class that provides tool to handle pathes
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
    /// Class that provides tool to handle pathes
    /// </summary>
    public static class Path
    {
        #region Methods
        #region Repair
        /// <summary>
        /// Repairs the specified path by removing wrong escape sequences and emend wrong path seperators. Convertes \\ to \ and / to \
        /// </summary>
        /// <param name="path">An string that specifies the path to repair</param>
        /// <returns>The corrected path</returns>
        public static string Repair(string path)
        {
            path = path.Replace(@"/", @"\");
            path = path.Replace(@"\\", @"\");
            return path;
        }
        #endregion

        #region IsDrive
        /// <summary>
        /// Check if the specified path is an drive
        /// </summary>
        /// <param name="path">An string that specifies the path to check if it is an drive</param>
        /// <returns>True if the direcotry is an drive</returns>
        public static bool IsDrive(string path)
        {
            try
            {
                return IsDrive(new DirectoryInfo(path));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the specified path is an drive
        /// </summary>
        /// <param name="path">An DirectoryInfo that specifies the direcotry  to check if it is an drive</param>
        /// <returns>True if the direcotry is an drive</returns>
        public static bool IsDrive(DirectoryInfo directory)
        {
            try
            {
                return new System.IO.DriveInfo(directory.Root.Name).Name == directory.FullName;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #endregion
    }
}