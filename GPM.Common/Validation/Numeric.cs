namespace GPM.Common.Validation;

public static class Numeric
{

    #region methods

    public static bool AreFloat(params string[] input)
    {
        bool areFloat = true;

        for (int i = input.Length - 1; areFloat && i >= 0; i--)
        {
            areFloat &= IsFloat(input[i]);
        }

        return areFloat;
    }

    public static bool IsFloat(string? input)
    {
        return float.TryParse(input, out _);
    }

    #endregion

}
