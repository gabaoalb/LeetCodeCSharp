using LeetCode.Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class InvertBinaryTreeTest
{
    [Fact]
    public void Case1()
    {
        // Arrange
        int[] tree = [4, 2, 7, 1, 3, 6, 9];
        TreeNode? treeNode = TreeNode.FromArrayIterative(tree);

        // Act
        TreeNode? result = new InvertBinaryTreeSolution().InvertTree(treeNode);
        int[] resultArray = TreeNode.ToArray(result);

        // Assert
        Assert.Equal([4, 7, 2, 9, 6, 3, 1], resultArray);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        int[] tree = [2, 1, 3];
        TreeNode? treeNode = TreeNode.FromArray(tree);

        // Act
        TreeNode? result = new InvertBinaryTreeSolution().InvertTree(treeNode);
        int[] resultArray = TreeNode.ToArray(result);

        // Assert
        Assert.Equal([2, 3, 1], resultArray);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] tree = [];
        TreeNode? treeNode = TreeNode.FromArray(tree);

        // Act
        TreeNode? result = new InvertBinaryTreeSolution().InvertTree(treeNode);
        int[] resultArray = TreeNode.ToArray(result);

        // Assert
        Assert.Equal([], resultArray);
    }
}
