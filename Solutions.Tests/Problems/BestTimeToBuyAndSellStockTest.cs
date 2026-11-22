using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class BestTimeToBuyAndSellStockTest
{
    public BestTimeToBuyAndSellStockSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        int[] prices = [7, 1, 5, 3, 6, 4];
        int expected = 5;
        int actual = Solution.MaxProfitTwoPointers(prices);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case2()
    {
        int[] prices = [7, 6, 4, 3, 1];
        int expected = 0;
        int actual = Solution.MaxProfitTwoPointers(prices);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case186()
    {
        int[] prices = [2, 1, 2, 1, 0, 1, 2];
        int expected = 2;
        int actual = Solution.MaxProfitTwoPointers(prices);
        Assert.Equal(expected, actual);
    }
}
