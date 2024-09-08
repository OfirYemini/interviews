using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises
{
    internal class StringsQuestions
    {
        public int LengthOfLongestSubstring(string s)
        {            
            int maxLength = 0;
            HashSet<char> chars = new HashSet<char>();
            int currentIndex = 0;
            for (int i = 0; currentIndex < s.Length; i++)
            {   
                if(chars.Count > 0)
                {
                    int startIndex = currentIndex - chars.Count;
                    int indexOfRepeatedChar = s.IndexOf(s[currentIndex],startIndex);
                    int startOfSustring = currentIndex - chars.Count;
                    while(indexOfRepeatedChar - startOfSustring >=0)
                    {
                        chars.Remove(s[indexOfRepeatedChar--]);
                    }                                      
                    
                }
                    
                do
                {
                    chars.Add(s[currentIndex]);
                    currentIndex++;


                } while (currentIndex < s.Length && !chars.Contains(s[currentIndex]));

                maxLength = Math.Max(maxLength, chars.Count);
                var maxSubString = s.Substring(currentIndex-chars.Count, chars.Count);
                if(maxLength > s.Length - currentIndex + chars.Count)
                    break;
            }

            return maxLength;
        }

        public int LengthOfLongestSubstring2(string s)
        {
            
            int maxLength = 0;
            int[] charIndex = new int[128];  // ASCII characters
            Array.Fill(charIndex, -1);  // Initialize all indices to -1
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];
                int lastSeenIndex = charIndex[currentChar];

                if (lastSeenIndex >= left)
                {
                    left = lastSeenIndex + 1;
                }

                charIndex[currentChar] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        public bool IsValidParentheses(string s)
        {
            Stack<char> stack = new Stack<char>(s.Length);
            char[] open = new char [3] { '[','(','{'};
            char[] close = new char[3] { ']',')','}'};
            bool res = true;
            foreach (char ch in s)
            {
                var closeIndex = Array.IndexOf(close,ch);
                if(closeIndex==-1)
                {
                    stack.Push(ch);
                    continue;
                }
                if(stack.TryPop(out char lastChar) && lastChar == open[closeIndex])
                {
                    continue;
                }
                res = false;
                break;
            }
            return stack.Count == 0 && res;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                string sortedString = new string(str.OrderBy(c => c).ToArray());
                if (!output.TryGetValue(sortedString, out var group))
                {
                    output[sortedString] = new List<string>() { str };
                    continue;
                }
                group.Add(str);
            }
            return output.Select(kvp => new List<string>(kvp.Value)).ToList<IList<string>>();
            
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {

            Dictionary<int, List<string>> output = new Dictionary<int, List<string>>();
            foreach (var str in strs)
            {
                var bitMask = CalcBitMask(str);
                if (!output.TryGetValue(bitMask, out var group))
                {
                    output[bitMask] = new List<string>() { str };
                    continue;
                }
                group.Add(str);
            }
            return output.Select(kvp => new List<string>(kvp.Value)).ToList<IList<string>>();

        }

        private int CalcBitMask(string str)
        {
            int bitMask = 0;
            foreach (var ch in str)
            {
                var bitPosition = ch - 'a';
                bitMask |= (1 << bitPosition);
            }
            return bitMask;
        }
    }
}
