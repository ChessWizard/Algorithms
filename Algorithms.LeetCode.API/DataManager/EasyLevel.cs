using Algorithms.LeetCode.API.DataManager.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

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
            if (substract > 0) value -= substract;

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

        public int[] TwoSum(int[] nums, int target)
        {
            var length = nums.Length;
            if (length < 2 || length > 10000) return null;

            #region O(n) Solution - Performance Way

            // O(n) solution contains just one loop
            // so we should use key value list to iterate -> we can use keyvaluepair list or dictionary
            List<KeyValuePair<int, int>> pairList = new();

            for (int i = 0; i < nums.Length; i++)
            {
                var number = nums[i];

                if(pairList.Any(x => x.Key == target - number))
                {
                    return new[] { pairList.FindIndex(x => x.Key == target - number), i };
                }

                if(!pairList.Any(x => x.Key == number))
                {
                    pairList.Add(new(number,i));
                }
            }
            return null;

            #endregion

            #region O(n ^ 2) Solution - Less Performance

            // Classical way = O(n ^ 2) solution contains two nested loops -> less performance
            //var targetIndexes = new int[2];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = 1; j < nums.Length; j++)
            //    {
            //        var currentNumber = nums[i];
            //        var compareNumber = nums[j];
            //        var isEqualsToTarget = target == (currentNumber + compareNumber);

            //        if (isEqualsToTarget)
            //        {
            //            targetIndexes[0] = Array.FindIndex(nums, x => x == currentNumber);
            //            targetIndexes[1] = Array.FindIndex(nums, x => x == compareNumber);
            //        }
            //    }
            //}
            //return targetIndexes;

            #endregion

        }
    }
}

