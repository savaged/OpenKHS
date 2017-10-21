
namespace OpenKHS.Interfaces
{
    public interface IMainViewModel : IViewManager
    {
        IDataViewModel CongregationVM { get; }
        IDataViewModel PublicTalksVM { get; }
        IDataViewModel PmScheduleVM { get; }
        IDataViewModel ClmmScheduleVM { get; }
    }
}