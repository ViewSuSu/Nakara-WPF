using Nakara.Modules.EventCenter.UI.BaiZeCard.ViewModels;
using Nakara.Modules.EventCenter.UI.BaiZeCard.Views;
using Nakara.Modules.EventCenter.UI.BindReward.ViewModels;
using Nakara.Modules.EventCenter.UI.BindReward.Views;
using Nakara.Modules.EventCenter.UI.LatestNews.ViewModels;
using Nakara.Modules.EventCenter.UI.LatestNews.Views;
using Nakara.Modules.EventCenter.UI.Main.ViewModels;
using Nakara.Modules.EventCenter.UI.Main.Views;
using Nakara.Modules.EventCenter.UI.MoonGazingPavilion.ViewModels;
using Nakara.Modules.EventCenter.UI.MoonGazingPavilion.Views;
using Nakara.Modules.EventCenter.UI.NetEasePayRewards.ViewModels;
using Nakara.Modules.EventCenter.UI.NetEasePayRewards.Views;
using Nakara.Modules.EventCenter.UI.PassingTheFlame.ViewModels;
using Nakara.Modules.EventCenter.UI.PassingTheFlame.Views;
using Nakara.Modules.EventCenter.UI.PatchNote.ViewModels;
using Nakara.Modules.EventCenter.UI.PatchNote.Views;
using Nakara.Modules.EventCenter.UI.PenglaiGuide.ViewModels;
using Nakara.Modules.EventCenter.UI.PenglaiGuide.Views;
using Nakara.Modules.EventCenter.UI.TargetedChestGuarantee.ViewModels;
using Nakara.Modules.EventCenter.UI.TargetedChestGuarantee.Views;
using Nakara.Modules.EventCenter.UI.TimeLimitedEvent.ViewModels;
using Nakara.Modules.EventCenter.UI.TimeLimitedEvent.Views;

namespace Nakara.Modules.EventCenter.Module
{
    internal class EventCenterModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<
                EventCenterMainUserControl,
                EventCenterMainUserControlViewModel
            >();
            containerRegistry.RegisterForNavigation<LatestNewsPage, LatestNewsPageViewModel>();
            containerRegistry.RegisterForNavigation<PatchNotePage, PatchNotePageViewModel>();
            containerRegistry.RegisterForNavigation<
                NetEasePayRewardsPage,
                NetEasePayRewardsPageViewModel
            >();
            containerRegistry.RegisterForNavigation<
                MoonGazingPavilionPage,
                MoonGazingPavilionPageViewModel
            >();
            containerRegistry.RegisterForNavigation<BaiZeCardPage, BaiZeCardPageViewModel>();
            containerRegistry.RegisterForNavigation<BindRewardPage, BindRewardPageViewModel>();
            containerRegistry.RegisterForNavigation<PenglaiGuidePage, PenglaiGuidePageViewModel>();
            containerRegistry.RegisterForNavigation<
                TargetedChestGuaranteePage,
                TargetedChestGuaranteePageViewModel
            >();
            containerRegistry.RegisterForNavigation<
                PassingTheFlamePage,
                PassingTheFlamePageViewModel
            >();
            containerRegistry.RegisterForNavigation<
                TimeLimitedEventPage,
                TimeLimitedEventPageViewModel
            >();
        }
    }
}
