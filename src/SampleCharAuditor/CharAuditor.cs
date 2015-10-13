using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace hk.SampleCharAuditor
{
    public class CharAuditor : ICharAuditor
    {
        public string GetMostPrevalentChar(string input)
        {
            Dictionary<char, int> charactersCount = new Dictionary<char, int>();
            char? returnVal = null;

            foreach (char c in input)
            {
                if (charactersCount.ContainsKey(c))
                {
                    charactersCount[c]++;
                    int temp = charactersCount[c];
                    if (returnVal.HasValue && charactersCount[returnVal.Value] < temp)
                    {
                        returnVal = c;
                    }
                }
                else
                {
                    charactersCount[c] = 1;
                    if (!returnVal.HasValue)
                    {
                        returnVal = c;
                    }
                }
            }

            return returnVal != null ? returnVal.Value.ToString(CultureInfo.InvariantCulture) : null;
        }

        public string GetFirstNSortedChars(string input, int topN)
        {
            List<char> characters = new List<char>(input.ToCharArray());
            characters.Sort();

            string str = characters.Aggregate(string.Empty, (current, character) => current + character);
            
            if (topN < str.Length)
            {
                return str.Substring(0, topN);    
            }

            return str;
        }
    }
}