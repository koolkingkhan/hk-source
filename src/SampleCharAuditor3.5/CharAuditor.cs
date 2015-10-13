using System;
using System.Collections.Generic;
using System.Linq;

namespace hk.SampleCharAuditor35
{
    public class CharAuditor : ICharAuditor
    {
        public string GetMostPrevalentChar(string input)
        {
            char[] characters = input.ToCharArray();
            List<char> uniqueCharacters = new List<char>();

            foreach (char c in characters.Where(c => !uniqueCharacters.Contains(c)))
            {
                uniqueCharacters.Add(c);
            }

            int previousCount = 0;
            char? mostPrevalent = null;
            foreach (char uniqueCharacter in uniqueCharacters)
            {
                int characterCount = characters.Where(n => (n.CompareTo(uniqueCharacter) == 0)).Count();
                if (characterCount > previousCount)
                {
                    mostPrevalent = uniqueCharacter;
                    previousCount = characterCount;
                }
            }

            if (mostPrevalent.HasValue)
            {
                return Convert.ToString(mostPrevalent);
            }

            return string.Empty;
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