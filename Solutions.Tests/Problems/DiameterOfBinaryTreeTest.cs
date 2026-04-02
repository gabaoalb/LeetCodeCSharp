using LeetCode.Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class DiameterOfBinaryTreeTest
{
    public DiameterOfBinaryTreeSolution Solution { get; set; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5];
        TreeNode? treeNode = TreeNode.FromArray(nums);

        // Act
        int actual = Solution.DiameterOfBinaryTree(treeNode);

        // Assert
        Assert.Equal(3, actual);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] nums = [1, 2];
        TreeNode? treeNode = TreeNode.FromArray(nums);

        // Act
        int actual = Solution.DiameterOfBinaryTree(treeNode);

        // Assert
        Assert.Equal(1, actual);
    }
}
