namespace GPM.Design.Mvpvm.Extensions;

internal static class PresenterExtensions
{

    #region methods

    internal static IView GetView(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToPresenterHidden();
        return presenterHidden.View;
    }

    internal static IViewModel GetViewModel(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToPresenterHidden();
        return presenterHidden.ViewModel;
    }

    internal static void Initialize(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToPresenterHidden();
        presenterHidden.Initialize();
    }

    internal static void LinkDataContext(this IPresenter presenter)
    {
        Window window = presenter.GetView().ToWindow();
        window.DataContext = presenter.GetViewModel();
    }

    internal static IPresenterHidden ToPresenterHidden(this IPresenter presenter)
    {
        return (IPresenterHidden)presenter;
    }

    #endregion

}
