///-----------------------------------------------------------------
///   File:         ProtoExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:33:59
///-----------------------------------------------------------------

namespace Nanomite
{
    using Google.Protobuf;
    using Google.Protobuf.WellKnownTypes;
    using Nanomite.Common;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ProtoExtensions"/>
    /// </summary>
    public static class ProtoExtensions
    {
        /// <summary>
        /// Tries the cast.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proto">The proto<see cref="Any"/></param>
        /// <returns></returns>
        public static T CastToModel<T>(this Any proto) where T : IMessage, new()
        {
            try
            {
                T result;
                proto.TryUnpack<T>(out result);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return default(T);
            }
        }

        /// <summary>
        /// Tries the cast as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list<see cref="List{Any}"/></param>
        /// <returns></returns>
        public static List<T> TryCastToModelList<T>(this List<Any> list) where T : IMessage, new()
        {
            try
            {
                return list.Select(p => p.Unpack<T>()).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<T>();
            }
        }

        /// <summary>
        /// Converts a exception to a proto exception
        /// </summary>
        /// <param name="p_Exception">The p_Exception<see cref="S_Exception"/></param>
        /// <param name="throwException">The throwException<see cref="bool"/></param>
        /// <returns>the proto Exception</returns>
        public static Exception ToException(this Any proto, bool throwException = false)
        {
            Exception ex = null;
            S_Exception p_Exception = proto.CastToModel<S_Exception>();
            if(p_Exception == null)
            {
                throw new Exception("Excpected S_Exception proto, but received: " + p_Exception.GetType().FullName);
            }

            if (p_Exception != null)
            {
                ex = p_Exception.ToBaseException();
            }


            if (!string.IsNullOrEmpty(p_Exception.Message) && ex != null)
            {
                if (throwException)
                {
                    throw new Exception(p_Exception.Message, ex);
                }
                return new Exception(p_Exception.Message, ex);
            }
            else if (!string.IsNullOrEmpty(p_Exception.Message))
            {
                if (throwException)
                {
                    throw new Exception(p_Exception.Message);
                }
                return new Exception(p_Exception.Message);
            }

            if (throwException)
            {
                throw ex;
            }

            return ex;
        }

        /// <summary>
        /// To the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        private static Exception ToBaseException(this S_Exception ex)
        {
            Exception result = null;
            if (ex.InnerException != null)
            {
                result = new Exception(ex.Message, ex.InnerException.ToBaseException());
            }
            else
            {
                result = new Exception(ex.Message);
            }

            if (!string.IsNullOrEmpty(ex.Code))
            {
                return new Exception(ex.Code, result);
            }

            return result;
        }

        /// <summary>
        /// Converts a exception to a proto exception
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="code">The code<see cref="string"/></param>
        /// <returns>the proto Exception</returns>
        public static S_Exception ToProtoException(this Exception ex, string code = null)
        {
            S_Exception result = new S_Exception();

            result.Message = ex.Message;
            result.StackTrace = ex.StackTrace;
            result.Code = code ?? "";
            if (ex.InnerException != null)
            {
                result.InnerException = ex.InnerException.ToProtoException();
            }

            return result;
        }
    }
}
