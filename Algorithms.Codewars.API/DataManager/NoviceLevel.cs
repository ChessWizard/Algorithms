using Algorithms.Codewars.API.DataManager.Interfaces;
using System.Globalization;
using System.Text;

namespace Algorithms.Codewars.API.DataManager
{
    public class NoviceLevel : INoviceLevel
    {
        public bool IsValidIP(string ipAddres)
        {
            /* Examples of valid inputs: 4 octet, [0,255]
                1.2.3.4
                123.45.67.89
             */

            if (string.IsNullOrEmpty(ipAddres)) return false;

            var octets = ipAddres.Split('.');

            if (octets.Contains("")) return false;// not equals to null string -> For EX: "." -> split -> "","" | "123.342.23." -> "123","342","23",""

            var isValidCharacters = octets.SelectMany(x => x.Select(y => y)).All(char.IsDigit);// is all digit and 

            if (!isValidCharacters || octets.Length != 4) return false;

            // value range -> [0,255] and not contains EX: 078, 00, 000 ...
            var isValidRange = !octets.Select(x => x).Any(x => Convert.ToInt32(x) > 255 || Convert.ToInt32(x) < 0 
                                                            || (x.Length > 1 && x.StartsWith("0")));
            
            if (!isValidRange) return false;

            return true;
        }

        public int[] MakeTheDeadfishSwim(string data)
        {
            string charset = "idso";

            // constraint check
            if (data.Any(x => !charset.Contains(x))) return null;

            int initialValue = 0;
            List<int> valueList = new();

            foreach (var item in data)
            {
                // check options using switch -> best practise
                switch (item)
                {
                    case 'i':
                        initialValue++;
                        break;

                    case 'd':
                        initialValue--;
                        break;

                    case 's':
                        initialValue = Convert.ToInt32(Math.Pow(initialValue, 2));// assign squared value as current
                        break;

                    case 'o':
                        valueList.Add(initialValue);
                        break;
                        
                    default:
                        break;
                }
            }
            return valueList.ToArray();
        }

        public string GetReadableTime(int seconds)
        {
            return "";
        }

        public int DuplicateCount(string str)
        {
            // constraints
            if (string.IsNullOrEmpty(str)) return 0;

            // using one dot per line rule
            var isAllUnique = !str.GroupBy(x => x)
                                  .Any(x => x.Count() > 1);// Find if any grouped data has been repeated more than once
            
            var isValidContent = str.All(char.IsLetterOrDigit);// it can contains letter or digit

            if(!isValidContent || isAllUnique) return 0;

            var beCaseInsensitive = str.ToLower();// counting case insensitive

            return beCaseInsensitive.GroupBy(x => x)
                                    .Where(x => x.Count() > 1)
                                    .ToList()
                                    .Count();
        }

        public IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            if(!iterable.Any()) return Enumerable.Empty<T>();// don't return null for best practise

            var list = iterable.ToList();

            List<T> uniqueList = new();
            for (int i = 1; i < list.Count(); i++)
            {
                var isUniqueItem = list[i-1];

                // first item added
                if(!uniqueList.Any()) uniqueList.Add(isUniqueItem);

                if(isUniqueItem.Equals(list[i]))
                {
                    continue;
                }
                uniqueList.Add(list[i]);
            }
            return uniqueList;
        }

        public string FirstNonRepeatingLetter(string s)
        {
            var beCaseInsensitive = s.ToLower();
            var isAllRepeating = beCaseInsensitive.GroupBy(x => x)
                                                  .All(g => g.Count() > 1);
            
            if(isAllRepeating) return string.Empty;

            if(s.Length is 1) return s;

            // store original value(case sensitive) but order by case insensitive 
            // EX: sSTjfjsd -> Output : 'T' -> not 't' 
            var firstNonRepeating = s.GroupBy(ch => ch.ToString(), StringComparer.OrdinalIgnoreCase)
                                      .Where(g => g.Count() == 1)
                                      .Select(g => g.Key)
                                      .FirstOrDefault();
            return firstNonRepeating;
        }

        public string ToWeirdCase(string s)
        {
            if(s.All(char.IsWhiteSpace)) return s;

            var words = s.Split(' ');

            StringBuilder builder = new();
            List<string> list = new();

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];

                for (int j = 0; j < word.Length; j++)
                {
                    var character = word[j];

                    if(j % 2 != 0)
                        character = char.ToLower(character, CultureInfo.GetCultureInfo("en-GB"));

                    if (j % 2 == 0)
                        character = char.ToUpper(character, CultureInfo.GetCultureInfo("en-GB"));// get global culture for string. EX: İ -> I
                    
                    // append new form
                    builder.Append(character);
                }
                builder.Append(' ');
            }
            return builder.ToString().TrimEnd();
        }

        public string Rot13(string message)
        {
            // TODO: Refactor Code Duplications

            var changableLowercaseCharset = "abcdefghijklmnopqrstuvwxyz";

            var changableUppercaseCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder builder = new();

            for (int i = 0; i < message.Length; i++)
            {
                var character = message[i];
                int changingCharIndex = 0;
                int leftoverValue = 0;
                char replaceCharacter;

                // for lowercases
                if (changableLowercaseCharset.Contains(character))
                {
                    changingCharIndex = changableLowercaseCharset.Where(x => x == character).Select(x => changableLowercaseCharset.IndexOf(x)).FirstOrDefault();
                    leftoverValue = (changingCharIndex + 13) % 26;

                    if (leftoverValue is 0)
                    {
                        replaceCharacter = changableLowercaseCharset.Skip(changingCharIndex + 13).FirstOrDefault();
                        character = replaceCharacter is '\0' ? 'a' : replaceCharacter; // EX: ...4...26 -> 4 + 13 -> OUTPUT: 17
                    }
                        
                    else
                        character = changableLowercaseCharset.Skip(leftoverValue).FirstOrDefault();// start beginning and skip EX: ...20...26 -> 20 + 13 -> OUTPUT: 7
                }

                // for uppercases
                if (changableUppercaseCharset.Contains(character))
                {
                    changingCharIndex = changableUppercaseCharset.Where(x => x == character).Select(x => changableUppercaseCharset.IndexOf(x)).FirstOrDefault();
                    leftoverValue = (changingCharIndex + 13) % 26;

                    if (leftoverValue is 0)
                    {
                        replaceCharacter = changableUppercaseCharset.Skip(changingCharIndex + 13).FirstOrDefault();
                        character = replaceCharacter is '\0' ? 'A' : replaceCharacter;
                    }
                        
                    else
                        character = changableUppercaseCharset.Skip(leftoverValue).FirstOrDefault();
                }
                builder.Append(character);
            }
            return builder.ToString();
        }
    }
}
