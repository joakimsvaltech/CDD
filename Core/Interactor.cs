namespace CDD.Core
{
    public interface Interactor
    {
        string Input();
        void Output<T>(T obj);
        void Caption(string caption);
        void Divider();
        void Label(string label);
    }
}
