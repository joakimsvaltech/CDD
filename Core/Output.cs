namespace CDD.Core
{
    public interface Output
    {
        void Text<T>(T obj);
        void Caption(string caption);
        void Divider();
        void Label(string label);
    }
}
