using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ValidParenthesesTest
{
    public ValidParenthesesSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        string s = "()";

        // Act
        bool result = Solution.IsValid(s);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        string s = "()[]{}";

        // Act
        bool result = Solution.IsValid(s);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        string s = "(]";

        // Act
        bool result = Solution.IsValid(s);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Case4()
    {
        // Arrange
        string s = "([])";

        // Act
        bool result = Solution.IsValid(s);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Case5()
    {
        // Arrange
        string s = "([)]";

        // Act
        bool result = Solution.IsValid(s);

        // Assert
        Assert.False(result);
    }
}
