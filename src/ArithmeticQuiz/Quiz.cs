﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticQuiz
{
    public class Quiz
    {
        private string name;
        private Random random = new Random(Environment.TickCount);

        private enum Operands
        {
            Addtion = 0,
            Subtraction = 1,
            Multiplcation = 2,
            Division = 3
        };

        public void EnterName()
        {
            Console.WriteLine("Enter your full name:");
            name = Console.ReadLine();
            Console.Write("Hello {0}. ", name);

        }

        public void AskQuestions(int noOfQuestions)
        {
            Console.WriteLine("You will now be asked {0} random questions.", noOfQuestions);
            Console.WriteLine(Environment.NewLine);

            int correctlyAnswered = 0;

            for (int i = 1; i <= noOfQuestions; i++)
            {
                Console.WriteLine("Question {0}: ", i);
                int firstNumber = random.Next(10);
                int secondNumber = random.Next(10);

                bool correct = AskQuestion(firstNumber, secondNumber);

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
            Console.WriteLine("With a score of: {0}%", (((double)correctlyAnswered / (double)noOfQuestions) * 100.0).ToString("#.##"));
        }

        private bool AskQuestion(int firstNumber, int secondNumber)
        {
            int getOperand = random.Next(0, 3);
            string operand;
            int correctAnswer;

            switch ((Operands)getOperand)
            {
                case Operands.Subtraction:
                    operand = "-";
                    correctAnswer = firstNumber - secondNumber;
                    break;
                case Operands.Multiplcation:
                    operand = "*";
                    correctAnswer = firstNumber * secondNumber;
                    break;
                default:
                case Operands.Addtion:
                    operand = "+";
                    correctAnswer = firstNumber + secondNumber;
                    break;
            }

            int theirAnswer = GetTheirAnswer(firstNumber, secondNumber, operand);

            return correctAnswer == theirAnswer;
        }

        private int GetTheirAnswer(int firstNumber, int secondNumber, string operand)
        {
            bool validNumber = false;
            int a;
            do
            {
                Console.WriteLine("What is {0} {1} {2}?", firstNumber, operand, secondNumber);
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out a))
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
    }
}