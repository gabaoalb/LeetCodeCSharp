using LeetCode.Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class MaximumDepthOfBinaryTreeTest
{
    public MaximumDepthOfBinaryTreeSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        List<int?> nums = [3, 9, 20, null, null, 15, 7];
        TreeNode? treeNode = TreeNode.FromList(nums);

        int actual = Solution.MaxDepth(treeNode);
        int expected = 3;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Case2()
    {
        List<int?> nums = [1, null, 2];
        TreeNode? treeNode = TreeNode.FromList(nums);

        int actual = Solution.MaxDepth(treeNode);
        int expected = 2;

        Assert.Equal(expected, actual);
    }
}
