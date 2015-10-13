using System;

namespace at.hk.Parser
{
    public class DtoCreatedEventArgs<T> : EventArgs where T : class
    {
        public T Data { get; set; }

        public DtoCreatedEventArgs(T dto)
        {
            Data = dto;
        }
    }
}