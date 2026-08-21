using Solutions.Models;

namespace Solutions.Problems;

public class MergeTwoSortedListsSolution
{
    public ListNode? MergeTwoListsRecursive(ListNode? list1, ListNode? list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        if (list1.val <= list2.val)
            return new() { val = list1.val, next = MergeTwoListsRecursive(list1.next, list2) };
        else
            return new() { val = list2.val, next = MergeTwoListsRecursive(list1, list2.next) };
    }

    public ListNode? MergeTwoListsUnoptimized(ListNode? list1, ListNode? list2)
    {
        if (list1 == null && list2 == null)
            return null;

        ListNode? result = new();
        var current = result;

        while (list1 != null || list2 != null)
        {
            if (list2 == null || (list1 != null && list1.val <= list2.val))
            {
                current.val = list1!.val;
                list1 = list1.next;
            }
            else
            {
                current.val = list2.val;
                list2 = list2.next;
            }

            if (list1 != null || list2 != null)
            {
                current.next = new();
                current = current.next;
            }
        }

        return result;
    }

    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var dummy = new ListNode();
        var tail = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }
            tail = tail.next!;
        }

        tail.next = list1 ?? list2;

        return dummy.next;
    }
}
