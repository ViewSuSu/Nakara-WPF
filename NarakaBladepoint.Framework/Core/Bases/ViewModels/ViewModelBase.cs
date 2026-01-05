namespace NarakaBladepoint.Framework.Core.Bases.ViewModels
{
    /// <summary>
    /// ViewModel基类
    /// </summary>
    public abstract class ViewModelBase : BindableBase
    {
        protected readonly IEventAggregator eventAggregator;
        protected readonly IRegionManager regionManager;

        protected ViewModelBase(IContainerProvider containerProvider)
        {
            this.eventAggregator = containerProvider.Resolve<IEventAggregator>();
            this.regionManager = containerProvider.Resolve<IRegionManager>();
        }
    }
}
