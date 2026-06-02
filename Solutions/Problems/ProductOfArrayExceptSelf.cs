namespace Solutions.Problems;

public class ProductOfArrayExceptSelfSolution
{
    /// <summary>
    /// Brute force approach: O(n^2) time, O(n) space
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>An array where each element is the product of all other elements except itself.</returns>
    public int[] ProductExceptSelfBruteForce(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            int product = 1;
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                    product *= nums[j];
            }
            result[i] = product;
        }

        return result;
    }

    /// <summary>
    /// Division approach: O(n) time, O(1) space (excluding output array)
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>An array where each element is the product of all other elements except itself.</returns>
    public int[] ProductExceptSelfDivision(int[] nums)
    {
        int zeros = nums.Count(n => n == 0);

        if (zeros > 1)
            return new int[nums.Length];
        if (zeros == 1)
            return [.. nums.Select(n => n == 0 ? nums.Where(x => x != 0).Aggregate(1, (a, b) => a * b) : 0)];

        int product = nums.Aggregate(1, (a, b) => a * b);

        return [.. nums.Select(n => product / n)];
    }

    /// <summary>
    /// Left and right products approach: O(n) time, O(n) space
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>An array where each element is the product of all other elements except itself.</returns>
    public int[] ProductExceptSelfLeftRight(int[] nums)
    {
        int n = nums.Length;
        int[] leftProducts = new int[n];
        int[] rightProducts = new int[n];
        int[] result = new int[n];

        leftProducts[0] = 1;
        for (int i = 1; i < n; i++)
            leftProducts[i] = leftProducts[i - 1] * nums[i - 1];

        rightProducts[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
            rightProducts[i] = rightProducts[i + 1] * nums[i + 1];

        for (int i = 0; i < n; i++)
            result[i] = leftProducts[i] * rightProducts[i];

        return result;
    }

    /// <summary>
    /// Optimal approach: O(n) time, O(1) space (excluding output array)
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>An array where each element is the product of all other elements except itself.</returns>
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        // Calculate left products
        result[0] = 1;
        for (int i = 1; i < n; i++)
            result[i] = result[i - 1] * nums[i - 1];

        // Calculate right products and final result
        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] *= rightProduct;
            rightProduct *= nums[i];
        }

        return result;
    }
}
