namespace Solutions.Problems;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstringBruteForce(string s)
    {
        int result = 0;

        for (int left = 0; left < s.Length; left++)
        {
            var hashSet = new HashSet<char>();
            for (int right = left + 1; right < s.Length; right++)
            {
                if (hashSet.Contains(s[right]))
                    break;

                hashSet.Add(s[right]);
            }
            result = Math.Max(result, hashSet.Count);
        }

        return result;
    }

    public int LengthOfLongestSubstringSlidingWindow(string s)
    {
        HashSet<char> hashSet = [];
        (int left, int result) = (0, 0);

        for (int right = 0; right < s.Length; right++)
        {
            while (hashSet.Contains(s[right]))
            {
                hashSet.Remove(s[left]);
                left++;
            }

            hashSet.Add(s[right]);
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }

    public int LengthOfLongestSubstringSlidingWindowOptimized(string s)
    {
        Dictionary<char, int> hashMap = [];
        (int left, int result) = (0, 0);

        for (int right = 0; right < s.Length; right++)
        {
            if (hashMap.TryGetValue(s[right], out int value))
                left = Math.Max(value + 1, left);

            hashMap[s[right]] = right;
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
