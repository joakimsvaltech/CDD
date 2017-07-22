using CDD.Core.Tokens;

namespace CDD.Core
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
        public TreeNode Right { get; private set; }
        public Token Content { get; }

        public void AddDescendant(Token token)
        {
            if (Right == null || token.Precedence > Right.Content.Precedence)
                Right = new TreeNode(token, Right);
            else
                Right.AddDescendant(token);
        }
    }
}