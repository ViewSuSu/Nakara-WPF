using Nakara.Shared.Jsons;
using Nakara.Shared.Services.Abstractions;

namespace Nakara.Modules.PersonalInformation.UI.HistoryMatchRecord.ViewModels
{
    internal class HistoryMatchRecordPageViewModel : ViewModelBase
    {
        private readonly IMatchDataInfomation matchDataInfomation;
        public List<MatchDataItem> MatchDataItems { get; }

        public HistoryMatchRecordPageViewModel(
            IContainerExtension containerExtension,
            IMatchDataInfomation matchDataInfomation
        )
            : base(containerExtension)
        {
            this.matchDataInfomation = matchDataInfomation;
            this.MatchDataItems = this.matchDataInfomation.GetMatchDataItemsAsync().Result;
        }
    }
}
