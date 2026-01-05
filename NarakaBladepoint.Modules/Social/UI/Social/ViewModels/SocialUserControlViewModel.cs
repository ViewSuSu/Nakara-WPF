using NarakaBladepoint.Modules.Social.UI.Email.Views;
using NarakaBladepoint.Modules.Social.UI.Friend.UI.Views;
using NarakaBladepoint.Modules.Social.UI.Setting.Views;
using NarakaBladepoint.Modules.Tutorial.UI.Views;

namespace NarakaBladepoint.Modules.Social.UI.Social.ViewModels
{
    public class SocialUserControlViewModel : ViewModelBase
    {
        public SocialUserControlViewModel(IContainerProvider containerProvider)
            : base(containerProvider)
        {
            NavigateToMusicCommand = new DelegateCommand(() =>
            {
                eventAggregator
                    .GetEvent<LoadHomePageRegionEvent>()
                    .Publish(nameof(TutorialUserControl));
            });
            NavigateToTutorialCommand = new DelegateCommand(() =>
            {
                eventAggregator
                    .GetEvent<LoadHomePageRegionEvent>()
                    .Publish(nameof(TutorialUserControl));
            });
            NavigateToEmailCommand = new DelegateCommand(() =>
            {
                eventAggregator
                    .GetEvent<LoadHomePageRegionEvent>()
                    .Publish(nameof(EmailUserControl));
            });
            NavigateToSettingCommand = new DelegateCommand(() =>
            {
                eventAggregator
                    .GetEvent<LoadHomePageRegionEvent>()
                    .Publish(nameof(SettingUserControl));
            });
            NavigateToFrendListCommand = new DelegateCommand(() =>
            {
                eventAggregator
                    .GetEvent<LoadHomePageRegionEvent>()
                    .Publish(nameof(FriendUserControl));
            });
        }

        public DelegateCommand NavigateToMusicCommand { get; }
        public DelegateCommand NavigateToTutorialCommand { get; }
        public DelegateCommand NavigateToEmailCommand { get; }
        public DelegateCommand NavigateToFrendListCommand { get; }
        public DelegateCommand NavigateToSettingCommand { get; }
    }
}
