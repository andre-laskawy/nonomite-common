///-----------------------------------------------------------------
///   File:         IMainBaseModel.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:34:27
///-----------------------------------------------------------------

namespace Nanomite.Common.Models.Base
{
    using Google.Protobuf;
    using System;

    /// <summary>
    /// Defines the <see cref="IMainBaseModel"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMainBaseModel<T> : IMainBaseModel, IBaseModel<T> where T : IMessage
    {
    }

    /// <summary>
    /// Defines the <see cref="IMainBaseModel" />
    /// </summary>
    public interface IMainBaseModel : IBaseModel
    {
        /// <summary>
        /// Gets or sets the creation date and time.
        /// </summary>
        DateTime CreatedDT { get; set; }

        /// <summary>
        /// Gets or sets the last modified date and time.
        /// </summary>
        DateTime ModifiedDT { get; set; }
    }
}
