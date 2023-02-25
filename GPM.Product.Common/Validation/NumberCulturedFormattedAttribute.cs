namespace GPM.Product.Common.Validation;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class NumberCulturedFormattedAttribute : ValidationAttribute
{

    #region constructors / deconstructors / destructors

    public NumberCulturedFormattedAttribute() : this(int.MaxValue, string.Empty)
    {

    }

    public NumberCulturedFormattedAttribute(string errorMessage) : this(int.MaxValue, errorMessage)
    {
        
    }

    public NumberCulturedFormattedAttribute(int maxPrecission) : this(maxPrecission, string.Empty)
    {

    }

    public NumberCulturedFormattedAttribute(int maxPrecission, string errorMessage)
    {
        _MaxPrecission = maxPrecission;
        ErrorMessage = errorMessage;
    }

    #endregion

    #region fields

    private readonly int _MaxPrecission;

    #endregion

    #region methods

    public override bool IsValid(object? value)
    {
        NumberFormatInfo numberFormatInfo;
        StringBuilder pattern;

        string? stringValue = Convert.ToString(value);
        bool isValid = false;

        if (!string.IsNullOrEmpty(stringValue))
        {
            numberFormatInfo = Thread.CurrentThread.CurrentCulture.NumberFormat;
            pattern = new($"^{numberFormatInfo.NegativeSign}?([1-9][0-9]*|0)", 3);

            if (_MaxPrecission > 0)
            {
                pattern.Append($@"(\{numberFormatInfo.NumberDecimalSeparator}[0-9]{{0,{Convert.ToString(_MaxPrecission - 1)}}}[1-9])?");
            }

            pattern.Append('$');

            isValid = Regex.IsMatch(stringValue, pattern.ToString());
        }

        return isValid;
    }

    #endregion

}
