using System.ComponentModel;

namespace ArithmeticQuiz
{
    public interface IQuestion
    {
        int Lhs { get; }
        int Rhs { get; }
        Operands Operand { get; }
        string OperandAsString { get; }
        int CorrectAnswer { get; }
        int? TheirAnswer { get; set; }
    }

    public class Question : IQuestion
    {
        public int Lhs { get; private set; }
        public int Rhs { get; private set; }
        public Operands Operand { get; private set; }
        public string OperandAsString { get; private set; }

        public Question(int lhs, int rhs, Operands operand)
        {
            Lhs = lhs;
            Rhs = rhs;
            Operand = operand;
            OperandAsString = Operand.GetAttribute<DescriptionAttribute>();
        }

        public int CorrectAnswer
        {
            get
            {
                switch (Operand)
                {
                    case Operands.Subtraction:
                        return Lhs - Rhs;
                    case Operands.Multiplication:
                        return Lhs * Rhs;
                    default:
                    case Operands.Addition:
                        return Lhs + Rhs;
                }
            }
        }

        public int? TheirAnswer { get; set; }
    }
}
