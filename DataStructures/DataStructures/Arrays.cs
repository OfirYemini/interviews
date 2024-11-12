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
        
        //todo: improve performance & memory
        public int MinMeetingRooms(int[][] intervals) 
        {
            // {5,10}, {5,30}, {15,20}
            // other end < my start || my end < other start
            //    --------------
            //  ----   ---   -----
            SortedDictionary<int, List<int>> meetingsByStartDate = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < intervals.Length; i++) //nlogn
            {
                meetingsByStartDate.TryGetValue(intervals[i][0], out var meetingsIndexes);
                meetingsIndexes = meetingsIndexes ?? new List<int>();
                meetingsIndexes.Add(i);
                meetingsByStartDate[intervals[i][0]] = meetingsIndexes;
            }
            
            List<List<int>> rooms = new List<List<int>>();
            foreach (var kvp in meetingsByStartDate)
            {
                foreach (var meetingIndex in kvp.Value)
                {
                    // find suitable room, if non exists add one
                    var currentMeeting = intervals[meetingIndex];
                    var eligibleRooms = rooms.Where(room =>
                    {
                        var lastMeeting = intervals[room.Last()];
                        return lastMeeting[1] <= currentMeeting[0];
                    });
                    var selectedRoom = eligibleRooms.OrderByDescending(r=>intervals[r.Last()][1]).FirstOrDefault();
                    if (selectedRoom == null)
                    {
                        rooms.Add([meetingIndex]);
                    }
                    else
                    {
                        selectedRoom.Add(meetingIndex);
                    }    
                }
                
            }
            
            return rooms.Count;
        }
        
        /// <summary>
        /// Trapping rain water
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int trappedWater = 0;
            int prevMaxHeightIndex = -1;
            int maxAfterPrevIndex = -1;
            for (int i = 0; i < height.Length; i++)
            {
                var currentHeight = height[i];
                
                var prevMaxHeight = prevMaxHeightIndex == -1 ? 0 : height[prevMaxHeightIndex];
                maxAfterPrevIndex = maxAfterPrevIndex == -1 || height[maxAfterPrevIndex] <= currentHeight ? i:maxAfterPrevIndex;
                if (currentHeight >= prevMaxHeight)
                {
                    if (prevMaxHeightIndex == -1)
                    {
                        prevMaxHeightIndex = i;
                        maxAfterPrevIndex = -1;
                        continue;
                    }
                    trappedWater += CalcWater(prevMaxHeightIndex, i, height);
                    prevMaxHeightIndex = i;
                    maxAfterPrevIndex = -1;
                }
            }

            if (prevMaxHeightIndex < height.Length - 1)
            {
                trappedWater += CalcWater(prevMaxHeightIndex, maxAfterPrevIndex, height);   
            }
            //find max, iterate over and if found new max, calc water beteween currentMax and prevoius max
            return trappedWater;
        }

        private int CalcWater(int prevMaxIndex, int currentMaxIndex, int[] height)
        {
            int totalWaterUnits = 0;
            if (prevMaxIndex == currentMaxIndex-1) return 0;
            int waterSurface = Math.Min(height[prevMaxIndex], height[currentMaxIndex]);
            for (int i = prevMaxIndex+1; i < currentMaxIndex; i++)
            {
                totalWaterUnits += waterSurface - height[i];   
            }
            return totalWaterUnits;
        }
    }
}
