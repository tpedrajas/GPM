namespace GPM.Product.Common;

public static class ExceptionManager
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
            throw LambdaExpressionManager.GetLambdaException<ET>(message);
        }
    }

    #endregion

}
