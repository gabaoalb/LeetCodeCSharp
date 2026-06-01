namespace Solutions.Problems;

public class ProductOfArrayExceptSelfSolution
{
    /// <summary>
    /// Division approach: O(n) time, O(1) space (excluding output array)
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>An array where each element is the product of all other elements except itself.</returns>
    public int[] ProductExceptSelf(int[] nums)
    {
        int zeros = nums.Count(n => n == 0);

        if (zeros > 1)
            return new int[nums.Length];
        if (zeros == 1)
            return [.. nums.Select(n => n == 0 ? nums.Where(x => x != 0).Aggregate(1, (a, b) => a * b) : 0)];

        int product = nums.Aggregate(1, (a, b) => a * b);

        return [.. nums.Select(n => product / n)];
    }
}
