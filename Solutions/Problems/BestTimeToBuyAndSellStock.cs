namespace Solutions.Problems;

public class BestTimeToBuyAndSellStockSolution
{
    /// <summary>
    /// Brute force approach to find the maximum profit from stock prices.
    /// </summary>
    /// <param name="prices">Array of stock prices where prices[i] is the price on day i.</param>
    /// <returns>The maximum profit that can be achieved from a single buy and sell transaction.</returns>
    public int MaxProfitBruteForce(int[] prices)
    {
        int maxProfit = 0;
        for (int i = 0; i < prices.Length; i++)
        for (int j = i + 1; j < prices.Length; j++)
            maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);

        return maxProfit;
    }

    /// <summary>
    /// Two pointers approach to find the maximum profit from stock prices.
    /// </summary>
    /// <param name="prices">Array of stock prices where prices[i] is the price on day i.</param>
    /// <returns>The maximum profit that can be achieved from a single buy and sell transaction.</returns>
    public int MaxProfitTwoPointers(int[] prices)
    {
        (int left, int right) = (0, 1);
        int maxProfit = 0;

        while (right < prices.Length)
        {
            if (prices[left] > prices[right])
                left = right;
            else
                maxProfit = Math.Max(maxProfit, prices[right] - prices[left]);

            right++;
        }

        return maxProfit;
    }

    /// <summary>
    /// Dynamic programming approach to find the maximum profit from stock prices.
    /// </summary>
    /// <param name="prices">Array of stock prices where prices[i] is the price on day i.</param>
    /// <returns>The maximum profit that can be achieved from a single buy and sell transaction.</returns>
    public int MaxProfit(int[] prices)
    {
        (int minPrice, int maxProfit) = (prices[0], 0);
        for (int index = 1; index < prices.Length; index++)
        {
            minPrice = Math.Min(prices[index], minPrice);
            maxProfit = Math.Max(prices[index] - minPrice, maxProfit);
        }
        return maxProfit;
    }
}
