using System;

namespace ArithmeticQuiz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var randomQuestionGenerator = new RandomQuestionGenerator();
            var questions = randomQuestionGenerator.GenerateQuestions(5);

            var quiz = new Quiz(new ConsoleReader());
            quiz.EnterName();
            quiz.AskQuestions(questions);

            Console.Read();
        }
    }
}