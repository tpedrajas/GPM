namespace GPM.WPF.View;

/// <summary>
/// Interaction logic for CubeIntersectionView.xaml
/// </summary>
public partial class CubeIntersectionView : Window, ICubeIntersectionView
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionView()
    {
        InitializeComponent();
    }

    #endregion

    #region methods

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        NumberFormatInfo info = CultureInfo.CurrentCulture.NumberFormat;
        string pattern = $@"^-?[0-9]*\" + Regex.Escape(info.CurrencyDecimalSeparator) + "?[0-9]{0,2}$";

        Regex regex = new(pattern);
        e.Handled = !regex.IsMatch(e.Text, 0);
    }

    #endregion

}
