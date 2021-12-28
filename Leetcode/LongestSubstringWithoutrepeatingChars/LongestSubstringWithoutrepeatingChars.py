class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        longest_str = 1
        unique_chars = set()
        
        for c in s:
            # If the char is already in unique chars set it is a repeat
            # The longest substring becomes the max of the last substring and the current substring
            if (c in unique_chars):
                longest_str = max(longest_str, len(unique_chars))
                unique_chars.clear()
                unique_chars.add(c)
            # Otherwise continue to record occurring chars
            else:
                unique_chars.add(c)
                
        return longest_str

s = Solution()
s.lengthOfLongestSubstring(" ")