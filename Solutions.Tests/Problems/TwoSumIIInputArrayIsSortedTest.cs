using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class TwoSumIIInputArrayIsSortedTest
{
    public TwoSumIIInputArrayIsSortedSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        int[] numbers = [2, 7, 11, 15];
        int target = 9;
        int[] expected = [1, 2];

        int[] result = Solution.TwoSumTwoPointers(numbers, target);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Case2()
    {
        int[] numbers = [2, 3, 4];
        int target = 6;
        int[] expected = [1, 3];

        int[] result = Solution.TwoSumTwoPointers(numbers, target);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Case3()
    {
        int[] numbers = [-1, 0];
        int target = -1;
        int[] expected = [1, 2];

        int[] result = Solution.TwoSumTwoPointers(numbers, target);

        Assert.Equal(expected, result);
    }
}
