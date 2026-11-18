using Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class AddTwoNumbersTest
{
    public AddTwoNumbersSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        var l1 = ListNode<int>.FromArray([2, 4, 3]);
        var l2 = ListNode<int>.FromArray([5, 6, 4]);

        var expected = ListNode<int>.FromArray([7, 0, 8]);
        var actual = Solution.AddTwoNumbersIterative(l1, l2);

        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }

    [Fact]
    public void Case2()
    {
        var l1 = ListNode<int>.FromArray([0]);
        var l2 = ListNode<int>.FromArray([0]);

        var expected = ListNode<int>.FromArray([0]);
        var actual = Solution.AddTwoNumbersIterative(l1, l2);

        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }

    [Fact]
    public void Case3()
    {
        var l1 = ListNode<int>.FromArray([9, 9, 9, 9, 9, 9, 9]);
        var l2 = ListNode<int>.FromArray([9, 9, 9, 9]);

        var expected = ListNode<int>.FromArray([8, 9, 9, 9, 0, 0, 0, 1]);
        var actual = Solution.AddTwoNumbersIterative(l1, l2);

        Assert.Equal(expected, actual, new ListNodeComparer<int>());
    }
}
