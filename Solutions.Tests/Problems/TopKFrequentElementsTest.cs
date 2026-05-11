using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class TopKFrequentElementsTest
{
    public TopKFrequentElementsSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] nums = [1, 1, 1, 2, 2, 3];
        int k = 2;

        // Act
        int[] result = Solution.TopKFrequentBucket(nums, k);

        // Assert
        Assert.Equal([1, 2], result.OrderBy(x => x));
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] nums = [1];
        int k = 1;

        // Act
        int[] result = Solution.TopKFrequentBucket(nums, k);

        // Assert
        Assert.Equal([1], result.OrderBy(x => x));
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] nums = [1, 2, 1, 2, 1, 2, 3, 1, 3, 2];
        int k = 2;

        // Act
        int[] result = Solution.TopKFrequentBucket(nums, k);

        // Assert
        Assert.Equal([1, 2], result.OrderBy(x => x));
    }
}
