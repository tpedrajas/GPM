namespace GPM.Product.Common;

public static class LambdaExpressionManager
{

    #region fields

    private static readonly Dictionary<(Type, string?), Delegate> _LambdaExceptionMessageDictionary = new();

    #endregion fields

    #region methods

    public static ET GetLambdaException<ET>(string? message) where ET : Exception
    {
        Type exceptionType = typeof(ET);

        if (!_LambdaExceptionMessageDictionary.TryGetValue((exceptionType, message), out Delegate? exceptionDelegate))
        {
            Type parameterType1 = typeof(string);
            ConstructorInfo constructor = exceptionType.GetConstructor(new Type[] { parameterType1 })!;

            ParameterExpression paramExpression1 = Expression.Parameter(parameterType1);
            NewExpression newExpression = Expression.New(constructor, new ParameterExpression[] { paramExpression1 });

            LambdaExpression lambdaExpression = Expression.Lambda(newExpression, new ParameterExpression[] { paramExpression1 });
            exceptionDelegate = lambdaExpression.Compile();

            _LambdaExceptionMessageDictionary.Add((exceptionType, message), exceptionDelegate);
        }

        return (ET)exceptionDelegate.DynamicInvoke(new object?[] { message })!;
    }

    #endregion

}
