using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class TrappingRainWaterTest
{
    public TrappingRainWaterSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
        int expected = 6;

        // Act
        int result = Solution.TrapDynamicProgramming(height);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] height = [4, 2, 0, 3, 2, 5];
        int expected = 9;

        // Act
        int result = Solution.TrapDynamicProgramming(height);

        // Assert
        Assert.Equal(expected, result);
    }
}
