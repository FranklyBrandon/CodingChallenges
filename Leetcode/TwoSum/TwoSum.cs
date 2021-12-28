public class Solution {
    public int[] TwoSum(int[] nums, int target) 
    {
        int len = nums.Count() - 1;
        for(int i = 0; i <= len; i++) 
        {
            for(int j = 0; j <= len; j++)
            {
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