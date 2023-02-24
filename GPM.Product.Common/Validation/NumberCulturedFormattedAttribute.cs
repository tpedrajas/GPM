namespace GPM.Product.Common.Validation;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class NumberCulturedFormattedAttribute : ValidationAttribute
{

    #region constructors / deconstructors / destructors

    public NumberCulturedFormattedAttribute()
    {

    }

    public NumberCulturedFormattedAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    #endregion

    #region methods

    public override bool IsValid(object? value)
    {
        string pattern = @"^-?([1-9][0-9]*|0)(\" + Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator + "[0-9]{1,})?$";
        Regex regex = new(pattern);

        return regex.IsMatch(value?.ToString() ?? "");
    }

    #endregion

}
