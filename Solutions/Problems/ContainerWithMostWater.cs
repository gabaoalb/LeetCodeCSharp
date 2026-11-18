namespace Solutions.Problems;

public class ContainerWithMostWaterSolution
{
    /// <summary>
    /// Brute force approach to find the maximum area between two lines.
    /// Time complexity: O(n^2) where n is the number of elements in the height array.
    /// Space complexity: O(1).
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int MaxAreaBruteForce(int[] height)
    {
        int maxArea = 0;

        for (int i = 0; i < height.Length; i++)
        for (int j = i + 1; j < height.Length; j++)
            maxArea = Math.Max(maxArea, (j - i) * Math.Min(height[i], height[j]));

        return maxArea;
    }

    /// <summary>
    /// Two-pointer approach to find the maximum area between two lines.
    /// Time complexity: O(n) where n is the number of elements in the height array.
    /// Space complexity: O(1).
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int MaxArea(int[] height)
    {
        int maxArea = 0;
        (int left, int right) = (0, height.Length - 1);

        while (left < right)
        {
            maxArea = Math.Max(maxArea, (right - left) * Math.Min(height[left], height[right]));
            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}
