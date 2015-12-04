namespace ArithmeticQuiz
{
    public interface IQuestions
    {
        int TestNumber { get; set; }
        int Count { get; }
        IQuestion GetQuestion(int questionNo);
        void AddQuestion(IQuestion question);
        int GetCorrectlyAnswered();
        double CalculateScorePercentage();
    }
}