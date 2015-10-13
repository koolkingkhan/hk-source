using System;
using System.IO;

namespace at.hk.Parser
{
    public abstract class ParserBase<T> : IParser<T> where T : class, new()
    {
        #region Implementation of IParser<T>

        public abstract void Parse(MemoryStream stream);

        public event EventHandler<DtoCreatedEventArgs<T>> DataExtractedHandler;

        #endregion

        protected void RaiseEvent(object sender, T data)
        {
            if (DataExtractedHandler != null)
            {
                DataExtractedHandler(sender, new DtoCreatedEventArgs<T>(data));
            }
        }
    }
}