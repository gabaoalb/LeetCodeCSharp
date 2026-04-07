using LeetCode.Solutions.Models;

namespace Solutions.Problems;

public class DiameterOfBinaryTreeSolution
{
    public int result = 0;

    public int DiameterOfBinaryTreeClassMemberDFS(TreeNode? root)
    {
        int Depth(TreeNode? node)
        {
            if (node == null)
                return 0;

            var left = Depth(node.left);
            var right = Depth(node.right);

            result = Math.Max(result, left + right);
            return Math.Max(left, right) + 1;
        }

        Depth(root);
        return result;
    }

    public int DiameterOfBinaryTreeDFS(TreeNode? root)
    {
        static int Depth(TreeNode? node, ref int result)
        {
            if (node == null)
                return 0;

            var left = Depth(node.left, ref result);
            var right = Depth(node.right, ref result);

            result = Math.Max(result, left + right);
            return Math.Max(left, right) + 1;
        }

        int result = 0;
        Depth(root, ref result);
        return result;
    }
}
