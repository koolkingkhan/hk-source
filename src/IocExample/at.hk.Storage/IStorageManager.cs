namespace at.hk.Storage
{
    public interface IStorageManager
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Save<T>(string name, T data);
    }
}