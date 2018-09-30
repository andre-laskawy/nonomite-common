///-----------------------------------------------------------------
///   File:         IBaseModel.cs
///   Author:   Andre Laskawy           
///   Date:       30.09.2018 14:34:27
///-----------------------------------------------------------------

namespace Nanomite.Common.Models.Base
{
    using Google.Protobuf;
    using System;

    /// <summary>
    /// Defines the <see cref="IBaseModel"/>
    /// </summary>
    public interface IBaseModel
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Version
        /// </summary>
        Version Version { get; set; }

        /// <summary>
        /// Gets the Proto
        /// </summary>
        IMessage Proto { get; }

        /// <summary>
        /// Maps the proto of this model to the specific entity properties.
        /// </summary>
        /// <param name="proto">(optional) can be given to map the model from another proto.</param>
        /// <returns></returns>
        IBaseModel MapToModel(IMessage proto = null);

        /// <summary>
        /// Maps the model to the specific entity properties of its proto.
        /// </summary>
        /// <returns></returns>
        IMessage MapToProto();
    }

    /// <summary>
    /// Defines the <see cref="IBaseModel{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseModel<T> : IBaseModel where T : IMessage
    {
        /// <summary>
        /// Maps the entity to the proto equivalent
        /// </summary>
        /// <returns></returns>
        T Map();
    }
}
