namespace GPM.Design.Mvpvm;

internal static class ViewPresentatorExtensions
{

    #region methods

    internal static void Close(this IView view)
    {
        Window window = view.ToWindow();
        window.Close();
    }

    internal static void Show(this IView view)
    {
        Window window = view.ToWindow();
        window.Show();
    }

    internal static bool? ShowDialog(this IView view)
    {
        Window window = view.ToWindow();
        return window.ShowDialog();
    }

    internal static Window ToWindow(this IView view)
    {
        return (Window)view;
    }

    #endregion

}
