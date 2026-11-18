using Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class LinkedListCycleTest
{
    private LinkedListCycleSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        var head = new ListNode<int>(3);
        var node2 = new ListNode<int>(2);
        var node0 = new ListNode<int>(0);
        var nodeNeg4 = new ListNode<int>(-4);
        head.Next = node2;
        node2.Next = node0;
        node0.Next = nodeNeg4;
        nodeNeg4.Next = node2; // Creates the cycle

        bool result = Solution.HasCycle(head);

        Assert.True(result);
    }

    [Fact]
    public void Case2()
    {
        var head = new ListNode<int>(1);
        var node2 = new ListNode<int>(2);
        head.Next = node2;
        node2.Next = head; // Creates the cycle

        bool result = Solution.HasCycle(head);

        Assert.True(result);
    }

    [Fact]
    public void Case3()
    {
        var head = new ListNode<int>(1);

        bool result = Solution.HasCycle(head);

        Assert.False(result);
    }
}
