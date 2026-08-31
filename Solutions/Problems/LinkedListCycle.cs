using Solutions.Models;

namespace Solutions.Problems;

public class LinkedListCycleSolution
{
    public bool HasCycleHashSet(ListNode head)
    {
        var hashSet = new HashSet<ListNode>();
        var current = head;

        while (current != null)
        {
            if (hashSet.Contains(current))
                return true;

            hashSet.Add(current);
            current = current.next;
        }

        return false;
    }


    public bool HasCycle(ListNode head)
    {
        (var fast, var slow) = (head, head);

        while (fast != null && fast.next != null)
        {
            (fast, slow) = (fast.next.next, slow.next);

            if (fast.Equals(slow))
                return true;
        }

        return false;
    }
}
