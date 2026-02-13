using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public record LocationInfo(Location Location, CultureInfo CultureInfo, TimeZoneInfo WindowsTimeZoneInfo, TimeZoneInfo NonWindowsTimeZoneInfo) { }

public static class Appointment
{
    private static Dictionary<Location, LocationInfo> _locationInfo = new()
    {
        {Location.London, new(Location.London,  new CultureInfo("en-GB"),  TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),  TimeZoneInfo.FindSystemTimeZoneById("Europe/London"))},
        {Location.NewYork, new(Location.NewYork,  new CultureInfo("en-US"),  TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),  TimeZoneInfo.FindSystemTimeZoneById("America/New_York"))},
        {Location.Paris, new(Location.Paris,  new CultureInfo("fr-FR"),  TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),  TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"))},
    };

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();


    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        return location switch
        {
            _ when RuntimeInformation.IsOSPlatform(OSPlatform.Windows) => ConvertToWindowsTimeZoneDateTime(appointmentDateDescription, location),
            _ => ConvertToNonWindowsTimeZoneDateTime(appointmentDateDescription, location),
        };
    }

    private static DateTime ConvertToWindowsTimeZoneDateTime(string appointmentDateDescription, Location location)
    {
        return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), _locationInfo[location].WindowsTimeZoneInfo);
    }

    private static DateTime ConvertToNonWindowsTimeZoneDateTime(string appointmentDateDescription, Location location)
    {
        return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), _locationInfo[location].NonWindowsTimeZoneInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Late => appointment.AddMinutes(-30),
            AlertLevel.Standard => appointment.AddMinutes(-105),
        };
    }

    
    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var previousDt = dt.AddDays(-7);
        return location switch
        {
            _ when RuntimeInformation.IsOSPlatform(OSPlatform.Windows) => _locationInfo[location].WindowsTimeZoneInfo.IsDaylightSavingTime(dt) != _locationInfo[location].WindowsTimeZoneInfo.IsDaylightSavingTime(previousDt),
            _ => _locationInfo[location].NonWindowsTimeZoneInfo.IsDaylightSavingTime(dt) != _locationInfo[location].NonWindowsTimeZoneInfo.IsDaylightSavingTime(previousDt),
        };
    }


    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        return DateTime.TryParse(dtStr, _locationInfo[location].CultureInfo, DateTimeStyles.None, out DateTime result) ? result : new DateTime(1, 1, 1);
    }
}
