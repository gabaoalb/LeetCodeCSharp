using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class LongestConsecutiveSequenceTest
{
    public LongestConsecutiveSequenceSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        int[] nums = [100, 4, 200, 1, 3, 2];

        int actual = Solution.LongestConsecutiveHashMap(nums);
        int expected = 4;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case2()
    {
        int[] nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1];

        int actual = Solution.LongestConsecutiveHashMap(nums);
        int expected = 9;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case3()
    {
        int[] nums = [1, 0, 1, 2];

        int actual = Solution.LongestConsecutiveHashMap(nums);
        int expected = 3;

        Assert.Equal(expected, actual);
    }
}
