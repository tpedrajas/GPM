namespace GPM.Design.Mvpvm.Management;

internal static class Visualizator
{

    #region methods

    internal static void ShowView(IView view, bool isDialog, bool isMain)
    {
        ShowView(view, isDialog);

        if (isMain)
        {
            MakeMainView(view);
        }
    }

    private static void MakeMainView(IView view)
    {
        Application.Current.MainWindow = (Window)view;
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
