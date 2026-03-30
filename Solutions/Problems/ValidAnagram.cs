namespace Solutions.Problems;

public class ValidAnagramSolution
{
    public bool IsAnagramSorting(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        string sortedS = string.Concat(s.OrderBy(s => s));
        string sortedT = string.Concat(t.OrderBy(t => t));

        return sortedS == sortedT;
    }

    public bool IsAnagramHashMap(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var hashMap = new Dictionary<char, int>();

        for (int index = 0; index < s.Length; index++)
        {
            hashMap[s[index]] = hashMap.GetValueOrDefault(s[index], 0) + 1;
            hashMap[t[index]] = hashMap.GetValueOrDefault(t[index], 0) - 1;
        }

        return !hashMap.Values.Any(v => v != 0);
    }
}
