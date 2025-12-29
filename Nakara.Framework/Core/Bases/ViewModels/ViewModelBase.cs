using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nakara.Framework.Core.Evens;

namespace Nakara.Framework.Core.Bases.ViewModels
{
    /// <summary>
    /// ViewModel基类
    /// </summary>
    public abstract class ViewModelBase : BindableBase
    {
        private readonly IContainerExtension containerExtension;
        protected readonly IEventAggregator eventAggregator;
        protected readonly IRegionManager regionManager;

        protected ViewModelBase(IContainerExtension containerExtension)
        {
            this.containerExtension = containerExtension;
            this.eventAggregator = containerExtension.Resolve<IEventAggregator>();
            this.regionManager = containerExtension.Resolve<IRegionManager>();
        }
    }
}
