using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ValidAnagramTest
{
    public ValidAnagramSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        string s = "anagram";
        string t = "nagaram";

        // Act
        bool result = Solution.IsAnagramHashMap(s, t);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        string s = "rat";
        string t = "car";

        // Act
        bool result = Solution.IsAnagramHashMap(s, t);

        // Assert
        Assert.False(result);
    }
}
