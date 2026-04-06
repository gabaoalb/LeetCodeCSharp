namespace Solutions.Problems;

public class GroupAnagramsSolution
{
    public List<List<string>> GroupAnagrams(string[] strs)
    {
        var hashMap = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            var letters = string.Concat(str.OrderBy(s => s));

            if (hashMap.TryGetValue(letters, out var strings))
                strings.Add(str);
            else
                hashMap[letters] = [str];
        }

        return [.. hashMap.Values];
    }

    public IList<IList<string>> GroupAnagramsSortLinq(string[] strs)
    {
        var groups = strs.GroupBy(s => new string([.. s.OrderBy(c => c)]))
                         .ToDictionary(g => g.Key, g => g.ToList());

        return [.. groups.Values];
    }

    public List<List<string>> GroupAnagramsHashMap(string[] strs)
    {
        var hashMap = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            var count = new int[26];
            foreach (var c in str)
                count[c - 'a']++;

            var key = string.Join(string.Empty, count);
            if (hashMap.TryGetValue(key, out var strings))
                strings.Add(str);
            else
                hashMap[key] = [str];
        }

        return [.. hashMap.Values];
    }

}
