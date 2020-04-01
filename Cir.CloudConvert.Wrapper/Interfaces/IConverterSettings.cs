using System;
using Cir.CloudConvert.Wrapper.ConfigElements;

namespace Cir.CloudConvert.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ConverterSettings</c> class.
    /// </summary>
    public interface IConverterSettings : IDisposable
    {
        /// <summary>
        /// Gets or sets the basic element.
        /// </summary>
        BasicElement Basic { get; set; }
    }
}