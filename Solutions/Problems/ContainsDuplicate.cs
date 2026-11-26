namespace Solutions.Problems;

public class ContainsDuplicateSolution
{
    /// <summary>
    /// Compares each pair of elements and returns as soon as a duplicate is found.
    /// Uses O(n²) time in the worst case and O(1) extra space.
    /// </summary>
    public bool ContainsDuplicateBruteForce(int[] nums)
    {
        for (int x = 0; x < nums.Length; x++)
        for (int y = x + 1; y < nums.Length; y++)
            if (nums[x] == nums[y])
                return true;

        return false;
    }

    /// <summary>
    /// Sorts the input array in place and checks adjacent elements for duplicates.
    /// Uses O(n log n) time in the worst case and O(log n) stack space for sorting.
    /// </summary>
    public bool ContainsDuplicateSorting(int[] nums)
    {
        nums.Sort();

        for (int x = 1; x < nums.Length; x++)
            if (nums[x] == nums[x - 1])
                return true;

        return false;
    }

    /// <summary>
    /// Tracks seen values in a hash set and returns as soon as a value repeats.
    /// Uses O(n) expected time and O(n) extra space in the worst case.
    /// </summary>
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
    /// Builds a hash set from the entire array and checks whether it contains fewer elements than the array.
    /// Uses O(n) expected time and O(n) extra space in the worst case.
    /// </summary>
    public bool ContainsDuplicate(int[] nums)
    {
        var hashSet = nums.ToHashSet();
        return hashSet.Count != nums.Length;
    }
}
