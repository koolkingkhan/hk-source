using System;

namespace at.hk.Storage
{
    public class DatabaseStorageManager : IStorageManager
    {
        #region Implementation of IStorageManager

        public bool Save<T>(string name, T data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}