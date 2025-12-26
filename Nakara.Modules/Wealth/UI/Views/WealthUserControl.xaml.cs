using System.ComponentModel;
using System.Windows.Controls;
using Nakara.Framework.Core.Bases;

namespace Nakara.Modules.Wealth.UI.Views
{
    /// <summary>
    /// WealthUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class WealthUserControl : UserControlBase
    {
        public WealthUserControl()
        {
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
        }
    }
}
