using Nakara.Framework.Core.Bases.ViewModels;

namespace Nakara.Modules.Tutorial.UI.ViewModels
{
    internal class TutorialUserControlViewModel : CanReturnToMainWindowPageViewModelBase
    {
        public TutorialUserControlViewModel(IContainerExtension containerExtension)
            : base(containerExtension) { }
    }
}
