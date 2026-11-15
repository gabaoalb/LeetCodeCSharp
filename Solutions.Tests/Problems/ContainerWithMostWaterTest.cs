using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ContainerWithMostWaterTest
{
    public ContainerWithMostWaterSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        int expected = 49;

        int result = Solution.MaxArea(height);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Case2()
    {
        int[] height = [1, 1];
        int expected = 1;

        int result = Solution.MaxArea(height);

        Assert.Equal(expected, result);
    }
}
