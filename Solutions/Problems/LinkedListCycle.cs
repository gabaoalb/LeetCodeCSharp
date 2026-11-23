using Solutions.Models;

namespace Solutions.Problems;

public class LinkedListCycleSolution
{
    /// <summary>
    /// Detects a cycle by storing visited node references in a hash set and returning true
    /// when a node is encountered again. Returns false if traversal reaches the end.
    /// <para>
    /// Expected time and auxiliary space are O(n), where n is the number of distinct reachable nodes.
    /// </para>
    /// </summary>
    public bool HasCycleHashSet(ListNode<int>? head)
    {
        var hashSet = new HashSet<ListNode<int>>();
        var current = head;

        while (current != null)
        {
            if (hashSet.Contains(current))
                return true;

            hashSet.Add(current);
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Detects a cycle using Floyd's algorithm, advancing a slow pointer one node and a fast
    /// pointer two nodes at a time. Returns true if they meet, or false if the fast pointer reaches the end.
    /// <para>
    /// Time is O(n), where n is the number of distinct reachable nodes. Auxiliary space is O(1).
    /// </para>
    /// </summary>
    public bool HasCycle(ListNode<int>? head)
    {
        (var fast, var slow) = (head, head);

        while (fast != null && fast.Next != null)
        {
            (fast, slow) = (fast.Next.Next, slow?.Next);

            if (fast == slow)
                return true;
        }

        return false;
    }
}
