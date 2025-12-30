using System;
using System.Collections;
using System.Collections.Generic;
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

namespace Nakara.Controls
{
    /// <summary>
    /// UpwardComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class UpwardComboBox : UserControl
    {
        #region ItemsSource
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource",
            typeof(IEnumerable),
            typeof(UpwardComboBox),
            new PropertyMetadata(null)
        );
        #endregion

        #region SelectedItem
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem",
                typeof(object),
                typeof(UpwardComboBox),
                new PropertyMetadata(null)
            );
        #endregion

        #region ItemTemplate
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                "ItemTemplate",
                typeof(DataTemplate),
                typeof(UpwardComboBox),
                new PropertyMetadata(null)
            );
        #endregion

        // 点击显示区展开 Popup
        private void DisplayBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PART_Popup.IsOpen = !PART_Popup.IsOpen;
            // 根据 Popup 状态显示对应箭头
            if (PART_Popup.IsOpen)
            {
                ArrowCollapsed.Visibility = Visibility.Collapsed;
                ArrowExpanded.Visibility = Visibility.Visible;
            }
            else
            {
                ArrowCollapsed.Visibility = Visibility.Visible;
                ArrowExpanded.Visibility = Visibility.Collapsed;
            }
        }

        // 点击列表项选择
        private void Item_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement fe)
            {
                SelectedItem = fe.DataContext;
                PART_Popup.IsOpen = false;
            }
        }

        public UpwardComboBox()
        {
            InitializeComponent();
        }
    }
}
