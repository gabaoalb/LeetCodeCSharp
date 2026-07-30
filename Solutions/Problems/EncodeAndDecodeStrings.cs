namespace Solutions.Problems;

public class EncodeAndDecodeStringsSolution
{
    public string Encode(IList<string> strs) =>
        string.Join("", strs.Select(s => $"{s.Length}/{s}"));

    public IList<string> Decode(string s)
    {
        var result = new List<string>();
        int i = 0;
        while (i < s.Length)
        {
            int slashIndex = s.IndexOf('/', i);
            if (slashIndex == -1)
                break;

            int length = int.Parse(s[i..slashIndex]);
            i = slashIndex + 1;

            string str = s.Substring(i, length);
            result.Add(str);
            i += length;
        }

        return result;
    }
}
