namespace CDD.Core.Spec
{
    public interface Translator
    {
        Constraint Translate(string representation);
    }
}