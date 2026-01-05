namespace NarakaBladepoint.Modules.DayEvent.UI.ViewModels
{
    internal class DayEventUserControlViewModel : ViewModelBase
    {
        public DayEventUserControlViewModel(IContainerProvider containerProvider)
            : base(containerProvider)
        {
            TaskDetailsComamnd = new DelegateCommand(() => { });
        }

        public DelegateCommand TaskDetailsComamnd { get; set; }
    }
}
