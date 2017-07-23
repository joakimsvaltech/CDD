namespace CDD.Perpetual.Tokens
{
    public class Literal : Token
    {
        public string Value;

        public Literal(string value)
            => Value = value.Trim();

        public override int Precedence => 1;
    }
}