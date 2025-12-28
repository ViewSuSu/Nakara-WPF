using Nakara.Framework.Core.Bases.ViewModels;

namespace Nakara.Modules.Tutorial.UI.ViewModels
{
    internal class TutorialUserControlViewModel : CanReturnToMainWindowPageViewModelBase
    {
        public TutorialUserControlViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator) { }
    }
}
