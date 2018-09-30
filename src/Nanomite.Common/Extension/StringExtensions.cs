///-----------------------------------------------------------------
///   File:         StringExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:34:00
///-----------------------------------------------------------------

namespace Nanomite
{
    using System;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="StringExtension"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Hashes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt<see cref="string"/></param>
        /// <returns></returns>
        public static string Hash(this string password, string salt)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(salt + password));
            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// To the enum.
        /// </summary>
        /// <typeparam name="T">any kind of enum</typeparam>
        /// <param name="enumString">The <see cref="string"/></param>
        /// <returns>The <see cref="T"/></returns>
        public static T ToEnum<T>(this string enumString) where T : struct
        {
            T result = default(T);

            try
            {
                result = (T)Enum.Parse(typeof(T), enumString, true);
            }
            catch
            {
                throw new Exception("Could not convert " + enumString + " to enum of type: " + typeof(T));
            }

            return result;
        }

        /// <summary>
        /// The GetIpEndpoint
        /// </summary>
        /// <param name="address">The <see cref="string"/></param>
        /// <returns>The <see cref="IPEndPoint"/></returns>
        public static IPEndPoint ToIpEndpoint(this string address)
        {
            IPEndPoint result = null;
            string errorMessage = string.Empty;

            Task.Run(async () =>
           {
               try
               {
                   Uri url;
                   IPAddress ip;
                   if (Uri.TryCreate(String.Format("http://{0}", address), UriKind.Absolute, out url) &&
                      IPAddress.TryParse(url.Host, out ip))
                   {
                       result = new IPEndPoint(ip, url.Port);
                   }

                   IPAddress[] IpInHostAddress = await Dns.GetHostAddressesAsync(url.Host);
                   result = new IPEndPoint(IpInHostAddress[0].MapToIPv4(), url.Port);
               }
               catch
               {
                   errorMessage = "Address is not valid or could not be found: " + address;
               }
           });

            while (result == null && string.IsNullOrEmpty(errorMessage))
            {
                Task.Delay(5).Wait();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception("Address is not valid or could not be found: " + address);
            }

            return result;
        }

        /// <summary>
        /// To the type of the model.
        /// </summary>
        /// <param name="typeString">The <see cref="string"/></param>
        /// <returns>The <see cref="Type"/></returns>
        public static Type ToModelType(this string typeString)
        {
            Type result = null;

            if (!string.IsNullOrEmpty(typeString))
            {
                try
                {
                    result = Type.GetType(typeString);
                    if (result == null)
                    {
                        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                        foreach (var assembly in assemblies)
                        {
                            var t = assembly.GetType(typeString);
                            if (t != null)
                            {
                                result = t;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    throw new Exception("Could not convert to model type: " + typeString);
                }
            }

            return result;
        }
    }
}
