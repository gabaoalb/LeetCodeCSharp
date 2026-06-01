using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class CarFleetTest
{
    public CarFleetSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] positions = [10, 8, 0, 5, 3];
        int[] speed = [2, 4, 1, 1, 3];
        int target = 12;

        // Act
        int result = Solution.CarFleet(target, positions, speed);
        int resultIterator = Solution.CarFleetIterator(target, positions, speed);

        // Assert
        Assert.Equal(3, result);
        Assert.Equal(3, resultIterator);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] positions = [0, 2, 4];
        int[] speed = [4, 2, 1];
        int target = 100;

        // Act
        int result = Solution.CarFleet(target, positions, speed);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Case4()
    {
        // Arrange
        int[] positions = [6, 8];
        int[] speed = [3, 2];
        int target = 10;

        // Act
        int result = Solution.CarFleet(target, positions, speed);

        // Assert
        Assert.Equal(2, result);
    }
}