using Nakara.Framework.Core.Bases.ViewModels;

namespace Nakara.Modules.CommonFunction.UI.Hero.ViewModels
{
    internal class HeroPageViewModel : ViewModelBase
    {
        public HeroPageViewModel(IContainerExtension containerExtension)
            : base(containerExtension)
        {
            CloseCommand = new DelegateCommand(() =>
            {
                this.eventAggregator.GetEvent<RemoveMainContentRegionEvent>().Publish();
            });
        }

        public DelegateCommand CloseCommand { get; set; }
    }
}
