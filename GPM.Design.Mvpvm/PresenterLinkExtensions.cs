namespace GPM.Design.Mvpvm;

internal static class PresenterLinkExtensions
{

    #region methods

    internal static void LinkDataContext(this IPresenter presenter)
    {
        Window window = presenter.View.ToWindow();
        window.DataContext = presenter.ViewModel;
    }

    #endregion

}
