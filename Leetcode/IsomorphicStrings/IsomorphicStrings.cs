public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length)
            return false;

        var map = new Dictionary<char, char>();
        var visited = new HashSet<char>();

        for (int i = 0; i < s.Length; i++) {
            // If we have an exisitng mapping from 's' but have not visted the 't' char yet
            // it is not isomorphic
            if (!map.ContainsKey(s[i])) {
                if (visited.Contains(t[i])) {
                    return false;
                }

                // Otherwise add mapping 
                map[s[i]] = t[i];
                visited.Add(t[i]);
            } else {
                // If exisitng mapping does not match current chars, it is not isomorphic
                if (map[s[i]] != t[i]) {
                    return false;
                }
            }
        }

        return true;
    }
}