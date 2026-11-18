using Solutions.Models;

namespace Solutions.Problems;

public class LinkedListCycleSolution
{
    public bool HasCycleHashSet(ListNode<int> head)
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

    public bool HasCycle(ListNode<int> head)
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
