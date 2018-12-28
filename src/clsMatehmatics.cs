/*
 * Filename:        clsMatehmatics.cs
 * Created:         2017-01-04
 * Last modified:   2018-10-18
 * Copyright:       Oliver Kind - 2018
 * License:         LGPL
 * 
 * File Content:
 * 1. Percentages
 * 
 * Desctiption:
 * Class that provides mathematical tools
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
