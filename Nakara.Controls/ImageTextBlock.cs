using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nakara.Controls
{
    public class ImageTextBlock : Control
    {
        static ImageTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ImageTextBlock),
                new FrameworkPropertyMetadata(typeof(ImageTextBlock))
            );
        }

        /// <summary>
        /// 图片源
        /// </summary>
        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            nameof(Source),
            typeof(ImageSource),
            typeof(ImageTextBlock),
            new PropertyMetadata(null)
        );

        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(ImageTextBlock),
            new PropertyMetadata(string.Empty)
        );
    }
}
