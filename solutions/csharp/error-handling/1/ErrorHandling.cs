public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception("You need to implement this method.");

    public static int? HandleErrorByReturningNullableType(string input) => int.TryParse(input, out int result) ? result : null;

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        if (int.TryParse(input, out int x))
        {
            result = x;
            return true;
        }
        else
        {
            result = -1;
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception();
        }
        finally
        {
            disposableObject.Dispose();
        }
    }
}
