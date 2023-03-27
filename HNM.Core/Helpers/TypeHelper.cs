namespace HNM.Core.Helpers;

public static class TypeHelper
{
    
    public static bool IsDefaultValue(object? obj)
    {
        return obj == null || obj.Equals(GetDefaultValue(obj.GetType()));
    }

    private static object? GetDefaultValue(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}