using System.Collections.Immutable;

namespace Solutions.Problems;

public class LongestSubstringWithoutRepeatingCharactersSolution
{
    /// <summary>
    /// Finds the longest substring without repeated characters by scanning from each starting
    /// position with a fresh set until a character repeats.
    /// <para>
    /// Expected time is O(n × min(n, k)). Auxiliary space is O(min(n, k)).
    /// Here, n is the input length and k is the alphabet size.
    /// </para>
    /// </summary>
    public int LengthOfLongestSubstringBruteForce(string s)
    {
        int result = 0;

        for (int left = 0; left < s.Length; left++)
        {
            var hashSet = new HashSet<char>();
            for (int right = left; right < s.Length; right++)
            {
                if (hashSet.Contains(s[right]))
                    break;

                hashSet.Add(s[right]);
            }
            result = Math.Max(result, hashSet.Count);
        }

        return result;
    }

    /// <summary>
    /// Finds the longest substring without repeated characters by binary searching candidate
    /// lengths and checking each candidate with a fixed-size window of character frequencies.
    /// <para>
    /// Expected time is O(n log n). Auxiliary space is O(min(n, k)).
    /// Here, n is the input length and k is the alphabet size.
    /// </para>
    /// </summary>
    public int LengthOfLongestSubstringBinarySearch(string s)
    {
        (int left, int right) = (0, s.Length + 1);

        bool HasUniqueWindow(int length)
        {
            Dictionary<char, int> frequencies = [];
            for (int i = 0; i < length; i++)
            {
                char character = s[i];
                frequencies[character] = frequencies.GetValueOrDefault(character) + 1;
            }

            if (frequencies.Count == length)
                return true;

            for (int i = length; i < s.Length; i++)
            {
                char outgoing = s[i - length];
                int remainingFrequency = frequencies[outgoing] - 1;
                if (remainingFrequency == 0)
                    frequencies.Remove(outgoing);
                else
                    frequencies[outgoing] = remainingFrequency;

                char incoming = s[i];
                frequencies[incoming] = frequencies.GetValueOrDefault(incoming) + 1;
                if (frequencies.Count == length)
                    return true;
            }

            return false;
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (HasUniqueWindow(mid))
                left = mid + 1;
            else
                right = mid;
        }

        return left - 1;
    }

    /// <summary>
    /// Finds the longest substring without repeated characters with a sliding window backed by a set.
    /// When a character repeats, shrinks the window from the left until its previous occurrence leaves.
    /// <para>
    /// Expected time is O(n). Auxiliary space is O(min(n, k)).
    /// Here, n is the input length and k is the alphabet size.
    /// </para>
    /// </summary>
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

    /// <summary>
    /// Finds the longest substring without repeated characters with a sliding window and a map of last
    /// seen indices. When a character repeats inside the window, moves the left boundary past that index.
    /// <para>
    /// Expected time is O(n). Auxiliary space is O(min(n, k)).
    /// Here, n is the input length and k is the alphabet size.
    /// </para>
    /// </summary>
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

    /// <summary>
    /// Finds the longest substring without repeated characters by tracking the longest valid suffix
    /// at each index. Extends its length by one, capped by the distance to the character's last occurrence.
    /// <para>
    /// Expected time is O(n). Auxiliary space is O(min(n, k)).
    /// Here, n is the input length and k is the alphabet size.
    /// </para>
    /// </summary>
    public int LengthOfLongestSubstringDynamicProgramming(string s)
    {
        Dictionary<char, int> lastIndex = [];
        int currentLength = 0;
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int p = -1;
            if (lastIndex.TryGetValue(s[i], out int value))
                p = value;

            lastIndex[s[i]] = i;

            currentLength = Math.Min(currentLength + 1, i - p);
            maxLength = Math.Max(maxLength, currentLength);
        }

        return maxLength;
    }
}
