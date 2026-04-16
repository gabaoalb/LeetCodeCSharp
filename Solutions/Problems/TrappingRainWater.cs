namespace Solutions.Problems;

public class TrappingRainWaterSolution
{
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
