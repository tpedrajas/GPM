namespace GPM.Design.Mvpvm.Management;

internal static class Visualizator
{

    #region methods

    internal static void InitializeView(IView view, bool isDialog, bool isMain)
    {
        if (isMain)
        {
            MakeMainView(view);
        }

        ShowView(view, isDialog);
    }

    private static void MakeMainView(IView view)
    {
        Application.Current.MainWindow = view.ToWindow();
    }

    private static void ShowView(IView view, bool isDialog)
    {
        if (isDialog)
        {
            view.ShowDialog();
        }
        else
        {
            view.Show();
        }
    }

    #endregion

}
