using Nakara.Modules.Tutorial.UI.ViewModels;
using Nakara.Modules.Tutorial.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nakara.Modules.Tutorial.Module
{
    internal class TutorialModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TutorialUserControl, TutorialUserControlViewModel>();
        }
    }
}
