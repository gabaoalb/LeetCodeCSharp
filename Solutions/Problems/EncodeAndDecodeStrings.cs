namespace Solutions.Problems;

public class EncodeAndDecodeStringsSolution
{
    public string Encode(IList<string> strs) =>
        string.Join('/', strs.Select(s => $"{s.Length}/{s}"));

    public IList<string> Decode(string s) =>
        [.. s.Split('/')
             .Chunk(2)
             .Select(c => c[1])];
}
