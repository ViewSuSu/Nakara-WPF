using Nakara.Modules.Social.UI.Email.ViewModels;
using Nakara.Modules.Social.UI.Email.Views;
using Nakara.Modules.Social.UI.Friend.UI.ViewModels;
using Nakara.Modules.Social.UI.Friend.UI.Views;
using Nakara.Modules.Social.UI.Music.ViewModels;
using Nakara.Modules.Social.UI.Music.Views;
using Nakara.Modules.Social.UI.Setting.ViewModels;
using Nakara.Modules.Social.UI.Setting.Views;
using Nakara.Modules.Social.UI.Social.ViewModels;
using Nakara.Modules.Social.UI.Social.Views;

namespace Nakara.Modules.Social.Module
{
    internal class SocialModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<
                SettingUserControl,
                SettingUserControlViewModel
            >();
            containerRegistry.RegisterForNavigation<EmailUserControl, EmailUserControlViewModel>();
            containerRegistry.RegisterForNavigation<MusicUserControl, MusicUserControlViewModel>();
            containerRegistry.RegisterForNavigation<
                FriendUserControl,
                FriendUserControlViewModel
            >();
            containerRegistry.Register<SocialUserControl>();
            containerRegistry.Register<SocialUserControlViewModel>();
        }
    }
}
