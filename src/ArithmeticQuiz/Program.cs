﻿using System;

namespace ArithmeticQuiz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var quiz = new Quiz(new ConsoleReader());
            quiz.EnterName();
            quiz.AskQuestions(5);
            Console.Read();
        }
    }
}