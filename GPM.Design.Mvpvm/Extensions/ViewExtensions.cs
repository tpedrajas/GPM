namespace GPM.Design.Mvpvm.Extensions;

internal static class ViewExtensions
{

    #region methods

    internal static void Close(this IView view)
    {
        view.ToWindow().Close();
    }

    internal static void Show(this IView view)
    {
        view.ToWindow().Show();
    }

    internal static bool? ShowDialog(this IView view)
    {
        return view.ToWindow().ShowDialog();
    }

    internal static Window ToWindow(this IView view)
    {
        return (Window)view;
    }

    #endregion

}
