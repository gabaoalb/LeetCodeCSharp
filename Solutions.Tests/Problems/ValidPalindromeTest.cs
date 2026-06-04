using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ValidPalindromeTest
{
    public ValidPalindromeSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        string s = "A man, a plan, a canal: Panama";

        // Act
        bool result = Solution.IsPalindrome(s);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        string s = "race a car";

        // Act
        bool result = Solution.IsPalindrome(s);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        string s = " ";

        // Act
        bool result = Solution.IsPalindrome(s);

        // Assert
        Assert.True(result);
    }
}
