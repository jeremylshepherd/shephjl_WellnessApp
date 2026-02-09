using System.Globalization;

namespace shephjl_WellnessApp.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture
    )
    {
        if (value is bool isSelected && isSelected)
        {
            return Color.FromArgb("#2196F3"); // Blue when selected
        }
        return Color.FromArgb("#FFFFFF"); // Light gray when not selected
    }

    // Only here to satisfy the IValueConverter interface
    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture
    )
    {
        throw new NotImplementedException();
    }
}
