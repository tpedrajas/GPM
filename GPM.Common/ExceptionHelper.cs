namespace GPM.Common;

public static class ExceptionHelper
{

    #region methods

    public static void ThrowIfNull<ET>(object? value) where ET : Exception, new()
    {
        if (value is null)
        {
            throw new ET();
        }
    }

    public static void ThrowIfNull<ET>(object? value, string? message) where ET : Exception
    {
        if (value is null)
        {
            throw LambdaExpressionHelper.GetLambdaException<ET>(message);
        }
    }

    #endregion

}
