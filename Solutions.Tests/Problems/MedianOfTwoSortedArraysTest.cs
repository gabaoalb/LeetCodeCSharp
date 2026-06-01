

using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class MedianOfTwoSortedArraysTest
{
    public MedianOfTwoSortedArraysSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2];

        // Act
        double result = Solution.FindMedianSortedArraysBruteForce(nums1, nums2);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4];

        // Act
        double result = Solution.FindMedianSortedArrays(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void Case2061()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2, 7];

        // Act
        double result = Solution.FindMedianSortedArrays(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void Case2071()
    {
        // Arrange
        int[] nums1 = [1, 2];
        int[] nums2 = [1, 1];

        // Act
        double result = Solution.FindMedianSortedArrays(nums1, nums2);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Case2072()
    {
        // Arrange
        int[] nums1 = [1, 1];
        int[] nums2 = [1, 2];

        // Act
        double result = Solution.FindMedianSortedArrays(nums1, nums2);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Case2073()
    {
        // Arrange
        int[] nums1 = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4];
        int[] nums2 = [1, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4];

        // Act
        double result = Solution.FindMedianSortedArrays(nums1, nums2);

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void CaseSpecial()
    {
        // Arrange
        int[] nums1 = [1, 1, 2, 3, 5, 8, 13, 21];
        int[] nums2 = [2, 3, 5, 7, 11, 13, 17, 19];

        // Act
        double resultBruteForce = Solution.FindMedianSortedArraysBruteForce(nums1, nums2);
        double result = Solution.FindMedianSortedArrays(nums1, nums2);

        // Assert
        Assert.Equal(6.0, resultBruteForce);
        Assert.Equal(6.0, result);
    }
}