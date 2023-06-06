using Algorithms.LeetCode.API.DataManager.Interfaces;

namespace Algorithms.LeetCode.API.DataManager
{
    public class EasyLevel : IEasyLevel
    {
        public int RomanToInt(string word)
        {
            // be case insensitive for our roman list
            word = word.ToUpper();

            List<KeyValuePair<char, int>> romanList = new()
            {
                new('I',1),
                new('V',5),
                new('X',10),
                new('L',50),
                new('C',100),
                new('D',500),
                new('M',1000),
            };
            var length = word.Length;
            var isValid = word.Where(x => !romanList.Select(x => x.Key).Contains(x)).ToList();

            if (length > 15 || length < 1 || isValid.Any()) return 0;

            int value = 0;

            var distinctList = word.GroupBy(x => x).ToList();

            foreach (var item in distinctList)
            {
                var romanValue = romanList.Where(x => x.Key == item.Key).Select(x => x.Value).FirstOrDefault();
                if (romanValue is not 0) value += romanValue * item.Count();
            }

            var substract = CheckSpecialRomanConditions(word);
            if(substract > 0) value -= substract;

            if (value < 1 || value > 3999) return 0;

            return value;
        }

        private int CheckSpecialRomanConditions(string s)
        {
            var zipped = s.Skip(1).Zip(s, (current, previous) => new { Current = current, Previous = previous }).ToList();

            var substractValue = 0;
            for (int i = 0; i < zipped.Count; i++)
            {
                var current = zipped[i].Current;
                var previous = zipped[i].Previous;

                if ((current is 'V' && previous is 'I')
                    || current is 'X' && previous is 'I')
                {
                    substractValue += 2;// EX: VI -> 6 , IV -> 4 = 6 - 4 = 2
                    i++;// pass next zipped
                }

                if ((current is 'L' && previous is 'X')
                    || current is 'C' && previous is 'X')
                {
                    substractValue += 20;// EX: LX -> 60 , XL -> 40 = 60 - 40 = 20
                    i++;
                }

                if ((current is 'D' && previous is 'C')
                    || current is 'M' && previous is 'C')
                {
                    substractValue += 200;// EX: DC -> 600 , CD -> 400 = 600 - 400 = 200
                    i++;
                }
            }

            return substractValue;
        }
    }
}

