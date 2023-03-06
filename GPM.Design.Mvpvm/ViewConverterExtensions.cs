namespace GPM.Design.Mvpvm;

internal static class ViewConverterExtensions
{

    #region methods

    internal static Window ToWindow(this IView view)
    {
        return (Window)view;
    }

    #endregion

}
