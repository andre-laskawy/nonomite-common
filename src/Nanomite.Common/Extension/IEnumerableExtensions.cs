///-----------------------------------------------------------------
///   File:         IEnumerableExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:33:59
///-----------------------------------------------------------------

namespace System.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="IEnumerableExtensions"/>
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Chunks the specified source.
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="chunksize">The chunksize.</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            var pos = 0;
            while (source.Skip(pos).Any())
            {
                yield return source.Skip(pos).Take(chunksize);
                pos += chunksize;
            }
        }

        /// <summary>
        /// The EmptyIfNull
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/></param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Outputs an item if it's contained in a collection.
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="item">The item.</param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool IfContains<T>(this IEnumerable<T> collection, Func<T, bool> predicate, out T item) where T : class
        {
            item = collection.FirstOrDefault(predicate);
            return item != default(T);
        }

        /// <summary>
        /// Parses each entry of a collection into a string.
        /// </summary>
        /// <param name="collection">The <see cref="IEnumerable"/></param>
        /// <returns>The <see cref="IEnumerable{string}"/></returns>
        public static IEnumerable<string> ItemsToString(this IEnumerable collection)
        {
            var list = new List<string>();
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var value = enumerator.Current.ToString();
                list.Add(value);
            }

            return list;
        }
    }
}
