using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticQuiz
{
    public class Quiz
    {
        private readonly IConsoleReader _reader;
        private Student _currentStudent;

        public Quiz(IConsoleReader reader)
        {
            _reader = reader;
        }

        public Student EnterName()
        {
            Console.WriteLine("Enter your first name:");
            string firstName = _reader.Read();

            Console.WriteLine("Enter your second name:");
            string lastName = _reader.Read();
            Console.Write("Hello {0} {1}. ", firstName, lastName);

            return _currentStudent = new Student(firstName, lastName);
        }

        public string User
        {
            get
            {
                return _currentStudent.FullName;
            }
        }

        public void AskQuestionsToStudent(IQuestions questions, Student student)
        {
            var initialOutput = "You will now be asked {0} random question" + (questions.Count == 1 ? "." : "s.");
            Console.WriteLine(initialOutput, questions.Count);
            Console.WriteLine(Environment.NewLine);

            for (var i = 1; i <= questions.Count; i++)
            {
                Console.WriteLine("Question {0}: ", i);

                var correct = AskQuestion(questions.GetQuestion(i));

                Console.WriteLine(correct ? "That is correct! Well done." : "That is incorrect.");

                Console.WriteLine(Environment.NewLine);
            }

            var correctlyAnswered = questions.GetCorrectlyAnswered();
            var score = questions.CalculateScorePercentage();
            student.AddScore(questions.TestNumber, score);

            Console.WriteLine("You have correctly answered {0} out of {1} Questions.", correctlyAnswered, questions.Count);
            Console.WriteLine("With a score of: {0}%", (score.CompareTo(0) == 0? "0": score.ToString("#.##")));
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