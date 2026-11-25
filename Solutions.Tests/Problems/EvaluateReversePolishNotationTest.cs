using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class EvaluateReversePolishNotationTest
{
    public EvaluateReversePolishNotationSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        string[] tokens = ["2", "1", "+", "3", "*"];

        // Act
        int result = Solution.EvalRPN(tokens);

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        string[] tokens = ["4", "13", "5", "/", "+"];

        // Act
        int result = Solution.EvalRPN(tokens);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        string[] tokens = ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"];

        // Act
        int result = Solution.EvalRPN(tokens);

        // Assert
        Assert.Equal(22, result);
    }
}
