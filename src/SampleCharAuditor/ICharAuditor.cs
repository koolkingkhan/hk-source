namespace hk.SampleCharAuditor
{
    public interface ICharAuditor
    {
        string GetMostPrevalentChar(string input);

        string GetFirstNSortedChars(string input, int topN);
    }
}