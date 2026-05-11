namespace Solutions.Problems;

public class TrappingRainWaterSolution
{
    /// <summary>
    /// Brute Force Solution
    /// </summary>
    /// <param name="height">The array representing the elevation map.</param>
    /// <returns>The total amount of trapped rainwater.</returns>
    public int TrapBruteForce(int[] height)
    {
        int trappedWater = 0;
        for (int i = 1; i < height.Length - 1; i++)
        {
            int leftMax = height[..i].Max();
            int rightMax = height[(i + 1)..].Max();
            trappedWater += Math.Max(0, Math.Min(leftMax, rightMax) - height[i]);
        }
        return trappedWater;
    }

    /// <summary>
    /// Dynamic Programming Solution
    /// </summary>
    /// <param name="height">The array representing the elevation map.</param>
    /// <returns>The total amount of trapped rainwater.</returns>
    public int TrapDynamicProgramming(int[] height)
    {
        int n = height.Length;
        if (n == 0) return 0;

        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = height[0];
        for (int i = 1; i < n; i++)
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);

        rightMax[^1] = height[^1];
        for (int i = n - 2; i >= 0; i--)
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);

        int trappedWater = 0;
        for (int i = 0; i < n; i++)
            trappedWater += Math.Min(leftMax[i], rightMax[i]) - height[i];

        return trappedWater;
    }

    /// <summary>
    /// Stack Solution
    /// </summary>
    /// <param name="height">The array representing the elevation map.</param>
    /// <returns>The total amount of trapped rainwater.</returns>
    public int TrapStack(int[] height)
    {
        int trappedWater = 0;
        Stack<int> stack = new();

        for (int i = 0; i < height.Length; i++)
        {
            while (stack.Count > 0 && height[i] > height[stack.Peek()])
            {
                int top = stack.Pop();
                if (stack.Count == 0) break;

                int distance = i - stack.Peek() - 1;
                int boundedHeight = Math.Min(height[i], height[stack.Peek()]) - height[top];
                trappedWater += distance * boundedHeight;
            }
            stack.Push(i);
        }

        return trappedWater;
    }

    /// <summary>
    /// Two Pointers Solution
    /// </summary>
    /// <param name="height">The array representing the elevation map.</param>
    /// <returns>The total amount of trapped rainwater.</returns>
    public int Trap(int[] height)
    {
        (int left, int right) = (0, height.Length - 1);
        (int leftMax, int rightMax) = (height[left], height[right]);
        int trappedWater = 0;

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                trappedWater += leftMax - height[left];
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                trappedWater += rightMax - height[right];
            }
        }

        return trappedWater;
    }
}
