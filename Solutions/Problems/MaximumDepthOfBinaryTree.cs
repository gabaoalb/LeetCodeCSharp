using LeetCode.Solutions.Models;

namespace Solutions.Problems;

public class MaximumDepthOfBinaryTreeSolution
{
    /// <summary>
    /// Recursive DFS Solution
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int MaxDepth(TreeNode? root)
    {
        if (root == null)
            return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}
