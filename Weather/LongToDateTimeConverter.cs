using System.Globalization;

namespace Weather;

public class LongToDateTimeConverter : IValueConverter
{
    DateTime _time = new DateTime(1970, 1,1,0,0,0,0);
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        long datetime = (long)(int)value;
        return $"{_time.AddSeconds(datetime).ToString()} UTC";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
