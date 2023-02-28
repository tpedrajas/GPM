namespace GPM.Product.Mvpvm.View;

public static class MvpvmViewConverterExtensions
{

    #region methods

    public static Window ToWindow(this IMvpvmView view)
    {
        return (Window)view;
    }

    #endregion

}
