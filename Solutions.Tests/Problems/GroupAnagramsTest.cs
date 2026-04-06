using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class GroupAnagramsTest
{
    public GroupAnagramsSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        var input = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        var expected = new List<List<string>>
        {
            new() { "bat" },
            new() { "nat", "tan" },
            new() { "ate", "eat", "tea" }
        };

        var result = Solution.GroupAnagramsSortLinq(input);

        Assert.Equal(expected.Count, result.Count);
        foreach (var group in expected)
            Assert.Contains(result, r => r.Count == group.Count && r.All(group.Contains));
    }

    [Fact]
    public void Case2()
    {
        var input = new[] { "" };
        var expected = new List<List<string>>
        {
            new() { "" }
        };

        var result = Solution.GroupAnagramsSortLinq(input);

        Assert.Equal(expected.Count, result.Count);
        foreach (var group in expected)
            Assert.Contains(result, r => r.Count == group.Count && r.All(group.Contains));
    }

    [Fact]
    public void Case3()
    {
        var input = new[] { "a" };
        var expected = new List<List<string>>
        {
            new() { "a" }
        };

        var result = Solution.GroupAnagramsSortLinq(input);

        Assert.Equal(expected.Count, result.Count);
        foreach (var group in expected)
            Assert.Contains(result, r => r.Count == group.Count && r.All(group.Contains));
    }
}
