///-----------------------------------------------------------------
///   File:         SerializerExtensions.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:33:59
///-----------------------------------------------------------------

namespace Nanomite
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the <see cref="SerializerExtensions"/>
    /// </summary>
    public static class SerializerExtensions
    {
        /// <summary>
        /// Serializes the specified model to <c>json</c>.
        /// </summary>
        /// <param name="model">The <see cref="object"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string Serialize(this object model)
        {
            string result = string.Empty;

            try
            {
                JsonSerializerSettings settins = new JsonSerializerSettings();
                settins.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                settins.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                result = JsonConvert.SerializeObject(model, settins);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not serialize Model of Type " + model.GetType(), ex);
            }

            return result;
        }
    }
}
