namespace Solutions.Problems;

public class ContainsDuplicateSolution
{
    public bool ContainsDuplicateBruteForce(int[] nums)
    {
        for (int x = 0; x < nums.Length; x++)
            for (int y = x + 1; y < nums.Length; y++)
                if (nums[x] == nums[y])
                    return true;

        return false;
    }

    public bool ContainsDuplicateSorting(int[] nums)
    {
        nums.Sort();

        for (int x = 1; x < nums.Length; x++)
            if (nums[x] == nums[x - 1])
                return true;

        return false;
    }

    public bool ContainsDuplicateHashSet(int[] nums)
    {
        var hashSet = new HashSet<int>();

        foreach (int num in nums)
        {
            if (hashSet.Contains(num))
                return true;
            hashSet.Add(num);
        }

        return false;
    }

    /// <summary>
    /// HashSet Length Solution
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool ContainsDuplicate(int[] nums)
    {
        var hashSet = nums.ToHashSet();
        return hashSet.Count != nums.Length;
    }
}
