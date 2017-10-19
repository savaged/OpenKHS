namespace OpenKHS.Interfaces
{
    public interface IMainView : IManagedView
    {
        void Show();
        object DataContext { get; set; }
    }
}