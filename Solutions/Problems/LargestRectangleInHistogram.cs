namespace Solutions.Problems;

public class LargestRectangleInHistogram
{
    /// <summary>
    /// Finds the largest rectangle area in a histogram represented by the array of heights.
    /// </summary>
    /// <param name="heights">An array of integers representing the heights of the histogram bars.</param>
    /// <returns>The area of the largest rectangle that can be formed in the histogram.</returns>
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = [];
        int maxArea = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Count > 0 && heights[i] < heights[stack.Peek()])
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(width * height, maxArea);
            }
            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            int height = heights[stack.Pop()];
            int width = stack.Count == 0 ? heights.Length : heights.Length - stack.Peek() - 1;
            maxArea = Math.Max(width * height, maxArea);
        }

        return maxArea;
    }
}
