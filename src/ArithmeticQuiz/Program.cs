using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            quiz.EnterName();
            quiz.AskQuestions(5);
            Console.Read();
        }
    }
}
