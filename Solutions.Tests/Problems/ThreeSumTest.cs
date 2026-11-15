using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ThreeSumTest
{
    public ThreeSumSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        int[] nums = [-1, 0, 1, 2, -1, -4];
        List<IList<int>> expected = [[-1, -1, 2], [-1, 0, 1]];

        IList<IList<int>> result = Solution.ThreeSum(nums);

        Assert.Equal(expected.Count, result.Count);
        Assert.All(expected, triplet => Assert.Contains(triplet, result));
    }

    [Fact]
    public void Case2()
    {
        int[] nums = [0, 1, 1];
        List<IList<int>> expected = [];

        IList<IList<int>> result = Solution.ThreeSum(nums);

        Assert.Equal(expected.Count, result.Count);
    }

    [Fact]
    public void Case3()
    {
        int[] nums = [0, 0, 0];
        List<IList<int>> expected = [[0, 0, 0]];

        IList<IList<int>> result = Solution.ThreeSum(nums);

        Assert.Equal(expected.Count, result.Count);
        Assert.All(expected, triplet => Assert.Contains(triplet, result));
    }
}
