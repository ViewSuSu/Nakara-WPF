using Nakara.Framework.Core.Bases.ViewModels;
using Nakara.Shared.Services.Abstractions;

namespace Nakara.Modules.StartGame.UI.ModeSelection.ViewModels
{
    internal class ModeSelectionUserControlViewModel : CanReturnToMainWindowPageViewModelBase
    {
        public ModeSelectionUserControlViewModel(IContainerExtension containerExtension)
            : base(containerExtension) { }
    }
}
