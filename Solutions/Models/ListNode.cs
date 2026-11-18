namespace Solutions.Models;

/// <summary>
/// Represents a node in a doubly linked list.
/// </summary>
/// <param name="val">The value stored in the node.</param>
/// <param name="next">The reference to the next node in the list.</param>
/// <param name="prev">The reference to the previous node in the list.</param>
public class ListNode<T>(T? val = default, ListNode<T>? next = null, ListNode<T>? prev = null)
{
    public T? Value = val;
    public ListNode<T>? Prev = prev;
    public ListNode<T>? Next = next;

    public static ListNode<T>? FromArray(T[] array)
    {
        if (array == null || array.Length == 0)
            return null;

        ListNode<T> head = new(array[0]);
        ListNode<T> current = head;

        for (int i = 1; i < array.Length; i++)
        {
            current.Next = new ListNode<T>(array[i]) { Prev = current };
            current = current.Next;
        }

        return head;
    }
}

public class ListNodeComparer<T> : IEqualityComparer<ListNode<T>?>
{
    public bool Equals(ListNode<T>? x, ListNode<T>? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return EqualityComparer<T>.Default.Equals(x.Value, y.Value) && Equals(x.Next, y.Next);
    }

    public int GetHashCode(ListNode<T>? obj)
    {
        if (obj == null)
            return 0;

        int hash = 17;
        hash = hash * 31 + EqualityComparer<T>.Default.GetHashCode(obj.Value!);
        hash = hash * 31 + GetHashCode(obj.Next);
        return hash;
    }
}
