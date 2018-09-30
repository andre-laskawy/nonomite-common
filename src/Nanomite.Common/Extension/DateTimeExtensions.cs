///-----------------------------------------------------------------
///   File:         DateTimeExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:33:58
///-----------------------------------------------------------------

namespace Nanomite
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the <see cref="DateTimeExtensions"/>
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a datetime to ISO-8601
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string ToISO8601(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("s", CultureInfo.InvariantCulture) + "Z";
        }
    }
}
