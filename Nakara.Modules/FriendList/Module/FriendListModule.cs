using Nakara.Modules.FriendList.UI.ViewModels;
using Nakara.Modules.FriendList.UI.Views;

namespace Nakara.Modules.FriendList.Module
{
    internal class FriendListModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<FriendListUserControl>();
            containerRegistry.Register<FriendListUserControlViewModel>();
        }
    }
}
