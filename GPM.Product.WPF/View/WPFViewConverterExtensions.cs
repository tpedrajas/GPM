namespace GPM.Product.WPF.View;

public static class WPFViewConverterExtensions
{

    #region methods

    public static Window ToWindow(this IWPFView view)
    {
        return (Window)view;
    }

    #endregion

}
