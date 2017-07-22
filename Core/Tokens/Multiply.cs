using CDD.Core.Tokens;

namespace CDD.Core.Constraints
{
    public class Multiply : Token
    {
        public override int Precedence => 2;
    }
}