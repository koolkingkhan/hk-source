using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ArithmeticQuiz
{
    class RandomQuestionGenerator : IRandomQuestionGenerator
    {
        private readonly Random _random = new Random(Environment.TickCount);

        public IQuestions GenerateQuestions(int i)
        {
            if (i <= 0)
            {
                throw new ArgumentException("Count must be greater than 0");
            }

            IQuestions questions = new Questions();

            for (int j = 1; j <= i; j++)
            {
                questions.AddQuestion(new Question(
                                lhs: _random.Next(10),
                                rhs: _random.Next(10),
                                operand: (Operands) _random.Next(0, 3)
                                ));
            }

            return questions;
        }
    }
}