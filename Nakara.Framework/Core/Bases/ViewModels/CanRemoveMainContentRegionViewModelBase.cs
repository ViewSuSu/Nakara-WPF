using Nakara.Framework.Core.Evens;

namespace Nakara.Framework.Core.Bases.ViewModels
{
    public abstract class CanRemoveMainContentRegionViewModelBase : ViewModelBase
    {
        protected CanRemoveMainContentRegionViewModelBase(IContainerExtension containerExtension)
            : base(containerExtension)
        {
            ReturnCommand = new DelegateCommand(() =>
            {
                this.eventAggregator.GetEvent<RemoveMainContentRegionEvent>().Publish();
            });
        }

        public DelegateCommand ReturnCommand { get; }
    }
}
