namespace HNM.Core;

public static class Check
{
    public static T NotNull<T>(T value, string parameterName)
    {
        if (value == null)
        {
            throw new ArgumentException(parameterName);
        }
        return value;
    }
}