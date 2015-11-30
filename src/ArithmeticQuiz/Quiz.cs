using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticQuiz
{
    public class Quiz
    {
        private readonly IConsoleReader _reader;
        private string _name;

        public Quiz(IConsoleReader reader)
        {
            _reader = reader;
        }

        public void EnterName()
        {
            Console.WriteLine("Enter your full name:");
            _name = _reader.Read();
            Console.Write("Hello {0}. ", _name);
        }

        public string User { get { return _name; } }

        public double PercentageScore { get; set; }

        public void AskQuestions(IList<IQuestion> questions)
        {
            var initialOutput = "You will now be asked {0} random question" + (questions.Count == 1 ? "." : "s.");
            Console.WriteLine(initialOutput, questions.Count);
            Console.WriteLine(Environment.NewLine);

            for (var i = 1; i <= questions.Count; i++)
            {
                Console.WriteLine("Question {0}: ", i);

                var correct = AskQuestion(questions[i-1]);

                if (correct)
                {
                    Console.WriteLine("That is correct! Well done.");
                }
                else
                {
                    Console.WriteLine("That is incorrect.");
                }
                Console.WriteLine(Environment.NewLine);
            }

            CalculateScore(questions);
        }

         void CalculateScore(IList<IQuestion> questions)
        {
            int correctlyAnswered = questions.TakeWhile(q => q.TheirAnswer.HasValue && q.CorrectAnswer == q.TheirAnswer.Value).Count();
            PercentageScore = (correctlyAnswered / (double)questions.Count * 100.0);

            Console.WriteLine("You have correctly answered {0} out of {1} Questions.", correctlyAnswered, questions.Count);
            Console.WriteLine("With a score of: {0}%", PercentageScore.ToString("#.##"));
        }

        private bool AskQuestion(IQuestion question)
        {
            question.TheirAnswer = GetTheirAnswer(question.Lhs, question.Rhs, question.OperandAsString);

            return question.CorrectAnswer == question.TheirAnswer;
        }

        private int GetTheirAnswer(int firstNumber, int secondNumber, string operand)
        {
            var validNumber = false;
            int a;
            do
            {
                Console.WriteLine("What is {0} {1} {2}?", firstNumber, operand, secondNumber);
                var input = _reader.Read();
                if (int.TryParse(input, out a))
                {
                    Console.WriteLine("You answered: {0}", input);
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("{0} is not a valid number. Try again.", input);
                }
            } while (!validNumber);

            return a;
        }
    }
}