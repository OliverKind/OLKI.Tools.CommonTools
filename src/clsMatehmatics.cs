/*
 * OLKI.Tools.CommonTools
 * 
 * Copyright:   Oliver Kind - 2019
 * License:     LGPL
 * 
 * Desctiption:
 * Class that provides mathematical tools
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

namespace OLKI.Tools.CommonTools
{
    /// <summary>
    /// Class that provides mathematical tools
    /// </summary>
    public static class Matehmatics
    {
        #region Constants
        /// <summary>
        /// The number of digits returnd by percentages calculation by default
        /// </summary>
        private const int DEFAULT_PERCENTAGES_DIGITS = 0;
        #endregion

        #region Methodes
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with none digits</returns>
        public static double Percentages(int percentageQuotation, int basicValue)
        {
            return Percentages(percentageQuotation, basicValue, DEFAULT_PERCENTAGES_DIGITS);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <param name="digits">The number of digits given in result</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with an specified number of digits</returns>
        public static double Percentages(int percentageQuotation, int basicValue, int digits)
        {
            return Percentages((double)percentageQuotation, (double)basicValue, digits);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with none digits</returns>
        public static double Percentages(long percentageQuotation, long basicValue)
        {
            return Percentages(percentageQuotation, basicValue, DEFAULT_PERCENTAGES_DIGITS);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <param name="digits">The number of digits given in result</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with an specified number of digits</returns>
        public static double Percentages(long percentageQuotation, long basicValue, int digits)
        {
            return Percentages((double)percentageQuotation, (double)basicValue, digits);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with none digits</returns>
        public static double Percentages(decimal percentageQuotation, decimal basicValue)
        {
            return Percentages(percentageQuotation, basicValue, DEFAULT_PERCENTAGES_DIGITS);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <param name="digits">The number of digits given in result</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with an specified number of digits</returns>
        public static double Percentages(decimal percentageQuotation, decimal basicValue, int digits)
        {
            return Percentages((double)percentageQuotation, (double)basicValue, digits);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with none digits</returns>
        public static double Percentages(float percentageQuotation, float basicValue)
        {
            return Percentages(percentageQuotation, basicValue, DEFAULT_PERCENTAGES_DIGITS);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <param name="digits">The number of digits given in result</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with an specified number of digits</returns>
        public static double Percentages(float percentageQuotation, float basicValue, int digits)
        {
            return Percentages((double)percentageQuotation, (double)basicValue, digits);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with none digits</returns>
        public static double Percentages(double percentageQuotation, double basicValue)
        {
            return Percentages(percentageQuotation, basicValue, DEFAULT_PERCENTAGES_DIGITS);
        }
        /// <summary>
        /// Calculate the percentage value from a diven Quotation and a basic value
        /// </summary>
        /// <param name="percentageQuotation">Specifies the quotation for percent calculation</param>
        /// <param name="basicValue">Specifies the basic value for percent calculation</param>
        /// <param name="digits">The number of digits given in result</param>
        /// <returns>Ther percentage value of a given qoutation and a basic value with an specified number of digits</returns>
        public static double Percentages(double percentageQuotation, double basicValue, int digits)
        {
            try
            {
                if (percentageQuotation > 0 && basicValue > 0)
                {
                    return System.Math.Round((100 * percentageQuotation / basicValue), digits);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                return 0;
            }
        }
        #endregion
    }
}