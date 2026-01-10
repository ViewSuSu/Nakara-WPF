using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NarakaBladepoint.Modules.SocialTag.UI.Views
{
    /// <summary>
    /// SocialTagPage.xaml 的交互逻辑
    /// </summary>
    public partial class SocialTagPage : UserControlBase
    {
        public SocialTagPage()
        {
            InitializeComponent();
        }

        #region 第一组CheckBox：在线时间（互斥）

        private void DaytimeOnlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (DaytimeOnlineCheckBox.IsChecked == true)
            {
                NightOnlineCheckBox.IsChecked = false;
                AllDayOnlineCheckBox.IsChecked = false;
                WeekendOnlineCheckBox.IsChecked = false;
                CasualOnlineCheckBox.IsChecked = false;
            }
        }

        private void NightOnlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (NightOnlineCheckBox.IsChecked == true)
            {
                DaytimeOnlineCheckBox.IsChecked = false;
                AllDayOnlineCheckBox.IsChecked = false;
                WeekendOnlineCheckBox.IsChecked = false;
                CasualOnlineCheckBox.IsChecked = false;
            }
        }

        private void AllDayOnlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (AllDayOnlineCheckBox.IsChecked == true)
            {
                DaytimeOnlineCheckBox.IsChecked = false;
                NightOnlineCheckBox.IsChecked = false;
                WeekendOnlineCheckBox.IsChecked = false;
                CasualOnlineCheckBox.IsChecked = false;
            }
        }

        private void WeekendOnlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (WeekendOnlineCheckBox.IsChecked == true)
            {
                DaytimeOnlineCheckBox.IsChecked = false;
                NightOnlineCheckBox.IsChecked = false;
                AllDayOnlineCheckBox.IsChecked = false;
                CasualOnlineCheckBox.IsChecked = false;
            }
        }

        private void CasualOnlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CasualOnlineCheckBox.IsChecked == true)
            {
                DaytimeOnlineCheckBox.IsChecked = false;
                NightOnlineCheckBox.IsChecked = false;
                AllDayOnlineCheckBox.IsChecked = false;
                WeekendOnlineCheckBox.IsChecked = false;
            }
        }

        #endregion

        #region 第二组CheckBox：麦克风（互斥）

        private void HasMicrophoneCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (HasMicrophoneCheckBox.IsChecked == true)
            {
                NoMicrophoneCheckBox.IsChecked = false;
            }
        }

        private void NoMicrophoneCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (NoMicrophoneCheckBox.IsChecked == true)
            {
                HasMicrophoneCheckBox.IsChecked = false;
            }
        }

        #endregion
    }
}
