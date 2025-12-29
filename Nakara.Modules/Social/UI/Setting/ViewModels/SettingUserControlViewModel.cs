using Nakara.Framework.Core.Bases.ViewModels;
using Nakara.Modules.Tutorial.UI.Views;

namespace Nakara.Modules.Social.UI.Setting.ViewModels
{
    internal class SettingUserControlViewModel : CanRemoveHomePageRegionViewModelBase
    {
        public SettingUserControlViewModel(IContainerExtension containerExtension)
            : base(containerExtension)
        {
            NavigateToTutorialCommand = new DelegateCommand(() =>
            {
                this.eventAggregator.GetEvent<LoadHomePageRegionEvent>()
                    .Publish(nameof(TutorialUserControl));
            });
            ExitCommand = new DelegateCommand(() =>
            {
                System.Windows.Application.Current.Shutdown();
            });
        }

        public DelegateCommand NavigateToTutorialCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }
    }
}
