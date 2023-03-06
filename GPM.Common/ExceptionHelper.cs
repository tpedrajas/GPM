namespace GPM.Common;

public static class ExceptionHelper
{

    #region methods

    public static void Throw<E>() where E : Exception, new()
    {
        throw new E();
    }

    public static void Throw<E>(string? message) where E : Exception
    {
        throw LambdaExpressionHelper.GetLambdaException<E>(message);
    }

    public static void ThrowIfFalse<E>(bool value) where E : Exception, new()
    {
        if (!value)
        {
            throw new E();
        }
    }

    public static void ThrowIfFalse<E>(bool value, string? message) where E : Exception
    {
        if (!value)
        {
            throw LambdaExpressionHelper.GetLambdaException<E>(message);
        }
    }

    public static void ThrowIfNotNull<E>(object? value) where E : Exception, new()
    {
        if (value is not null)
        {
            throw new E();
        }
    }

    public static void ThrowIfNotNull<E>(object? value, string? message) where E : Exception
    {
        if (value is null)
        {
            throw LambdaExpressionHelper.GetLambdaException<E>(message);
        }
    }

    public static void ThrowIfNull<E>(object? value) where E : Exception, new()
    {
        if (value is null)
        {
            throw new E();
        }
    }

    public static void ThrowIfNull<E>(object? value, string? message) where E : Exception
    {
        if (value is null)
        {
            throw LambdaExpressionHelper.GetLambdaException<E>(message);
        }
    }

    public static void ThrowIfTrue<E>(bool value) where E : Exception, new()
    {
        if (value)
        {
            throw new E();
        }
    }

    public static void ThrowIfTrue<E>(bool value, string? message) where E : Exception
    {
        if (value)
        {
            throw LambdaExpressionHelper.GetLambdaException<E>(message);
        }
    }

    #endregion

}
