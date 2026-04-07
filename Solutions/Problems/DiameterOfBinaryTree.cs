using LeetCode.Solutions.Models;

namespace Solutions.Problems;

public class DiameterOfBinaryTreeSolution
{
    public int DiameterOfBinaryTreeBruteForce(TreeNode? root)
    {
        static int Depth(TreeNode? node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Depth(node.left), Depth(node.right));
        }

        if (root == null)
            return 0;

        int leftHeight = Depth(root.left);
        int rightHeight = Depth(root.right);

        int diameter = leftHeight + rightHeight;
        int sub = Math.Max(DiameterOfBinaryTreeBruteForce(root.left), DiameterOfBinaryTreeBruteForce(root.right));

        return Math.Max(diameter, sub);
    }

    #region ClassMemberDFS
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
    #endregion

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

    public int DiameterOfBinaryTreeIterativeDFS(TreeNode? root)
    {
        if (root == null)
            return 0;

        var hashMap = new Dictionary<TreeNode, (int height, int diameter)>();
        Stack<TreeNode> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Peek();

            if (node.left != null && !hashMap.ContainsKey(node.left))
            {
                stack.Push(node.left);
                continue;
            }

            if (node.right != null && !hashMap.ContainsKey(node.right))
            {
                stack.Push(node.right);
                continue;
            }

            node = stack.Pop();

            (int leftHeight, int leftDiameter) = (0, 0);
            if (node.left != null && hashMap.TryGetValue(node.left, out var valueLeft))
                (leftHeight, leftDiameter) = valueLeft;

            (int rightHeight, int rightDiameter) = (0, 0);
            if (node.right != null && hashMap.TryGetValue(node.right, out var valueRight))
                (rightHeight, rightDiameter) = valueRight;

            int diameter = Math.Max(leftHeight + rightHeight, Math.Max(leftDiameter, rightDiameter));
            int height = 1 + Math.Max(leftHeight, rightHeight);

            hashMap[node] = (height, diameter);
        }

        return hashMap[root].diameter;
    }
}