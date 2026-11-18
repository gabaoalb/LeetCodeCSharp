using Solutions.Models;

namespace Solutions.Problems;

public class AddTwoNumbersSolution
{
    public ListNode<int>? AddTwoNumbers(ListNode<int>? l1, ListNode<int>? l2)
    {
        ListNode<int>? Add(ListNode<int>? l1, ListNode<int>? l2, int carry = 0)
        {
            if (l1 == null && l2 == null && carry == 0)
                return null;

            (int v1, int v2) = (l1?.Value ?? 0, l2?.Value ?? 0);

            int sum = v1 + v2 + carry;
            carry = sum / 10;
            int value = sum % 10;

            var nextNode = Add(l1?.Next, l2?.Next, carry);

            return new ListNode<int>(value) { Next = nextNode };
        }

        return Add(l1, l2);
    }

    public ListNode<int>? AddTwoNumbersIterative(ListNode<int>? l1, ListNode<int>? l2)
    {
        ListNode<int> dummyHead = new();
        ListNode<int> current = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            (int v1, int v2) = (l1?.Value ?? 0, l2?.Value ?? 0);

            int sum = v1 + v2 + carry;
            carry = sum / 10;
            int value = sum % 10;

            current.Next = new ListNode<int>(value);
            current = current.Next;

            if (l1 != null)
                l1 = l1.Next;
            if (l2 != null)
                l2 = l2.Next;
        }

        return dummyHead.Next;
    }
}
