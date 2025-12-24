using System;
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
    public class IconTextBlockCustomControl : Control
    {
        static IconTextBlockCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(IconTextBlockCustomControl),
                new FrameworkPropertyMetadata(typeof(IconTextBlockCustomControl))
            );
        }

        #region Icon（图片）

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            nameof(Icon),
            typeof(ImageSource),
            typeof(IconTextBlockCustomControl),
            new PropertyMetadata(null)
        );

        #endregion

        #region Text（文本）

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(IconTextBlockCustomControl),
            new PropertyMetadata(string.Empty)
        );

        #endregion

        #region Command（鼠标左键命令）

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(IconTextBlockCustomControl),
            new PropertyMetadata(null)
        );

        #endregion
    }
}
