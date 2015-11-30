using System.ComponentModel;

namespace ArithmeticQuiz
{
    public enum Operands
    {
        [Description("+")]
        Addition = 0,

        [Description("-")]
        Subtraction = 1,

        [Description("*")]
        Multiplication = 2,

        [Description("/")]
        Division = 3
    }
}
