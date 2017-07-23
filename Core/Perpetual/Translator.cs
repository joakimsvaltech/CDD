namespace CDD.Core.Perpetual
{
    public interface Translator
    {
        Constraint Translate(string representation);
    }
}