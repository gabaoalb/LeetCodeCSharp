using Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class MergeTwoSortedListsTest
{
    public MergeTwoSortedListsSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        var l1 = ListNode.FromArray([1, 2, 4]);
        var l2 = ListNode.FromArray([1, 3, 4]);

        if (l1 == null || l2 == null)
            throw new InvalidOperationException("Input lists cannot be null.");

        // Act
        var expected = ListNode.FromArray([1, 1, 2, 3, 4, 4]);
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer());
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        ListNode? l1 = null;
        ListNode? l2 = null;

        // Act
        ListNode? expected = null;
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer());
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        ListNode? l1 = null;
        ListNode? l2 = ListNode.FromArray([0]);

        // Act
        var expected = ListNode.FromArray([0]);
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer());
    }

    [Fact]
    public void Case4()
    {
        // Arrange
        ListNode? l1 = ListNode.FromArray([1]);
        ListNode? l2 = ListNode.FromArray([]);

        // Act
        var expected = ListNode.FromArray([1]);
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}
