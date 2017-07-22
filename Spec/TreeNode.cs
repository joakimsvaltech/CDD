using CDD.Perpetual.Tokens;

namespace CDD.Perpetual
{
    public class TreeNode
    {
        public TreeNode(Token content, TreeNode left = null, TreeNode right = null)
        {
            Left = left;
            Right = right;
            Content = content;
        }

        public TreeNode Left { get; private set; }
        public TreeNode Right { get; set; }
        public Token Content { get; }
    }
}