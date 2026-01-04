using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nakara.Modules.DayEvent.UI.ViewModels
{
    class DayEventUserControlViewModel : ViewModelBase
    {
        public DayEventUserControlViewModel(IContainerExtension containerExtension)
            : base(containerExtension)
        {
            TaskDetailsComamnd = new DelegateCommand(() => { });
        }

        public DelegateCommand TaskDetailsComamnd { get; set; }
    }
}
