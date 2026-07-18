using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class LongestSubstringWithoutRepeatingCharactersTest
{
    private readonly LongestSubstringWithoutRepeatingCharacters Solution = new();

    [Fact]
    public void Case1()
    {
        string s = "abcabcbb";
        int expected = 3;
        int actual = Solution.LengthOfLongestSubstringBruteForce(s);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case2()
    {
        string s = "bbbbb";
        int expected = 1;
        int actual = Solution.LengthOfLongestSubstringBruteForce(s);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case3()
    {
        string s = "pwwkew";
        int expected = 3;
        int actual = Solution.LengthOfLongestSubstringBruteForce(s);
        Assert.Equal(expected, actual);
    }
}
