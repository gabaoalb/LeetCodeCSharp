namespace Solutions.Problems;

public class LongestConsecutiveSequenceSolution
{
    /// <summary>
    /// Brute Force approach to find the longest consecutive sequence in an array of integers.
    /// Time complexity: O(n^2) in the worst case, where n is the number of elements in the input array. This occurs when all elements are unique and form a single consecutive sequence.
    /// Space complexity: O(n) in the worst case, where n is the number of elements in the input array. This occurs when all elements are unique and stored in the hash set.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>The length of the longest consecutive elements sequence.</returns>
    public int LongestConsecutiveBruteForce(int[] nums)
    {
        HashSet<int> set = [.. nums];
        int maxLength = 0;

        foreach (int number in nums)
        {
            int current = number;
            int length = 1;
            while (set.Contains(current + 1))
            {
                current++;
                length++;
            }
            maxLength = Math.Max(maxLength, length);
        }

        return maxLength;
    }

    /// <summary>
    /// Sorting approach to find the longest consecutive sequence in an array of integers.
    /// Time complexity: O(n log n) due to the sorting step, where n is the number of elements in the input array. The rest of the algorithm runs in O(n) time.
    /// Space complexity: O(1) if the sorting is done in-place, or O(n) if a new array is created for sorting. The additional space used for variables is O(1).
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>The length of the longest consecutive elements sequence.</returns>
    public int LongestConsecutiveSorting(int[] nums)
    {
        if (nums.Length == 0) return 0;

        Array.Sort(nums);
        int maxLength = 1;
        int currentLength = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1]) continue;
            if (nums[i] == nums[i - 1] + 1)
            {
                currentLength++;
            }
            else
            {
                maxLength = Math.Max(maxLength, currentLength);
                currentLength = 1;
            }
        }

        return Math.Max(maxLength, currentLength);
    }

    /// <summary>
    /// Hash Set approach to find the longest consecutive sequence in an array of integers.
    /// Time complexity: O(n) in the average case, where n is the number of elements in the input array. This occurs when all elements are unique and form multiple consecutive sequences.
    /// Space complexity: O(n) in the worst case, where n is the number of elements in the input array. This occurs when all elements are unique and stored in the hash set.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>The length of the longest consecutive elements sequence.</returns>
    public int LongestConsecutiveHashSet(int[] nums)
    {
        HashSet<int> set = [.. nums];
        int maxLength = 0;

        foreach (int number in set)
        {
            if (set.Contains(number - 1)) continue;
            int current = number;
            int length = 1;
            while (set.Contains(current + 1))
            {
                current++;
                length++;
            }
            maxLength = Math.Max(maxLength, length);
        }

        return maxLength;
    }

    /// <summary>
    /// Hash Map approach to find the longest consecutive sequence in an array of integers. This method uses a dictionary to keep track of the lengths of consecutive sequences and updates them as it iterates through the numbers.
    /// Time complexity: O(n) in the average case, where n is the number of elements in the input array. This occurs when all elements are unique and form multiple consecutive sequences.
    /// Space complexity: O(n) in the worst case, where n is the number of elements in the input array. This occurs when all elements are unique and stored in the dictionary.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>The length of the longest consecutive elements sequence.</returns>
    public int LongestConsecutiveHashMap(int[] nums)
    {
        Dictionary<int, int> map = [];
        int maxLength = 0;

        foreach (int number in nums)
        {
            if (map.ContainsKey(number)) continue;
            int leftLength = map.GetValueOrDefault(number - 1, 0);
            int rightLength = map.GetValueOrDefault(number + 1, 0);
            int currentLength = leftLength + rightLength + 1;

            map[number] = currentLength;
            maxLength = Math.Max(maxLength, currentLength);

            if (leftLength > 0) map[number - leftLength] = currentLength;
            if (rightLength > 0) map[number + rightLength] = currentLength;
        }

        return maxLength;
    }
}
