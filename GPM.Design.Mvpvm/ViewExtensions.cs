namespace GPM.Design.Mvpvm;

internal static class ViewExtensions
{

    #region methods

    internal static void Close(this IView view)
    {
        Window window = view.ToWindow();
        window.Close();
    }

    internal static void MakeMainView(this IView view)
    {
        Window window = view.ToWindow();
        Application.Current.MainWindow = window;
    }

    internal static void SetDataContext(this IView view, IViewModel viewModel)
    {
        Window window = view.ToWindow();
        window.DataContext = viewModel;
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

    private static Window ToWindow(this IView view)
    {
        return (Window)view;
    }

    #endregion

}
