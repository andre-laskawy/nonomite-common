///-----------------------------------------------------------------
///   File:         ExceptionExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:33:58
///-----------------------------------------------------------------

namespace Nanomite
{
    using System;

    /// <summary>
    /// Defines the <see cref="ExceptionExtensions"/>
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// To text.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="code">The code.</param>
        /// <returns>The <see cref="string"/></returns>
        public static string ToText(this Exception ex, string code = null)
        {
            string message = (code == null ? "" : code + ":") + ex.Message + Environment.NewLine;

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                message += "Inner exception: " + ex.Message + Environment.NewLine;
            }

            message += "Stacktrace: " + ex.StackTrace + Environment.NewLine;

            return message;
        }
    }
}
