///-----------------------------------------------------------------
///   File:         GenericExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:33:58
///-----------------------------------------------------------------

namespace Nanomite.Common.Extensions
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="GenericExtensions"/>
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Clones an object
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="obj">The <see cref="T"/></param>
        /// <returns>The <see cref="T"/></returns>
        public static T Clone<T>(this T obj) where T : class
        {
            return JsonConvert.DeserializeObject<T>(obj.Serialize());
        }

        /// <summary>
        /// Casts a specified item to another type with at least the same properties.
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>The <see cref="R"/></returns>
        public static R DownCast<T, R>(this T item)
        {
            var instance = Activator.CreateInstance<R>();
            var type = typeof(T);
            var properties = type.GetProperties().Where(p => p.CanRead && p.CanWrite);
            foreach (var property in properties)
            {
                var value = property.GetValue(item);
                property.SetValue(instance, value);
            }

            return instance;
        }
    }
}
