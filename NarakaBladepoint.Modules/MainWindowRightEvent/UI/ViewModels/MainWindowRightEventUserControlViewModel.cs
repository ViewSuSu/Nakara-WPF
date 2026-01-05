namespace NarakaBladepoint.Modules.MainWindowRightEvent.UI.ViewModels
{
    internal class MainWindowRightEventUserControlViewModel : ViewModelBase
    {
        public MainWindowRightEventUserControlViewModel(IContainerProvider containerProvider)
            : base(containerProvider)
        {
            EventOneCommand = new DelegateCommand(() => { });
            EventFourCommand = new DelegateCommand(() => { });
            EventEightCommand = new DelegateCommand(() => { });
        }

        public DelegateCommand EventOneCommand { get; set; }
        public DelegateCommand EventFourCommand { get; set; }
        public DelegateCommand EventEightCommand { get; set; }
    }
}
