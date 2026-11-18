using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class DailyTemperaturesTest
{
    public DailyTemperaturesSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] temperatures = [73, 74, 75, 71, 69, 72, 76, 73];
        int[] expected = [1, 1, 4, 2, 1, 1, 0, 0];

        // Act
        var result = Solution.DailyTemperatures(temperatures);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] temperatures = [30, 40, 50, 60];
        int[] expected = [1, 1, 1, 0];

        // Act
        var result = Solution.DailyTemperatures(temperatures);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] temperatures = [30, 60, 90];
        int[] expected = [1, 1, 0];

        // Act
        var result = Solution.DailyTemperatures(temperatures);

        // Assert
        Assert.Equal(expected, result);
    }
}
