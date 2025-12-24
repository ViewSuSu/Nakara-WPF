using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace Nakara_WPF.Wealth
{
    /// <summary>
    /// WealthUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class WealthUserControl : UserControl
    {
        public WealthUserControl()
        {
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            DataContext = App.ServiceProvider.GetService<WealthViewModel>();
        }
    }
}
