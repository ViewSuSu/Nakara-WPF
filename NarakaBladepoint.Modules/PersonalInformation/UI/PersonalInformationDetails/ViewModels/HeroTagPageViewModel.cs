using NarakaBladepoint.Modules.PersonalInformation.Domain.Events;

namespace NarakaBladepoint.Modules.PersonalInformation.UI.PersonalInformationDetails.ViewModels
{
    internal class HeroTagPageViewModel : ViewModelBase
    {
        public HeroTagPageViewModel(IContainerProvider containerProvider)
            : base(containerProvider)
        {
            EscCommand = new DelegateCommand(() =>
            {
                eventAggregator
                    .GetEvent<RemovePersonalInformationDetailMainContentEvents>()
                    .Publish();
            });
            SaveCommand = new DelegateCommand(() => { });
        }

        public DelegateCommand EscCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
    }
}
