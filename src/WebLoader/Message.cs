using System;

namespace WebLoader
{
    public class Message
    {
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

        public string Time { get; set; }
        public string Content { get; set; }
    }
}