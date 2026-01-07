using System.ComponentModel;
using System.Windows.Media;
using NarakaBladepoint.Modules.StartGame.UI.HeroChose.Models;
using NarakaBladepoint.Shared.Services.Abstractions;

namespace NarakaBladepoint.Modules.StartGame.UI.HeroChose.ViewModels
{
    internal class HeroChoseUserControlViewModel : CanRemoveHomePageRegionViewModelBase
    {
        private readonly IHeroInfomation heroInfomation;
        private readonly ICurrentUserInformationProvider currentUserInformationProvider;

        public BindingList<HeroChoseModuleItemModel> HeroChoseModuleItemModels { get; }

        private int firstHeroIndex = -1;
        private int secondHeroIndex = -1;
        private int thirdHeroIndex = -1;

        public int FirstHeroIndex
        {
            get { return firstHeroIndex; }
            set
            {
                firstHeroIndex = value;
                RaisePropertyChanged(nameof(FirstHeroAvatar));
                RaisePropertyChanged(nameof(IsCanSelcted));
                RaisePropertyChanged(nameof(FirstHeroIsNull));
            }
        }

        public int SecondHeroIndex
        {
            get { return secondHeroIndex; }
            set
            {
                secondHeroIndex = value;
                RaisePropertyChanged(nameof(SecondHeroAvatar));
                RaisePropertyChanged(nameof(IsCanSelcted));
                RaisePropertyChanged(nameof(SecondHeroIsNull));
            }
        }

        public int ThirdHeroIndex
        {
            get { return thirdHeroIndex; }
            set
            {
                thirdHeroIndex = value;
                RaisePropertyChanged(nameof(ThirdHeroAvatar));
                RaisePropertyChanged(nameof(IsCanSelcted));
                RaisePropertyChanged(nameof(ThirdHeroIsNull));
            }
        }

        public ImageSource FirstHeroAvatar =>
            FirstHeroIndex != -1
                ? this.heroInfomation.GetHeroAvatarModelByIdAsync(FirstHeroIndex).Result.Avatar
                : null;
        public ImageSource SecondHeroAvatar =>
            SecondHeroIndex != -1
                ? this.heroInfomation.GetHeroAvatarModelByIdAsync(SecondHeroIndex).Result.Avatar
                : null;
        public ImageSource ThirdHeroAvatar =>
            ThirdHeroIndex != -1
                ? this.heroInfomation.GetHeroAvatarModelByIdAsync(ThirdHeroIndex).Result.Avatar
                : null;

        public bool IsCanSelcted => FirstHeroIsNull || SecondHeroIsNull || ThirdHeroIsNull;

        public bool FirstHeroIsNull => FirstHeroIndex == -1;
        public bool SecondHeroIsNull => SecondHeroIndex == -1;
        public bool ThirdHeroIsNull => ThirdHeroIndex == -1;

        public HeroChoseUserControlViewModel(
            IContainerProvider containerProvider,
            IHeroInfomation heroInfomation,
            ICurrentUserInformationProvider currentUserInformationProvider
        )
            : base(containerProvider)
        {
            this.heroInfomation = heroInfomation;
            this.currentUserInformationProvider = currentUserInformationProvider;
            this.HeroChoseModuleItemModels = new BindingList<HeroChoseModuleItemModel>(
                heroInfomation
                    .GetHeroAvatarModelsAsync()
                    .Result.Select(x => new HeroChoseModuleItemModel(x))
                    .ToArray()
            );
            HeroChoseModuleItemModels.ListChanged += (o, e) =>
            {
                if (
                    e.PropertyDescriptor != null
                    && e.PropertyDescriptor.Name == HeroChoseModuleItemModel.IsSelectedProperty
                    && HeroChoseModuleItemModels[e.NewIndex].IsSelected
                )
                {
                    if (FirstHeroIndex == -1)
                    {
                        FirstHeroIndex = e.NewIndex;
                    }
                    else if (SecondHeroIndex == -1)
                    {
                        SecondHeroIndex = e.NewIndex;
                    }
                    else if (ThirdHeroIndex == -1)
                    {
                        ThirdHeroIndex = e.NewIndex;
                    }
                }
            };

            var userModel = currentUserInformationProvider.GetCurrentUserInfoAsync().Result;
            FirstHeroIndex = userModel.FirstPickHeroIndex;
            SecondHeroIndex = userModel.SecondPickHeroIndex;
            ThirdHeroIndex = userModel.ThridPickHeroIndex;
            if (FirstHeroIndex != -1)
                HeroChoseModuleItemModels[FirstHeroIndex].IsSelected = true;
            if (SecondHeroIndex != -1)
                HeroChoseModuleItemModels[SecondHeroIndex].IsSelected = true;
            if (ThirdHeroIndex != -1)
                HeroChoseModuleItemModels[ThirdHeroIndex].IsSelected = true;

            RemoveFirstHeroCommand = new DelegateCommand(() =>
            {
                HeroChoseModuleItemModels[FirstHeroIndex].IsSelected = false;
                FirstHeroIndex = -1;
            });
            RemoveSecondHeroCommand = new DelegateCommand(() =>
            {
                HeroChoseModuleItemModels[SecondHeroIndex].IsSelected = false;
                SecondHeroIndex = -1;
            });
            RemoveThirdHeroCommand = new DelegateCommand(() =>
            {
                HeroChoseModuleItemModels[ThirdHeroIndex].IsSelected = false;
                ThirdHeroIndex = -1;
            });
            SaveCommand = new DelegateCommand(Save);
            ClearCommand = new DelegateCommand(Clear);
            SelectedHeroCommand = new DelegateCommand<HeroChoseModuleItemModel>(SelectedHero);
        }

        private void SelectedHero(HeroChoseModuleItemModel selectedModel)
        {
            selectedModel.IsSelected = true;
        }

        private void Clear()
        {
            RemoveFirstHeroCommand.Execute();
            RemoveSecondHeroCommand.Execute();
            RemoveThirdHeroCommand.Execute();
        }

        public DelegateCommand RemoveFirstHeroCommand { get; }
        public DelegateCommand RemoveSecondHeroCommand { get; }
        public DelegateCommand RemoveThirdHeroCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand ClearCommand { get; }
        public DelegateCommand<HeroChoseModuleItemModel> SelectedHeroCommand { get; }

        private async void Save()
        {
            await heroInfomation.SaveHeroChoseIndex(
                FirstHeroIndex,
                SecondHeroIndex,
                ThirdHeroIndex
            );
        }
    }
}
