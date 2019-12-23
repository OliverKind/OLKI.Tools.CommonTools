﻿/*
 * RaMaDe - RawMatchAndDelete
 * 
 * Copyright:   Oliver Kind - 2019
 * License:     LGPL
 * 
 * Desctiption:
 * Class that provides tool in context with colors
 * 
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the LGPL General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * LGPL General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not check the GitHub-Repository.
 * 
 * */

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLKI.Tools.CommonTools
{
    /// <summary>
    /// Class that provides tool in context with colors
    /// </summary>
    public static class ColorTools
    {
        #region Constants
        /// <summary>
        /// Threshold for switching from dark to bright color
        /// </summary>
        private const double DEFAULT_IDEAL_TEXT_COLOR_THRESHOLD = 115; //128; <-- Original
        /// <summary>
        /// Factor red for calculating the brightnes of a color
        /// </summary>
        private const double DEFAULT_COLOR_BRGHTNES_FACTOR_R = 0.299;
        /// <summary>
        /// Factor green for calculating the brightnes of a color
        /// </summary>
        private const double DEFAULT_COLOR_BRGHTNES_FACTOR_G = 0.587;
        /// <summary>
        /// Factor blue for calculating the brightnes of a color
        /// </summary>
        private const double DEFAULT_COLOR_BRGHTNES_FACTOR_B = 0.114;
        /// <summary>
        /// Dark text color
        /// </summary>
        private static readonly Color DEFAULT_IDEAL_TEXT_COLOR_DARK = Color.Black;
        /// <summary>
        /// Bright text color
        /// </summary>
        private static readonly Color DEFAULT_IDEAL_TEXT_COLOR_BRIGHT = Color.White;
        #endregion

        #region Methods
        #region IdealTextColor
        /// <summary>
        /// A method for programatically determining the appropriate foreground color (black or white) based on the specified background color
        /// </summary>
        /// <remarks>
        /// Source: http://www.codeproject.com/Articles/16565/Determining-Ideal-Text-Color-Based-on-Specified-Ba
        /// Autor:  John Simmons / outlaw programmer
        /// Additional Source: http://www.fseitz.de/blog/index.php?/archives/112-Helligkeit-von-Farben-des-RGB-Farbraums-berechnen.html
        /// Additional Source: http://alienryderflex.com/hsp.html
        /// </remarks>
        /// <param name="backgroundColor">Specifies the background color for text</param>
        /// <returns>Ideal foreground color (black or white) based on the specified background color</returns>
        public static Color IdealTextColor(Color backgroundColor)
        {
            return ColorTools.IdealTextColor(backgroundColor, DEFAULT_IDEAL_TEXT_COLOR_THRESHOLD);
        }
        /// <summary>
        /// A method for programatically determining the appropriate foreground color (black or white) based on the specified background color
        /// </summary>
        /// <remarks>
        /// Source: http://www.codeproject.com/Articles/16565/Determining-Ideal-Text-Color-Based-on-Specified-Ba
        /// Autor:  John Simmons / outlaw programmer
        /// Additional Source: http://www.fseitz.de/blog/index.php?/archives/112-Helligkeit-von-Farben-des-RGB-Farbraums-berechnen.html
        /// Additional Source: http://alienryderflex.com/hsp.html
        /// </remarks>
        /// <param name="backgroundColor">Specifies the background color for text</param>
        /// <param name="threshold">Specifies the threshold for switching from dark to bright color</param>
        /// <returns>Ideal foreground color (black or white) based on the specified background color</returns>
        public static Color IdealTextColor(Color backgroundColor, double threshold)
        {
            return ColorTools.IdealTextColor(backgroundColor, DEFAULT_IDEAL_TEXT_COLOR_BRIGHT, threshold);
        }
        /// <summary>
        /// A method for programatically determining the appropriate foreground color (black or white) based on the specified background color
        /// </summary>
        /// <remarks>
        /// Source: http://www.codeproject.com/Articles/16565/Determining-Ideal-Text-Color-Based-on-Specified-Ba
        /// Autor:  John Simmons / outlaw programmer
        /// Additional Source: http://www.fseitz.de/blog/index.php?/archives/112-Helligkeit-von-Farben-des-RGB-Farbraums-berechnen.html
        /// Additional Source: http://alienryderflex.com/hsp.html
        /// </remarks>
        /// <param name="backgroundColor">Specifies the background color for text</param>
        /// <param name="textColorBright">Specifies the bright text color</param>
        /// <returns>Ideal foreground color (black or white) based on the specified background color</returns>
        public static Color IdealTextColor(Color backgroundColor, Color textColorBright)
        {
            return ColorTools.IdealTextColor(backgroundColor, textColorBright, DEFAULT_IDEAL_TEXT_COLOR_DARK, DEFAULT_IDEAL_TEXT_COLOR_THRESHOLD);
        }
        /// <summary>
        /// A method for programatically determining the appropriate foreground color (black or white) based on the specified background color
        /// </summary>
        /// <remarks>
        /// Source: http://www.codeproject.com/Articles/16565/Determining-Ideal-Text-Color-Based-on-Specified-Ba
        /// Autor:  John Simmons / outlaw programmer
        /// Additional Source: http://www.fseitz.de/blog/index.php?/archives/112-Helligkeit-von-Farben-des-RGB-Farbraums-berechnen.html
        /// Additional Source: http://alienryderflex.com/hsp.html
        /// </remarks>
        /// <param name="backgroundColor">Specifies the background color for text</param>
        /// <param name="textColorBright">Specifies the bright text color</param>
        /// <param name="threshold">Specifies the threshold for switching from dark to bright color</param>
        /// <returns>Ideal foreground color (black or white) based on the specified background color</returns>
        public static Color IdealTextColor(Color backgroundColor, Color textColorBright, double threshold)
        {
            return ColorTools.IdealTextColor(backgroundColor, textColorBright, DEFAULT_IDEAL_TEXT_COLOR_DARK, threshold);
        }
        /// <summary>
        /// A method for programatically determining the appropriate foreground color (black or white) based on the specified background color
        /// </summary>
        /// <remarks>
        /// Source: http://www.codeproject.com/Articles/16565/Determining-Ideal-Text-Color-Based-on-Specified-Ba
        /// Autor:  John Simmons / outlaw programmer
        /// Additional Source: http://www.fseitz.de/blog/index.php?/archives/112-Helligkeit-von-Farben-des-RGB-Farbraums-berechnen.html
        /// Additional Source: http://alienryderflex.com/hsp.html
        /// </remarks>
        /// <param name="backgroundColor">Specifies the background color for text</param>
        /// <param name="textColorBright">Specifies the bright text color</param>
        /// <param name="textColorDark">Specifies the dark text color</param>
        /// <returns>Ideal foreground color (black or white) based on the specified background color</returns>
        public static Color IdealTextColor(Color backgroundColor, Color textColorBright, Color textColorDark)
        {
            return ColorTools.IdealTextColor(backgroundColor, textColorBright, textColorDark, DEFAULT_IDEAL_TEXT_COLOR_THRESHOLD);
        }
        /// <summary>
        /// A method for programatically determining the appropriate foreground color (black or white) based on the specified background color
        /// </summary>
        /// <remarks>
        /// Source: http://www.codeproject.com/Articles/16565/Determining-Ideal-Text-Color-Based-on-Specified-Ba
        /// Autor:  John Simmons / outlaw programmer
        /// Additional Source: http://www.fseitz.de/blog/index.php?/archives/112-Helligkeit-von-Farben-des-RGB-Farbraums-berechnen.html
        /// Additional Source: http://alienryderflex.com/hsp.html
        /// </remarks>
        /// <param name="backgroundColor">Specifies the background color for text</param>
        /// <param name="textColorBright">Specifies the bright text color</param>
        /// <param name="textColorDark">Specifies the dark text color</param>
        /// <param name="threshold">Specifies the threshold for switching from dark to bright color</param>
        /// <returns>Ideal foreground color (black or white) based on the specified background color</returns>
        public static Color IdealTextColor(Color backgroundColor, Color textColorBright, Color textColorDark, double threshold)
        {
            //int BgBright = Convert.ToInt32((backgroundColor.R * DEFAULT_IDEAL_TEXT_COLOR_FACTOR_R) + (backgroundColor.G * DEFAULT_IDEAL_TEXT_COLOR_FACTOR_G) + (backgroundColor.B * DEFAULT_IDEAL_TEXT_COLOR_FACTOR_B));
            //int BgBright = Convert.ToInt32(Math.Sqrt((Math.Pow(backgroundColor.R, 2) * DEFAULT_IDEAL_TEXT_COLOR_FACTOR_R) + (Math.Pow(backgroundColor.G, 2) * DEFAULT_IDEAL_TEXT_COLOR_FACTOR_G) + (Math.Pow(backgroundColor.B, 2) * DEFAULT_IDEAL_TEXT_COLOR_FACTOR_B)));
            return (255 - ColorTools.Brightnes(backgroundColor) < threshold) ? textColorDark : textColorBright;
        }
        #endregion

        #region Brightnes
        /// <summary>
        /// Get the Brightnes of an given color with default factors for red, green and blue 	pigment content
        /// </summary>
        /// <param name="color">Specifies the color to calculate the brightness</param>
        /// <returns>The Brightniss of the color with an range from 0 for dark (black) an 255 for bright (white)</returns>
        public static double Brightnes(Color color)
        {
            return ColorTools.Brightnes(color, DEFAULT_COLOR_BRGHTNES_FACTOR_B, DEFAULT_COLOR_BRGHTNES_FACTOR_G, DEFAULT_COLOR_BRGHTNES_FACTOR_R);
        }
        /// <summary>
        /// Get the Brightnes of an given color with default factors for red, green and blue 	pigment content
        /// </summary>
        /// <param name="color">Specifies the color to calculate the brightness</param>
        /// <param name="factorBlue">Factor blue for calculating the brightnes of a color</param>
        /// <param name="factorGreen">Factor green for calculating the brightnes of a color</param>
        /// <param name="factorRead">Factor red for calculating the brightnes of a color</param>
        /// <returns>The Brightniss of the color with an range from 0 for dark (black) an 255 for bright (white)</returns>
        public static double Brightnes(Color color, double factorBlue, double factorGreen, double factorRead)
        {
            double FactorB = (Math.Pow(color.B, 2) * factorBlue);
            double FactorG = (Math.Pow(color.G, 2) * factorGreen);
            double FactorR = (Math.Pow(color.R, 2) * factorRead);
            return Math.Sqrt(FactorB + FactorG + FactorR);
        }
        #endregion

        #region ReverseColor
        /// <summary>
        /// A method for programatically determining the complementary color of a given color
        /// </summary>
        /// <param name="colorToConvert">Specifies the color to reverse</param>
        /// <returns>Complementary color of a given color</returns>
        public static Color GetComplementaryColor(Color colorToConvert)
        {
            return Color.FromArgb(colorToConvert.ToArgb() ^ 0xffffff);
        }
        #endregion
        #endregion
    }
}