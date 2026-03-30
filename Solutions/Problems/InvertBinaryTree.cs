using LeetCode.Solutions.Models;

namespace Solutions.Problems;

public class InvertBinaryTreeSolution
{
    /// <summary>
    /// DFS Recursive Solution
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode? InvertTreeRecursiveDFS(TreeNode? root)
    {
        if (root == null)
            return null;

        (root.left, root.right) = (root.right, root.left);

        InvertTreeRecursiveDFS(root.right);
        InvertTreeRecursiveDFS(root.left);

        return root;
    }

    /// <summary>
    /// Iterative DFS Solution
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root == null)
            return null;

        Stack<TreeNode> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();

            (node.left, node.right) = (node.right, node.left);

            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }

        return root;
    }

    /// <summary>
    /// BFS Algo
    /// Algoritmo de Busca em Largura 
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode? InvertTreeBFS(TreeNode root)
    {
        if (root == null)
            return null;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            (node.left, node.right) = (node.right, node.left);

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }

        return root;
    }
}
