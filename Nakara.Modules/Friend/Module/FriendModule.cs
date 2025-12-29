using Nakara.Modules.Friend.UI.ViewModels;
using Nakara.Modules.Friend.UI.Views;

namespace Nakara.Modules.Friend.Module
{
    internal class FriendModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<FriendUserControl>();
            containerRegistry.Register<FriendUserControlViewModel>();
        }
    }
}
