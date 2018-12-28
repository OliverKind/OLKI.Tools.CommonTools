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
        /// Repairs the specified file path by removing wrong escape sequences and emend wrong path seperators. Convertes \\ to \ and / to \
        /// </summary>
        /// <param name="path">An null-terminated string that specifies the path to repair</param>
        public static string Repair(string path)
        {
            path = path.Replace(@"/", @"\");
            path = path.Replace(@"\\", @"\");
            return path;
        }
        #endregion
        #endregion
    }
}