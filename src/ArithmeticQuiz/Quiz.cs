using System;

namespace ArithmeticQuiz
{
    public class Quiz
    {
        private IConsoleReader _reader;
        private string _name;
        private readonly Random random = new Random(Environment.TickCount);

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

        public void AskQuestions(int noOfQuestions)
        {
            Console.WriteLine("You will now be asked {0} random questions.", noOfQuestions);
            Console.WriteLine(Environment.NewLine);

            var correctlyAnswered = 0;

            for (var i = 1; i <= noOfQuestions; i++)
            {
                Console.WriteLine("Question {0}: ", i);
                var firstNumber = random.Next(10);
                var secondNumber = random.Next(10);

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
            Console.WriteLine("With a score of: {0}%", (correctlyAnswered/(double) noOfQuestions*100.0).ToString("#.##"));
        }

        private bool AskQuestion(int firstNumber, int secondNumber)
        {
            var getOperand = random.Next(0, 3);
            string operand;
            int correctAnswer;

            switch ((Operands) getOperand)
            {
                case Operands.Subtraction:
                    operand = "-";
                    correctAnswer = firstNumber - secondNumber;
                    break;
                case Operands.Multiplcation:
                    operand = "*";
                    correctAnswer = firstNumber*secondNumber;
                    break;
                default:
                case Operands.Addtion:
                    operand = "+";
                    correctAnswer = firstNumber + secondNumber;
                    break;
            }

            var theirAnswer = GetTheirAnswer(firstNumber, secondNumber, operand);

            return correctAnswer == theirAnswer;
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
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("{0} is not a valid number. Try again.", input);
                }
            } while (!validNumber);

            return a;
        }

        private enum Operands
        {
            Addtion = 0,
            Subtraction = 1,
            Multiplcation = 2,
            Division = 3
        }
    }
}