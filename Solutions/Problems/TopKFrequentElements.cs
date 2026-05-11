namespace Solutions.Problems;

public class TopKFrequentElementsSolution
{
    /// <summary>
    /// Sorting the elements by their frequency and returning the k most frequent elements.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <param name="k">The number of top frequent elements to return.</param>
    /// <returns>An array of the k most frequent elements.</returns>
    public int[] TopKFrequent(int[] nums, int k) =>
        [.. nums.CountBy(n => n)
                .OrderByDescending(g => g.Value)
                .Take(k)
                .Select(g => g.Key)];

    /// <summary>
    /// Using a min-heap (priority queue) to keep track of the top k frequent elements.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <param name="k">The number of top frequent elements to return.</param>
    /// <returns>An array of the k most frequent elements.</returns>
    public int[] TopKFrequentHeap(int[] nums, int k)
    {
        var freq = nums.CountBy(n => n)
                       .ToDictionary(g => g.Key, g => g.Value);

        var pq = new PriorityQueue<int, int>();
        foreach (var kv in freq)
        {
            pq.Enqueue(kv.Key, kv.Value);
            if (pq.Count > k)
                pq.Dequeue();
        }

        var result = new int[k];
        for (int i = 0; i < k; i++)
            result[i] = pq.Dequeue();

        return result;
    }

    /// <summary>
    /// Using bucket sort to group elements by their frequency and then returning the k most frequent elements.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <param name="k">The number of top frequent elements to return.</param>
    /// <returns>An array of the k most frequent elements.</returns>
    public int[] TopKFrequentBucket(int[] nums, int k)
    {
        var freq = nums.CountBy(n => n)
                       .ToDictionary(g => g.Key, g => g.Value);

        List<int>[] buckets = [.. Enumerable.Range(0, nums.Length + 1)
                                            .Select(_ => new List<int>())];

        foreach (var kv in freq)
            buckets[kv.Value].Add(kv.Key);

        return [.. buckets.Reverse()
                          .SelectMany(b => b)
                          .Take(k)];
    }
}