using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticQuiz
{
    public interface IRandomQuestionGenerator
    {
        void GenerateQuestion();
        int Lhs { get; }
        int Rhs { get; }
        Quiz.Operands Operand { get; }
        int Answer { get; }
        string OperandAsString { get; }
    }



    class RandomQuestionGenerator : IRandomQuestionGenerator
    {
        private readonly Random _random = new Random(Environment.TickCount);

        public void GenerateQuestion()
        {
            Lhs = _random.Next(10);
            Rhs = _random.Next(10);
            Operand = (Quiz.Operands)_random.Next(0, 3);
            OperandAsString = Operand.GetAttribute<DescriptionAttribute>();
        }

        public int Lhs { get; private set; }

        public int Rhs { get; private set; }

        public Quiz.Operands Operand { get; private set; }

        public string OperandAsString { get; private set; }

        public int Answer
        {
            get
            {
                switch (Operand)
                {
                    case Quiz.Operands.Subtraction:
                        return Lhs - Rhs;
                    case Quiz.Operands.Multiplcation:
                        return Lhs * Lhs;
                    default:
                    case Quiz.Operands.Addtion:
                        return Lhs + Rhs;
                }
            }
        }
    }
}
