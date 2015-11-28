using System;
using System.ComponentModel;

namespace ArithmeticQuiz
{
    public class Quiz
    {
        private readonly IConsoleReader _reader;
        private string _name;
        private readonly IRandomQuestionGenerator _randomQuestionGenerator;

        public Quiz(IConsoleReader reader, IRandomQuestionGenerator randomQuestionGenerator)
        {
            _reader = reader;
            _randomQuestionGenerator = randomQuestionGenerator;
        }

        public void EnterName()
        {
            Console.WriteLine("Enter your full name:");
            _name = _reader.Read();
            Console.Write("Hello {0}. ", _name);
        }

        public string User { get { return _name; } }

        public int CorrectAnswer
        {
            get { return _randomQuestionGenerator.Answer; }
        }

        public int TheirAnswer { get; set; }


        public void AskQuestions(int noOfQuestions)
        {
            var questions = "You will now be asked {0} random question" + (noOfQuestions == 1?  "." : "s.");
            Console.WriteLine(questions, noOfQuestions);
            Console.WriteLine(Environment.NewLine);

            var correctlyAnswered = 0;

            for (var i = 1; i <= noOfQuestions; i++)
            {
                Console.WriteLine("Question {0}: ", i);
                var firstNumber = _randomQuestionGenerator.Lhs;
                var secondNumber = _randomQuestionGenerator.Rhs;

                var correct = AskQuestion(firstNumber, secondNumber);

                if (correct)
                {
                    correctlyAnswered = correctlyAnswered + 1;

                    Console.WriteLine("That is correct! Well done.");
                }
                else
                {
                    Console.WriteLine("That is incorrect.");
                }
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine("You have correctly answered {0} out of {1} questions.", correctlyAnswered, noOfQuestions);
            Console.WriteLine("With a score of: {0}%", (correctlyAnswered / (double)noOfQuestions * 100.0).ToString("#.##"));
        }

        private bool AskQuestion(int firstNumber, int secondNumber)
        {
            TheirAnswer = GetTheirAnswer(firstNumber, secondNumber, _randomQuestionGenerator.OperandAsString);

            return CorrectAnswer == TheirAnswer;
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

        public enum Operands
        {
            [Description("+")]
            Addtion = 0,

            [Description("-")]
            Subtraction = 1,

            [Description("*")]
            Multiplcation = 2,

            [Description("/")]
            Division = 3
        }

        public void QuestionsAndAnswers()
        {


        }
    }
}