///-----------------------------------------------------------------
///   File:         BaseModel.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:34:28
///-----------------------------------------------------------------

namespace Nanomite.Common.Models.Base
{
    using global::System;
    using Google.Protobuf;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// This is the base class for all common models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseModel<T> : IBaseModel<T> where T : IMessage
    {
        /// <summary>
        /// Gets or sets the proto
        /// </summary>
        protected T proto { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel{T}"/> class.
        /// </summary>
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
            this.proto = (T)Activator.CreateInstance(typeof(T));
        }

        /// <inheritdoc />>
        [JsonProperty(PropertyName = "Version")]
        [JsonConverter(typeof(VersionConverter))]
        [NotMapped]
        public Version Version { get; set; }

        /// <inheritdoc />>
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        /// <inheritdoc />>
        IMessage IBaseModel.Proto => proto;

        /// <inheritdoc />>
        public IBaseModel MapToModel(IMessage proto = null)
        {
            try
            {
                if (proto != null)
                {
                    this.proto = (T)proto;
                }
            }
            catch { }

            var properties = this.proto.GetType().GetProperties().Where(p => p.CanWrite);
            foreach (var prop in properties)
            {
                var property = this.GetType().GetProperty(prop.Name);
                if (property == null)
                {
                    throw new NullReferenceException(string.Format("Property {0} of Proto not found inside the model.", prop.Name));
                }

                var value = prop.GetValue(this.proto);
                if (value != null)
                {
                    if (property.PropertyType == typeof(Guid))
                    {
                        if (string.IsNullOrEmpty(value?.ToString()))
                        {
                            value = Guid.Empty.ToString();
                        }

                        property.SetValue(this, Guid.Parse(value.ToString()));
                    }
                    if (property.PropertyType == typeof(Guid?))
                    {
                        if (string.IsNullOrEmpty(value?.ToString()))
                        {
                            value = null;
                        }
                        else
                        {
                            value = Guid.Parse(value.ToString());
                        }

                        property.SetValue(this, value);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        if (string.IsNullOrEmpty(value?.ToString()))
                        {
                            value = DateTime.MinValue;
                        }

                        DateTime dt = DateTime.MinValue;
                        try
                        {
                            if (!DateTime.TryParse(value.ToString(), out dt))
                            {
                                dt = Convert.ToDateTime(value.ToString(), new CultureInfo("de-de"));
                            }
                        }
                        catch { }

                        property.SetValue(this, dt);
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        DateTime? dt = null;
                        if (!string.IsNullOrEmpty(value?.ToString()))
                        {
                            try
                            {
                                DateTime dtValue;
                                if (!DateTime.TryParse(value.ToString(), out dtValue))
                                {
                                    dtValue = Convert.ToDateTime(value.ToString(), new CultureInfo("de-de"));
                                }
                                dt = dtValue;
                            }
                            catch { }
                        }

                        property.SetValue(this, dt);
                    }
                    else if (property.PropertyType == typeof(string)
                        || property.PropertyType == typeof(bool)
                         || property.PropertyType == typeof(int)
                        || property.PropertyType == typeof(double)
                        || property.PropertyType == typeof(float))
                    {
                        property.SetValue(this, value);
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(this, value);
                    }
                }
            }

            this.MapSepcificToModel(this.proto);
            return this;
        }

        /// <inheritdoc />>
        public IMessage MapToProto()
        {
            var properties = this.proto.GetType().GetProperties().Where(p => p.CanWrite);
            foreach (var prop in properties)
            {
                var property = this.GetType().GetProperty(prop.Name);
                if (property == null)
                {
                    throw new NullReferenceException(string.Format("Property {0} of Proto not found inside the model.", prop.Name));
                }

                var value = property.GetValue(this);
                if (value != null)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        if (value != null)
                        {
                            prop.SetValue(this.proto, ((DateTime)value).ToUniversalTime().ToString("s", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            prop.SetValue(this.proto, "");
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        if (value != null)
                        {
                            prop.SetValue(this.proto, (value as DateTime?).Value.ToUniversalTime().ToString("s", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            prop.SetValue(this.proto, "");
                        }
                    }
                    else if (property.PropertyType == typeof(Guid)
                        || property.PropertyType == typeof(Guid?)
                        || property.PropertyType == typeof(Version)
                        || property.PropertyType == typeof(string))
                    {
                        prop.SetValue(this.proto, value?.ToString() ?? "");
                    }
                    else if (property.PropertyType == typeof(bool)
                        || property.PropertyType == typeof(int)
                        || property.PropertyType == typeof(double)
                        || property.PropertyType == typeof(float))
                    {
                        if (prop.PropertyType == typeof(Single))
                        {
                            prop.SetValue(this.proto, Convert.ToSingle(value));
                        }
                        else
                        {
                            prop.SetValue(this.proto, value);
                        }
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        prop.SetValue(this.proto, value);
                    }
                }
            }

            return this.MapSpecificToProto();
        }

        /// <inheritdoc/>
        public T Map()
        {
            return (T)this.MapToProto();
        }

        /// <inheritdoc/>
        protected abstract T MapSpecificToProto();

        /// <inheritdoc/>
        protected abstract void MapSepcificToModel(T proto);
    }
}
