using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ValidParenthesesTest
{
    public ValidParenthesesSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        string s = "()";

        bool result = Solution.IsValid(s);

        Assert.True(result);
    }

    [Fact]
    public void Case2()
    {
        string s = "()[]{}";

        bool result = Solution.IsValid(s);

        Assert.True(result);
    }

    [Fact]
    public void Case3()
    {
        string s = "(]";

        bool result = Solution.IsValid(s);

        Assert.False(result);
    }
}
