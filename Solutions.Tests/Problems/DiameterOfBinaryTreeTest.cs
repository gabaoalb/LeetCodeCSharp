using Solutions.Models;
using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class DiameterOfBinaryTreeTest
{
    public DiameterOfBinaryTreeSolution Solution { get; } = new();

    [Fact]
    public void Case1()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5];
        TreeNode? treeNode = TreeNode.FromArray(nums);

        // Act
        int actual = Solution.DiameterOfBinaryTreeDFS(treeNode);

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
        int actual = Solution.DiameterOfBinaryTreeDFS(treeNode);

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5, 6];
        TreeNode? treeNode = TreeNode.FromArray(nums);

        // Act
        int actual = Solution.DiameterOfBinaryTreeClassMemberDFS(treeNode);
        int actual2 = Solution.DiameterOfBinaryTreeClassMemberDFS(treeNode);

        // Assert
        Assert.Equal(4, actual);
        Assert.Equal(4, actual2);
        Assert.Equal(actual, actual2);
    }

    [Fact]
    public void CaseClassMemberDFS_ShouldResetResultBetweenCalls()
    {
        // Arrange
        TreeNode? largerTree = TreeNode.FromArray([1, 2, 3, 4, 5, 6]);
        TreeNode? smallerTree = TreeNode.FromArray([1, 2]);

        // Act
        int largerTreeDiameter = Solution.DiameterOfBinaryTreeClassMemberDFS(largerTree);
        int smallerTreeDiameter = Solution.DiameterOfBinaryTreeClassMemberDFS(smallerTree);

        // Assert
        Assert.Equal(4, largerTreeDiameter);
        Assert.Equal(1, smallerTreeDiameter);
    }
}
