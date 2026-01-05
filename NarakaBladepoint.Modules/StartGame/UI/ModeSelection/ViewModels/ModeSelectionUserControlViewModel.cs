using NarakaBladepoint.Shared.Services.Abstractions;
using NarakaBladepoint.Shared.Services.Models;

namespace NarakaBladepoint.Modules.StartGame.UI.ModeSelection.ViewModels
{
    internal class ModeSelectionUserControlViewModel : CanRemoveHomePageRegionViewModelBase
    {
        private readonly IServerInformation serverInformation;

        public List<ServerInformationModel> ServerInfos { get; }

        private ServerInformationModel selectedItem;

        public ServerInformationModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                SetProperty(ref selectedItem, value);
            }
        }

        public ModeSelectionUserControlViewModel(
            IContainerProvider containerProvider,
            IServerInformation serverInformation
        )
            : base(containerProvider)
        {
            this.serverInformation = serverInformation;
            this.ServerInfos = this.serverInformation.GetServerInformationAsync().Result;
            SelectedItem = ServerInfos.FirstOrDefault();
        }

        public DelegateCommand ChoseHeroCommand { get; set; }
        public DelegateCommand ChoseMapCommand { get; set; }
    }
}
