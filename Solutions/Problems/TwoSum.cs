namespace Solutions.Problems;

public class TwoSumSolution
{
    /// <summary>
    /// Brute Force
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSumBruteForce(int[] nums, int target)
    {
        for (int x = 0; x < nums.Length; x++)
            for (int y = x + 1; y < nums.Length; y++)
                if (nums[x] + nums[y] == target)
                    return [x, y];

        return [];
    }

    /// <summary>
    /// Sorting two pointers
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSumSorting(int[] nums, int target)
    {
        var sorted = nums.Select((num, index) => (num, index)).OrderBy(x => x.num).ToArray();
        (int left, int right) = (0, sorted.Length - 1);

        while (left < right)
        {
            int sum = sorted[left].num + sorted[right].num;
            if (sum == target)
                return [sorted[left].index, sorted[right].index];
            else if (sum < target)
                left++;
            else
                right--;
        }

        return [];
    }

    /// <summary>
    /// HashMap two pass
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSumHashMapTwoPass(int[] nums, int target)
    {
        Dictionary<int, int> hashMap = [];

        // hashMap = nums.Select((value, index) => (value, index)).ToDictionary(x => x.value, x => x.index);
        for (int index = 0; index < nums.Length; index++)
            hashMap[nums[index]] = index;

        for (int index = 0; index < nums.Length; index++)
        {
            int diff = target - nums[index];
            if (hashMap.TryGetValue(diff, out int value) && value != index)
                return [index, value];
        }

        return [];
    }

    /// <summary>
    /// HashMap one pass
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> hashMap = [];

        for (int index = 0; index < nums.Length; index++)
        {
            int diff = target - nums[index];
            if (hashMap.TryGetValue(diff, out int value))
                return [value, index];
            hashMap[nums[index]] = index;
        }

        return [];
    }
}
