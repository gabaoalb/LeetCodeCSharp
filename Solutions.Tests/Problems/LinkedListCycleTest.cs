using Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class LinkedListCycleTest
{
    private LinkedListCycleSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        var head = new ListNode(3);
        var node2 = new ListNode(2);
        var node0 = new ListNode(0);
        var nodeNeg4 = new ListNode(-4);
        head.next = node2;
        node2.next = node0;
        node0.next = nodeNeg4;
        nodeNeg4.next = node2; // Creates the cycle

        bool result = Solution.HasCycle(head);

        Assert.True(result);
    }

    [Fact]
    public void Case2()
    {
        var head = new ListNode(1);
        var node2 = new ListNode(2);
        head.next = node2;
        node2.next = head; // Creates the cycle

        bool result = Solution.HasCycle(head);

        Assert.True(result);
    }

    [Fact]
    public void Case3()
    {
        var head = new ListNode(1);

        bool result = Solution.HasCycle(head);

        Assert.False(result);
    }
}
