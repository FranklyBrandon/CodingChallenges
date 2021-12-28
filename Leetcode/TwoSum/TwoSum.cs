public class Solution {
    public int[] TwoSum(int[] nums, int target) 
    {
        int len = nums.Count() - 1;
        // For each number in the list, check if adding it to each other number produces the target
        for(int i = 0; i <= len; i++) 
        {
            for(int j = 0; j <= len; j++)
            {
                // Ignore the index of the number we are currently checking against
                if(j==i)
                    continue;
                
                if(nums[i] + nums[j] == target)
                {
                    return new int[2]
                    {
                        i,
                        j
                    };
                }
            }
        }
        
        throw new Exception("No solution found");
    }
}