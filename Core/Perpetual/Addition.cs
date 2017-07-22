namespace CDD.Core.Spec
{
    public class Addition : Expression
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public Addition(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override Expression Resolve()
        {
            if (_left is Constant<int> lefti && _right is Constant<int> righti)
                return new Constant<int>(lefti.Value + righti.Value);
            if (_left is Constant<decimal> leftd && _right is Constant<decimal> rightd)
                return new Constant<decimal>(leftd.Value + rightd.Value);
            if (_left is Constant<string> lefts && _right is Constant<string> rights)
                return new Constant<string>(lefts.Value + rights.Value);
            return this;
        }
    }
}