using System;

namespace at.hk.Parser
{
    public interface ITweet
    {
        string Name { get; set; }

        string Date { get; set; }

        string Message { get; set; }
    }
}
