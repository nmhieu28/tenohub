namespace HNM.Core;

public class CoreException : Exception
{
    public CoreException(string message): base(message)
    {
    }

    public static CoreException Exception(string message)
    {
        return new CoreException(message);
    }

    public static CoreException NullArgument(string arg)
    {
        return new CoreException($"{arg} can not be null");
    }

    public static CoreException InvalidArgument(string arg)
    {
        return new CoreException($"{arg} is invalid");
    }

    public static CoreException NotFound(string arg)
    {
        return new CoreException($"{arg} was not found");
    }
}