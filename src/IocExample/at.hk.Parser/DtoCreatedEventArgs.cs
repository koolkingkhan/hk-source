using System;

namespace at.hk.Parser
{
    public class DtoCreatedEventArgs<T> : EventArgs where T : class
    {
        public DtoCreatedEventArgs(T dto)
        {
            Data = dto;
        }

        public T Data { get; set; }
    }
}