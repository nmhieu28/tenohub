namespace HNM.Core.Helpers;

public static class DateHelper
{
    public static DateTime NewDateTime()
    {
        return ToDateTime(DateTimeOffset.Now.UtcDateTime);
    }

    private static DateTime ToDateTime(this DateTime date)
    {
        return DateTime.SpecifyKind(date, DateTimeKind.Utc);
    }
}