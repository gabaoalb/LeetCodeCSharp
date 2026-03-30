namespace Solutions.Problems;

public class MedianOfTwoSortedArraysSolution
{
    public double FindMedianSortedArraysBruteForce(int[] nums1, int[] nums2)
    {
        List<double> newNums = [.. nums1.Concat(nums2).Select(Convert.ToDouble)];
        newNums.Sort();

        int count = newNums.Count;
        int mid = count / 2;

        if (count % 2 == 1)
            return newNums[mid];
        else
            return (newNums[mid - 1] + newNums[mid]) / 2;
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        (int p1, int p2, List<double> newNums) = (0, 0, new(nums1.Length + nums2.Length));

        while (newNums.Count < nums1.Length + nums2.Length)
        {
            int? val1 = (p1 >= 0 && p1 < nums1.Length)
                ? nums1[p1]
                : null;
            int? val2 = (p2 >= 0 && p2 < nums2.Length)
                ? nums2[p2]
                : null;

            if ((val1.HasValue && val2.HasValue && val1.Value <= val2.Value) || (val1.HasValue && !val2.HasValue))
                newNums.Add(nums1[p1++]);
            else if ((val1.HasValue && val2.HasValue && val1.Value > val2.Value) || (!val1.HasValue && val2.HasValue))
                newNums.Add(nums2[p2++]);
        }

        int count = newNums.Count;
        int mid = count / 2;

        if (count % 2 == 1)
            return newNums[mid];
        else
            return (newNums[mid - 1] + newNums[mid]) / 2;
    }
}
