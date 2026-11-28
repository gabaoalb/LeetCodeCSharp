using Solutions.Models;

namespace Solutions.Problems;

public class DiameterOfBinaryTreeSolution
{
    /// <summary>
    /// Finds the diameter in edges by recomputing both subtree heights at each node and
    /// comparing the path through that node with the diameters of its subtrees.
    /// <para>
    /// Worst-case time is O(n²) for a skewed tree because subtree heights are recomputed.
    /// Auxiliary space is O(h) for recursion, where n is the node count and h is the tree height.
    /// </para>
    /// </summary>
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
        int sub = Math.Max(
            DiameterOfBinaryTreeBruteForce(root.left),
            DiameterOfBinaryTreeBruteForce(root.right)
        );

        return Math.Max(diameter, sub);
    }

    #region ClassMemberDFS
    public int result = 0;

    /// <summary>
    /// Finds the diameter in edges in one postorder traversal. Returns each subtree's height
    /// to its parent and uses an instance field to track the largest sum of child heights.
    /// The field is reset on each call, so concurrent calls on the same instance share mutable state.
    /// <para>
    /// Time is O(n). Auxiliary space is O(h) for recursion, where n is the node count
    /// and h is the tree height.
    /// </para>
    /// </summary>
    public int DiameterOfBinaryTreeClassMemberDFS(TreeNode? root)
    {
        result = 0; // reset result for each call to the method
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

    /// <summary>
    /// Finds the diameter in edges in one postorder traversal. Returns each subtree's height
    /// to its parent and tracks the largest sum of child heights in a local variable passed by reference.
    /// <para>
    /// Time is O(n). Auxiliary space is O(h) for recursion, where n is the node count
    /// and h is the tree height.
    /// </para>
    /// </summary>
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

    /// <summary>
    /// Finds the diameter in edges with an explicit stack for postorder traversal.
    /// Stores each subtree's height and diameter in a dictionary after processing its children.
    /// <para>
    /// Expected time is O(n). Auxiliary space is O(n) for the dictionary and stack,
    /// where n is the node count.
    /// </para>
    /// </summary>
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

            int diameter = Math.Max(
                leftHeight + rightHeight,
                Math.Max(leftDiameter, rightDiameter)
            );
            int height = 1 + Math.Max(leftHeight, rightHeight);

            hashMap[node] = (height, diameter);
        }

        return hashMap[root].diameter;
    }
}
