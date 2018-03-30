
namespace OpenKHS.Interfaces
{
    public interface IMainViewModel : IViewManager
    {
        IViewModel CongregationVM { get; }
        IViewModel PublicTalksVM { get; }
        IViewModel PmScheduleVM { get; }
        IViewModel ClmmScheduleVM { get; }
    }
}