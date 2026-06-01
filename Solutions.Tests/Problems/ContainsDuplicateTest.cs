using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ContainsDuplicateTest
{
    public ContainsDuplicateSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] nums = [1, 2, 3, 1];

        // Act
        bool result = Solution.ContainsDuplicate(nums);
        bool resultSort = Solution.ContainsDuplicateSorting(nums);

        // Assert
        Assert.True(result);
        Assert.True(resultSort);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4];

        // Act
        bool result = Solution.ContainsDuplicate(nums);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] nums = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2];

        // Act
        bool result = Solution.ContainsDuplicate(nums);

        // Assert
        Assert.True(result);
    }
}
