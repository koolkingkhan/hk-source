﻿using System.Collections.Generic;

namespace hk.TelephonePermutations
{
    public class Permutations
    {
        public static List<string> PrintPhoneNumberPermutations(string phoneNum)
        {
            var m = new Dictionary<char, string>(10);
            m['0'] = "0";
            m['1'] = "abc";
            m['2'] = "def";
            m['3'] = "ghi";
            m['4'] = "jkl";
            m['5'] = "mno";
            m['6'] = "pqr";
            m['7'] = "stu";
            m['8'] = "vwx";
            m['9'] = "yz";

            List<string> finalStrs = null;
            foreach (var c in phoneNum)
            {
                var newStrs = new List<string>();

                // First time in loop
                if (finalStrs == null)
                {
                    finalStrs = new List<string>();
                    foreach (var d in m[c])
                    {
                        finalStrs.Add(d.ToString());
                    }
                    continue;
                }

                // Sebsequent times in loop do permutations
                foreach (var d in m[c])
                {
                    foreach (var prevStr in finalStrs)
                    {
                        newStrs.Add(prevStr + d);
                    }
                }

                finalStrs = newStrs;
            }

            return finalStrs;
            //foreach (string s in finalStrs)
            //{
            //    System.Diagnostics.Debug.WriteLine(s);
            //}
        }
    }
}