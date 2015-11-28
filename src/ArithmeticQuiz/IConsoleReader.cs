using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticQuiz
{
    public interface IConsoleReader
    {
        string Read();
    }

    public class ConsoleReader : IConsoleReader
    {
        public string Read() 
        {
            return Console.ReadLine();
        }
    }
}
