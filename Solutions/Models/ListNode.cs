namespace Solutions.Models;

public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;

    public static ListNode? FromArray(int[] array)
    {
        if (array == null || array.Length == 0)
            return null;

        ListNode head = new(array[0]);
        ListNode current = head;

        for (int i = 1; i < array.Length; i++)
        {
            current.next = new ListNode(array[i]);
            current = current.next;
        }

        return head;
    }
}

public class ListNodeComparer : IEqualityComparer<ListNode?>
{
    public bool Equals(ListNode? x, ListNode? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.val == y.val && Equals(x.next, y.next);
    }

    public int GetHashCode(ListNode? obj)
    {
        if (obj == null)
            return 0;

        int hash = 17;
        hash = hash * 31 + obj.val.GetHashCode();
        hash = hash * 31 + GetHashCode(obj.next);
        return hash;
    }
}