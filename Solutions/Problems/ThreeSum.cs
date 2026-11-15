namespace Solutions.Problems;

public class ThreeSumSolution
{
    /// <summary>
    /// Brute force approach to find all unique triplets that sum up to zero.
    /// </summary>
    /// <param name="nums">Input array of integers.</param>
    /// <returns>List of unique triplets that sum up to zero.</returns>
    public IList<IList<int>> ThreeSumBruteForce(int[] nums)
    {
        HashSet<(int, int, int)> combinations = [];

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[j] + nums[k] != 0)
                        continue;

                    int[] values = [nums[i], nums[j], nums[k]];
                    Array.Sort(values);
                    combinations.Add((values[0], values[1], values[2]));
                }
            }
        }

        return [.. combinations.Select(x => (IList<int>)[x.Item1, x.Item2, x.Item3])];
    }

    /// <summary>
    /// Hash map approach to find all unique triplets that sum up to zero.
    /// </summary>
    /// <param name="nums">Input array of integers.</param>
    /// <returns>List of unique triplets that sum up to zero.</returns>
    public IList<IList<int>> ThreeSumHashMap(int[] nums)
    {
        Array.Sort(nums);
        Dictionary<int, int> count = nums.CountBy(n => n).ToDictionary(g => g.Key, g => g.Value);

        IList<IList<int>> result = [];

        for (int i = 0; i < nums.Length; i++)
        {
            count[nums[i]]--;
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                count[nums[j]]--;
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int target = -(nums[i] + nums[j]);
                if (count.TryGetValue(target, out int value) && value > 0)
                    result.Add([nums[i], nums[j], target]);
            }

            for (int j = i + 1; j < nums.Length; j++)
                count[nums[j]]++;
        }

        return result;
    }

    /// <summary>
    /// Two pointer approach to find all unique triplets that sum up to zero.
    /// </summary>
    /// <param name="nums">Input array of integers.</param>
    /// <returns>List of unique triplets that sum up to zero.</returns>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        List<IList<int>> result = [];

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            if (nums[i] > 0)
                break;

            (int j, int k) = (i + 1, nums.Length - 1);

            while (j < k)
            {
                int partial = nums[i] + nums[j] + nums[k];

                switch (partial)
                {
                    case > 0:
                        k--;
                        break;
                    case < 0:
                        j++;
                        break;
                    default:
                        result.Add([nums[i], nums[j], nums[k]]);
                        j++;
                        k--;
                        while (j < k && nums[j] == nums[j - 1]) j++;
                        while (j < k && nums[k] == nums[k + 1]) k--;
                        break;
                }
            }
        }

        return result;
    }
}
