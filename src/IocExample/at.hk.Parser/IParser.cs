using System;
using System.IO;

namespace at.hk.Parser
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParser<T> where T : class, new()
    {
        /// <summary>
        /// Text to parse and perform an action on
        /// </summary>
        void Parse(MemoryStream stream);

        /// <summary>
        /// 
        /// </summary>
        event EventHandler<DtoCreatedEventArgs<T>> DataExtractedHandler;
    }
}   