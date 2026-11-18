namespace Solutions.Problems;

public class DailyTemperaturesSolution
{
    /// <summary>
    /// Brute force approach to solve the daily temperatures problem.
    /// </summary>
    /// <param name="temperatures">Array of daily temperatures.</param>
    /// <returns>Array indicating the number of days until a warmer temperature.</returns>
    public int[] DailyTemperaturesBruteForce(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        for (int j = i + 1; j < temperatures.Length; j++)
            if (temperatures[j] > temperatures[i])
            {
                result[i] = j - i;
                break;
            }

        return result;
    }

    /// <summary>
    /// Stack-based approach to solve the daily temperatures problem.
    /// </summary>
    /// <param name="temperatures">Array of daily temperatures.</param>
    /// <returns>Array indicating the number of days until a warmer temperature.</returns>
    public int[] DailyTemperaturesStack(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        Stack<int> stack = [];

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int index = stack.Pop();
                result[index] = i - index;
            }
            stack.Push(i);
        }

        return result;
    }

    /// <summary>
    /// Dynamic programming approach to solve the daily temperatures problem.
    /// </summary>
    /// <param name="temperatures">Array of daily temperatures.</param>
    /// <returns>Array indicating the number of days until a warmer temperature.</returns>
    public int[] DailyTemperatures(int[] temperatures)
    {
        int len = temperatures.Length;
        int[] result = new int[temperatures.Length];

        for (int i = len - 2; i >= 0; i--)
        {
            int j = i + 1;
            while (j < len && temperatures[j] <= temperatures[i])
            {
                if (result[j] == 0)
                    break;

                j += result[j];
            }

            if (j < len && temperatures[j] > temperatures[i])
                result[i] = j - i;
        }

        return result;
    }
}
