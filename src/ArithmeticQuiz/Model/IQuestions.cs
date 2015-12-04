namespace ArithmeticQuiz
{
    public interface IQuestions
    {
        int TestNumber { get; set; }
        int Count { get; }
        IQuestion this[int index] { get; }
        void AddQuestion(IQuestion question);
        int GetCorrectlyAnswered();
        double CalculateScorePercentage();
    }
}