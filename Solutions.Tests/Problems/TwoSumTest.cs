using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class TwoSumTest
{
    public TwoSumSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] nums = [2, 7, 11, 15];
        int target = 9;

        // Act
        int[] result = Solution.TwoSumSorting(nums, target);

        // Assert
        Assert.Equal([0, 1], result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] nums = [3, 2, 4];
        int target = 6;

        // Act
        int[] result = Solution.TwoSumSorting(nums, target);

        // Assert
        Assert.Equal([1, 2], result);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] nums = [3, 3];
        int target = 6;

        // Act
        int[] result = Solution.TwoSumSorting(nums, target);

        // Assert
        Assert.Equal([0, 1], result);
    }
}
