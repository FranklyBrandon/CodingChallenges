public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if(s.Length != t.Length)
            return false;

        var sStringMap = GetStringCharMap(s);
        var tStringMap = GetStringCharMap(t);

        for(int i = 0; i < s.Length; i++)
        {
            if(sStringMap[i] != tStringMap[i])
                return false;
        }

        return true;
    }

    public int[] GetStringCharMap(string x) 
    {
        var set = new Dictionary<char, int>();
        var uniqueCharCount = 0;
        var result = new int[x.Length];

        for(int i = 0; i < x.Length; i++)
        {
            char character = x[i];
            int charId = 0;
            // Find if character already has an Id, populate charId if so
            if (!set.TryGetValue(character, out charId))
            {
                // If it does not, set the char id equal to the uniqueCharCount then increment
                set.Add(character, uniqueCharCount);
                uniqueCharCount ++;
            }

            result[i] = charId;
        }

        return result;
    }
}