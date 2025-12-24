using CommunityToolkit.Mvvm.ComponentModel;
using Nakara_WPF.Models;

namespace Nakara_WPF.Wealth
{
    public partial class WealthViewModel : ObservableObject
    {
        public WealthModel WealthModel { get; }

        public WealthViewModel() { }
    }
}
