///-----------------------------------------------------------------
///   File:         MainBaseModel.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:34:27
///-----------------------------------------------------------------

namespace Nanomite.Common.Models.Base
{
    using Google.Protobuf;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the <see cref="MainBaseModel"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MainBaseModel<T> : BaseModel<T>, IMainBaseModel<T> where T : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainBaseModel{T}"/> class.
        /// </summary>
        protected MainBaseModel() : base()
        {
            this.CreatedDT = DateTime.UtcNow;
            this.ModifiedDT = DateTime.UtcNow;
        }

        /// <inheritdoc />>
        [JsonProperty(PropertyName = "CreatedDT")]
        public DateTime CreatedDT { get; set; }

        /// <inheritdoc />>
        [JsonProperty(PropertyName = "ModifiedDT")]
        public DateTime ModifiedDT { get; set; }
    }
}
