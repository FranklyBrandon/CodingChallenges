public class Solution {
    public int PivotIndex(int[] nums) {
        var leftSum = 0;
        var rightSum = nums.Sum();

        for (int i = 0; i < nums.Length; i++)
        {
            // Calculate the sum of the right side by subtracting the index num
            // from the total sum on each iteration
            rightSum -= nums[i];
            if (rightSum == leftSum)
                return i; 

            // Only add the current num iteration to the left sum after the check
            // because the index is not inclusive of the current iteration
            leftSum += nums[i];
        }

        return -1;
    }
}