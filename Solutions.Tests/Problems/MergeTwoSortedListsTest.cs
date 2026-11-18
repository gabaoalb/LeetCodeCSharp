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
        var l1 = ListNode<int>.FromArray([1, 2, 4]);
        var l2 = ListNode<int>.FromArray([1, 3, 4]);

        if (l1 == null || l2 == null)
            throw new InvalidOperationException("Input lists cannot be null.");

        // Act
        var expected = ListNode<int>.FromArray([1, 1, 2, 3, 4, 4]);
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        ListNode<int>? l1 = null;
        ListNode<int>? l2 = null;

        // Act
        ListNode<int>? expected = null;
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        ListNode<int>? l1 = null;
        ListNode<int>? l2 = ListNode<int>.FromArray([0]);

        // Act
        var expected = ListNode<int>.FromArray([0]);
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }

    [Fact]
    public void Case4()
    {
        // Arrange
        ListNode<int>? l1 = ListNode<int>.FromArray([1]);
        ListNode<int>? l2 = ListNode<int>.FromArray([]);

        // Act
        var expected = ListNode<int>.FromArray([1]);
        var actual = Solution.MergeTwoListsRecursive(l1, l2);

        // Assert
        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }
}
