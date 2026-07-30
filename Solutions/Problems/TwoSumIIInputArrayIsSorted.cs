namespace Solutions.Problems;

public class TwoSumIIInputArrayIsSortedSolution
{
    public int[] TwoSumBruteForce(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
            for (int j = i + 1; j < numbers.Length; j++)
                if (numbers[i] + numbers[j] == target)
                    return [i + 1, j + 1];
                else if (numbers[i] + numbers[j] > target)
                    break;

        return [];
    }

    public int[] TwoSumBinarySearch(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            (int left, int right) = (i + 1, numbers.Length - 1);

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                switch (numbers[mid].CompareTo(target - numbers[i]))
                {
                    case < 0:
                        left = mid + 1;
                        break;
                    case > 0:
                        right = mid - 1;
                        break;
                    case 0:
                        return [i + 1, mid + 1];
                }
            }
        }

        return [];
    }

    public int[] TwoSumHashMap(int[] numbers, int target)
    {
        Dictionary<int, int> hashMap = [];

        foreach ((int num, int right) in numbers.Select((n, i) => (n, i)))
        {
            if (hashMap.TryGetValue(target - num, out int left))
                return [left + 1, right + 1];

            hashMap[num] = right;
        }

        return [];
    }


    public int[] TwoSumTwoPointers(int[] numbers, int target)
    {
        (int left, int right) = (0, numbers.Length - 1);

        while (left < right)
        {
            switch ((numbers[left] + numbers[right]).CompareTo(target))
            {
                case < 0:
                    left++;
                    break;
                case > 0:
                    right--;
                    break;
                case 0:
                    return [left + 1, right + 1];
            }
        }

        return [];
    }
}
