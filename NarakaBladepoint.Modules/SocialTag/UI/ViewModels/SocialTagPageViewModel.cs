using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarakaBladepoint.Modules.SocialTag.UI.Models;
using NarakaBladepoint.Shared.Datas;
using NarakaBladepoint.Shared.Services.Abstractions;

namespace NarakaBladepoint.Modules.SocialTag.UI.ViewModels
{
    internal class SocialTagPageViewModel : CanRemoveHomePageRegionViewModelBase
    {
        private readonly ICurrentUserInfoProvider currentUserInfoProvider;
        private readonly ISocialTagProvider socialTagProvider;
        private readonly IConfiguration configuration;

        /// <summary>
        /// 当前选中的标签数量
        /// </summary>
        public int SelectedCount =>
            FightTags
                .Concat(SocialTags)
                .Concat(PersonalityTags)
                .Concat(ModeTags)
                .Concat(LanguageTags)
                .Count(x => x.IsSelected);

        public int MaxCount { get; set; } = 4;

        public int[] SelectedTagIndex =>
            FightTags
                .Concat(SocialTags)
                .Concat(PersonalityTags)
                .Concat(ModeTags)
                .Concat(LanguageTags)
                .Select(x => x.SocialTagData.Index)
                .ToArray();

        public IEnumerable<SocialTagModel> SelectedSocialTagModels =>
            FightTags
                .Concat(SocialTags)
                .Concat(PersonalityTags)
                .Concat(ModeTags)
                .Concat(LanguageTags)
                .Where(x => x.IsSelected);

        public SocialTagPageViewModel(
            IContainerProvider containerProvider,
            ICurrentUserInfoProvider currentUserInfoProvider,
            ISocialTagProvider socialTagProvider,
            IConfiguration configuration
        )
            : base(containerProvider)
        {
            this.currentUserInfoProvider = currentUserInfoProvider;
            this.socialTagProvider = socialTagProvider;
            this.configuration = configuration;

            // 初始化当前用户信息
            this.CurrentUserModel = this.currentUserInfoProvider.GetCurrentUserInfoAsync().Result;

            // 1. 战斗类标签（替换为BindingList）
            FightTags = new BindingList<SocialTagModel>(
                this.socialTagProvider.GetSocialTags(SocialTagType.Fight)
                    .Result.Select(x => new SocialTagModel(x)
                    {
                        IsSelected = socialTagProvider
                            .GetSocialTagIsSelectedByIndex(x.Index)
                            .Result,
                    })
                    .ToList()
            );

            // 2. 社交类标签（替换为BindingList）
            SocialTags = new BindingList<SocialTagModel>(
                this.socialTagProvider.GetSocialTags(SocialTagType.Social)
                    .Result.Select(x => new SocialTagModel(x)
                    {
                        IsSelected = socialTagProvider
                            .GetSocialTagIsSelectedByIndex(x.Index)
                            .Result,
                    })
                    .ToList()
            );

            // 3. 个性类标签（替换为BindingList）
            PersonalityTags = new BindingList<SocialTagModel>(
                this.socialTagProvider.GetSocialTags(SocialTagType.Personality)
                    .Result.Select(x => new SocialTagModel(x)
                    {
                        IsSelected = socialTagProvider
                            .GetSocialTagIsSelectedByIndex(x.Index)
                            .Result,
                    })
                    .ToList()
            );

            // 4. 模式类标签（替换为BindingList）
            ModeTags = new BindingList<SocialTagModel>(
                this.socialTagProvider.GetSocialTags(SocialTagType.Mode)
                    .Result.Select(x => new SocialTagModel(x)
                    {
                        IsSelected = socialTagProvider
                            .GetSocialTagIsSelectedByIndex(x.Index)
                            .Result,
                    })
                    .ToList()
            );

            // 5. 语言类标签（替换为BindingList）
            LanguageTags = new BindingList<SocialTagModel>(
                this.socialTagProvider.GetSocialTags(SocialTagType.Language)
                    .Result.Select(x => new SocialTagModel(x)
                    {
                        IsSelected = socialTagProvider
                            .GetSocialTagIsSelectedByIndex(x.Index)
                            .Result,
                    })
                    .ToList()
            );

            // 订阅所有BindingList的ListChanged事件
            FightTags.ListChanged += OnTagListChanged;
            SocialTags.ListChanged += OnTagListChanged;
            PersonalityTags.ListChanged += OnTagListChanged;
            ModeTags.ListChanged += OnTagListChanged;
            LanguageTags.ListChanged += OnTagListChanged;

            MouseLeftButtonDown = new DelegateCommand<SocialTagModel>(tag =>
            {
                tag.IsSelected = !tag.IsSelected;
                CurrentUserModel.SelectedHeroTags = SelectedTagIndex;
                this.configuration.Save(CurrentUserModel);
            });
            RaisePropertyChanged(nameof(SelectedCount));
            RaisePropertyChanged(nameof(SelectedSocialTagModels));
        }

        /// <summary>
        /// BindingList变更事件处理方法
        /// </summary>
        /// <param name="sender">触发事件的BindingList</param>
        /// <param name="e">事件参数</param>
        private void OnTagListChanged(object sender, ListChangedEventArgs e)
        {
            if (
                e.PropertyDescriptor != null
                && e.PropertyDescriptor.Name == SocialTagModel.IsSelectedPropertyName
            )
            {
                RaisePropertyChanged(nameof(SelectedCount));
                RaisePropertyChanged(nameof(SelectedSocialTagModels));
            }
        }

        // 当前用户信息（原有）
        public UserInformationData CurrentUserModel { get; private set; }

        // 战斗类标签列表（改为BindingList）
        public BindingList<SocialTagModel> FightTags { get; }

        // 社交类标签列表（改为BindingList）
        public BindingList<SocialTagModel> SocialTags { get; }

        // 个性类标签列表（改为BindingList）
        public BindingList<SocialTagModel> PersonalityTags { get; }

        // 模式类标签列表（改为BindingList）
        public BindingList<SocialTagModel> ModeTags { get; }

        // 语言类标签列表（改为BindingList）
        public BindingList<SocialTagModel> LanguageTags { get; }

        public DelegateCommand<SocialTagModel> MouseLeftButtonDown { get; set; }
    }
}
