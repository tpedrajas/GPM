namespace GPM.Design.Mvpvm;

public static class ViewConverterExtensions
{

    #region methods

    public static Window ToWindow(this IViewBase view)
    {
        return (Window)view;
    }

    #endregion

}
