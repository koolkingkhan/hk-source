using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebLoader
{
    public class Message
    {
        public string Time { get; set; }
        public string Content { get; set; }

        public Message(string time, string content)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                throw new ArgumentNullException("time");
            }
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("content");
            }

            Time = time;
            Content = content;
        }
    }
}
