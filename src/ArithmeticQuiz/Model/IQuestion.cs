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
}
