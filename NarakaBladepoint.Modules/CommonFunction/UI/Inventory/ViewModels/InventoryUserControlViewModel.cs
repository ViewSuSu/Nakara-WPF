using System.ComponentModel;
using NarakaBladepoint.Modules.CommonFunction.UI.Inventory.Models;

namespace NarakaBladepoint.Modules.CommonFunction.UI.Inventory.ViewModels
{
    internal class InventoryUserControlViewModel : CanRemoveMainContentRegionViewModelBase
    {
        public BindingList<InventoryItemModel> InventoryItemModels { get; set; } = [];

        public InventoryUserControlViewModel(IContainerProvider containerProvider)
            : base(containerProvider)
        {
            ClickItemComamnd = new DelegateCommand(() => { });
        }

        public DelegateCommand ClickItemComamnd { get; set; }
    }
}
