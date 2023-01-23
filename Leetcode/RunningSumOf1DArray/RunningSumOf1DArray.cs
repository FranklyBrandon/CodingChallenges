public class Solution {
    public int[] RunningSum(int[] nums) {
        var sums = new int[nums.Length];
        var runningTotal = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            runningTotal += nums[i];
            sums[i] = runningTotal;
        }

        return sums;
    }
}