using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Arrays
    {
        public int[] RunningSum(int[] nums)
        {
            int[] result = new int[nums.Length];
            if (nums.Length == 0) return result;
            
            result[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = nums[i] + result[i-1];
            }
            return result;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int,List<int>> valuesToIndex = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(!valuesToIndex.TryGetValue(nums[i], out List<int> indexes))
                {
                    valuesToIndex[nums[i]] = new List<int>() { i};
                    continue;
                }
                valuesToIndex[nums[i]].Add(i);
            }
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int desiredNumber = target - nums[i];
                if (valuesToIndex.TryGetValue(desiredNumber, out var indexes))
                {
                    if (indexes.Count == 1 && desiredNumber == nums[i]) continue;
                    result = new[] { i, indexes.First(j => j != i) };
                    break;
                }
            }
            return result;
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> valuesToIndex = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {                
                valuesToIndex[nums[i]] = i;                
            }

            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int desiredNumber = target - nums[i];
                if (valuesToIndex.TryGetValue(desiredNumber, out var index))
                {
                    result = new[] { i, index };
                    break;
                }
            }
            return result;
        }
    }
}
