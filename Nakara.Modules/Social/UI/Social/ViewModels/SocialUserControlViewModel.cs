using Nakara.Modules.Social.UI.FriendList.Views;

namespace Nakara.Modules.Social.UI.Social.ViewModels
{
    public class SocialUserControlViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public SocialUserControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            OpenFrendListCommand = new DelegateCommand(OnOpenFriendList);
        }

        public DelegateCommand OpenFrendListCommand { get; }

        private void OnOpenFriendList()
        {
            _eventAggregator
                .GetEvent<LoadSidePanelRegionEvent>()
                .Publish(nameof(FriendListUserControl));
        }
    }
}
