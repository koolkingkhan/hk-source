using System;
using System.IO;

namespace at.hk.ConsoleApp
{
    /// <summary>
    /// Class used to create sample output
    /// </summary>
    class Program2
    {
        static void Main(string[] args)
        {
            string outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Samples\");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            using (StreamWriter writer = new StreamWriter(outputPath + "tweets.txt"))
            {
                for (int i = 0; i < 2000; i++)
                {
                    writer.WriteLine(string.Format("UserName = {0} | Date = {1} | Message = {2}", Environment.UserName,
                                               RandomDay().ToShortDateString(), RandomStr()));
                }
            }
        }

        public static string RandomStr()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", "");
            return rStr;
        }

        static Random gen = new Random();

        static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);

            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
