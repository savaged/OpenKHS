namespace OpenKHS.Interfaces
{
    public interface IViewState
    {
        bool IsBusy { get; set; }
        bool IsNotBusy { get; }
    }
}