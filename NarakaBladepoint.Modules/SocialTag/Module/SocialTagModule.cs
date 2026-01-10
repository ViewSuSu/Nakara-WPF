using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarakaBladepoint.Modules.SocialTag.UI.ViewModels;
using NarakaBladepoint.Modules.SocialTag.UI.Views;

namespace NarakaBladepoint.Modules.SocialTag.Module
{
    internal class SocialTagModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SocialTagPage, SocialTagPageViewModel>();
            containerRegistry.Register<TagUserControl>();
            containerRegistry.Register<TagUserControlViewModel>();
        }
    }
}
