using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ProductOfArrayExceptSelfTest
{
    private ProductOfArrayExceptSelfSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        int[] nums = [1, 2, 3, 4];
        int[] expected = [24, 12, 8, 6];

        int[] actual = Solution.ProductExceptSelf(nums);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case2()
    {
        int[] nums = [-1, 1, 0, -3, 3];
        int[] expected = [0, 0, 9, 0, 0];

        int[] actual = Solution.ProductExceptSelf(nums);

        Assert.Equal(expected, actual);
    }
}
