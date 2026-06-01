using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class EncodeAndDecodeStringsTest
{
    public EncodeAndDecodeStringsSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        IList<string> strs = ["Hello", "World"];

        // Act
        string encoded = Solution.Encode(strs);
        IList<string> decoded = Solution.Decode(encoded);

        // Assert
        Assert.Equal(strs, decoded);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        IList<string> strs = ["Foo", "Bar", "Baz"];

        // Act
        string encoded = Solution.Encode(strs);
        IList<string> decoded = Solution.Decode(encoded);

        // Assert
        Assert.Equal(strs, decoded);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        IList<string> strs = ["", " ", "   "];

        // Act
        string encoded = Solution.Encode(strs);
        IList<string> decoded = Solution.Decode(encoded);

        // Assert
        Assert.Equal(strs, decoded);
    }
}
