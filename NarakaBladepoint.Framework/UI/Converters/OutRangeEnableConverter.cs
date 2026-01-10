using System.Globalization;
using System.Windows.Data;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class OutRangeEnableConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            if (values.Length != 3)
                return true;

            if (
                values[0] is not int selectedCount
                || values[1] is not bool isSelected
                || values[2] is not int maxCount
            )
                return true;

            // 已选中的永远允许取消
            if (isSelected)
                return true;

            // 未选中的，达到上限后禁用
            return selectedCount < maxCount;
        }

        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture
        ) => throw new NotImplementedException();
    }
}
