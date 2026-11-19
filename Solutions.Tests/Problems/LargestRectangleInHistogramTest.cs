using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class LargestRectangleInHistogramTest
{
    public LargestRectangleInHistogram Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] heights = [2, 1, 5, 6, 2, 3];

        // Act
        int result = Solution.LargestRectangleArea(heights);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] heights = [2, 4];

        // Act
        int result = Solution.LargestRectangleArea(heights);

        // Assert
        Assert.Equal(4, result);
    }
}
