using Solutions.Models;

namespace Solutions.Problems;

public class AddTwoNumbersSolution
{
    public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        ListNode? Add(ListNode? l1, ListNode? l2, int carry = 0)
        {
            if (l1 == null && l2 == null && carry == 0)
                return null;

            (int v1, int v2) = (l1?.val ?? 0, l2?.val ?? 0);

            int sum = v1 + v2 + carry;
            carry = sum / 10;
            int value = sum % 10;

            var nextNode = Add(l1?.next, l2?.next, carry);

            return new ListNode(value) { next = nextNode };
        }

        return Add(l1, l2);
    }

    public ListNode? AddTwoNumbersIterative(ListNode? l1, ListNode? l2)
    {
        ListNode dummyHead = new();
        ListNode current = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            (int v1, int v2) = (l1?.val ?? 0, l2?.val ?? 0);

            int sum = v1 + v2 + carry;
            carry = sum / 10;
            int value = sum % 10;

            current.next = new ListNode(value);
            current = current.next;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        return dummyHead.next;
    }
}
