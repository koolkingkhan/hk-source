namespace hk.SampleCharAuditor35
{
    public interface ICharAuditor
    {
        string GetMostPrevalentChar(string input);

        string GetFirstNSortedChars(string input, int topN);
    }
}
