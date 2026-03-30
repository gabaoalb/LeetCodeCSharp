namespace LeetCode.Solutions.Models;

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;

    /// <summary>
    /// Create the binary tree recursively based on an array
    /// </summary>
    /// <param name="array"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public static TreeNode? FromArray(int[] array, int level = 0)
    {
        TreeNode root = new();

        if (level < array.Length)
        {
            root.val = array[level];
            root.left = FromArray(array, 2 * level + 1);
            root.right = FromArray(array, 2 * level + 2);
        }

        if (root.val != 0)
            return root;
        else
            return null;
    }

    /// <summary>
    /// Use iterative bfs logic
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static TreeNode? FromArrayIterative(int[] array)
    {
        if (array == null || array.Length == 0)
            return null;

        // 1. Cria a raiz da árvore
        TreeNode root = new(array[0]);

        // 2. Fila para processar os nós por nível (Level-Order)
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        int i = 1;
        while (i < array.Length)
        {
            // Remove o próximo nó pai da fila para atribuir seus filhos
            TreeNode current = queue.Dequeue();

            // Processa o filho à ESQUERDA
            if (i < array.Length)
            {
                current.left = new TreeNode(array[i]);
                queue.Enqueue(current.left);
                i++;
            }

            // Processa o filho à DIREITA
            if (i < array.Length)
            {
                current.right = new TreeNode(array[i]);
                queue.Enqueue(current.right);
                i++;
            }
        }

        return root;
    }

    public static int[] ToArray(TreeNode? root)
    {
        if (root == null) return [];

        List<int> result = [];
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            result.Add(node.val);

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }

        return [.. result];
    }
}