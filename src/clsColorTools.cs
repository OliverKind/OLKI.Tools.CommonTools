/*
 * OLKI.Tools.CommonTools
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Class that provides tool in context with colors
 * - Is not longer maintained here
 * - The code has been moved here: OLKI.Tools.ColorAndPicture.Color
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

using System.Drawing;

namespace OLKI.Tools.CommonTools
{
    /// <summary>
    /// Class that provides tool in context with colors
    /// </summary>
    public static class ColorTools
    {
        #region Constants
        //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.IdealTextColor(backgroundColor);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.IdealTextColor(backgroundColor, threshold);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.IdealTextColor(backgroundColor, textColorBright);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.IdealTextColor(backgroundColor, textColorBright, threshold);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.IdealTextColor(backgroundColor, textColorBright, textColorDark);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.IdealTextColor(backgroundColor, textColorBright, textColorDark, threshold);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.Brightnes(color);
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
            //Is not longer maintained here
            //The code has been moved here: OLKI.Tools.ColorAndPicture.Color
            return OLKI.Tools.ColorAndPicture.Color.Brightnes(color, factorBlue, factorGreen, factorRead);
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