from typing import List

class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        for index_i, value_i in enumerate(nums):
            # For each number in the list, check if adding it to each other number produces the target
            for index_j, value_j in enumerate(nums):
                # Ignore the index of the number we are currently checking against
                if (index_i == index_j):
                    continue
                if (value_i + value_j == target):
                    return [index_i, index_j]
            
        
        print('No solution')