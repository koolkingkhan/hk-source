using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace at.hk.Parser
{
    public class TwitterParser : ParserBase<Tweet>
    {
        private Task<IDictionary<string, string>> GetParsedItems(string text)
        {
            var tcs = new TaskCompletionSource<IDictionary<string, string>>();
            var task = tcs.Task;

            Task.Factory.StartNew(() => tcs.SetResult(GetItems(text)));

            return task;
        }

        private IDictionary<string, string> GetItems(string text)
        {
            //Is this in O(N) time
            var dictionary = text.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries))
                .Where(x => !(x.Length < 2))
                .ToDictionary(x => x[0].Trim(), x => x[1].Trim());

            return dictionary;
        }

        public override void Parse(MemoryStream stream)
        {
            using (var ms = stream)
            {
                ms.Position = 0;
                using (var reader = new StreamReader(ms))
                {
                    string line;
                    while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                    {
                        var tokens = line.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);

                        var value = tokens.LastOrDefault();

                        if (!string.IsNullOrEmpty(value))
                        {
                            Parse(value);
                            Console.WriteLine(value);
                        }
                    }
                }
            }
        }

        private void Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            try
            {
                var parameters = GetParsedItems(text).Result;

                var tweet = new Tweet
                {
                    Name = GetValue(parameters, "UserName"),
                    Date = GetValue(parameters, "Date"),
                    Message = GetValue(parameters, "Message")
                };

                //Once created, broadcast message that a new tweet dto has been created
                RaiseEvent(this, tweet);
            }
            catch (AggregateException ex)
            {
                foreach (var t in ex.InnerExceptions)
                {
                    Console.WriteLine("\n------------------\n{0}", t.Message);
                }
            }
        }

        private string GetValue(IDictionary<string, string> parameters, string param)
        {
            string returnVal;
            return null != parameters && parameters.TryGetValue(param, out returnVal)
                ? returnVal
                : string.Empty;
        }
    }
}