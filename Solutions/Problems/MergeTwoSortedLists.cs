using Solutions.Models;

namespace Solutions.Problems;

public class MergeTwoSortedListsSolution
{
    public ListNode<int>? MergeTwoListsRecursive(ListNode<int>? list1, ListNode<int>? list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        if (list1.Value <= list2.Value)
        {
            list1.Next = MergeTwoListsRecursive(list1.Next, list2);
            return list1;
        }

        list2.Next = MergeTwoListsRecursive(list1, list2.Next);
        return list2;
    }

    public ListNode<int>? MergeTwoListsUnoptimized(ListNode<int>? list1, ListNode<int>? list2)
    {
        if (list1 == null && list2 == null)
            return null;

        ListNode<int>? result = new();
        var current = result;

        while (list1 != null || list2 != null)
        {
            if (list2 == null || (list1 != null && list1.Value <= list2.Value))
            {
                current.Value = list1!.Value;
                list1 = list1.Next;
            }
            else
            {
                current.Value = list2.Value;
                list2 = list2.Next;
            }

            if (list1 != null || list2 != null)
            {
                current.Next = new();
                current = current.Next;
            }
        }

        return result;
    }

    public ListNode<int>? MergeTwoLists(ListNode<int>? list1, ListNode<int>? list2)
    {
        var dummy = new ListNode<int>();
        var tail = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.Value < list2.Value)
            {
                tail.Next = list1;
                list1 = list1.Next;
            }
            else
            {
                tail.Next = list2;
                list2 = list2.Next;
            }
            tail = tail.Next!;
        }

        tail.Next = list1 ?? list2;

        return dummy.Next;
    }
}
