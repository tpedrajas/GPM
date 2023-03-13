namespace GPM.Design.Mvpvm;

internal static class PresenterExtensions
{

    #region extension methods

    internal static Dictionary<Type, IBehavior> GetBehaviors(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToTestPresenterHidden();
        return presenterHidden.GetBehaviors();
    }

    internal static IView GetView(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToTestPresenterHidden();
        return presenterHidden.GetView();
    }

    internal static IViewModel GetViewModel(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToTestPresenterHidden();
        return presenterHidden.GetViewModel();
    }

    internal static void Initialize(this IPresenter presenter, bool isDialog, bool isMain)
    {
        IPresenterHidden presenterHidden = presenter.ToTestPresenterHidden();
        presenterHidden.Initialize(isDialog, isMain);
    }

    private static IPresenterHidden ToTestPresenterHidden(this IPresenter presenter)
    {
        return (IPresenterHidden)presenter;
    }

    internal static void Unload(this IPresenter presenter)
    {
        IPresenterHidden presenterHidden = presenter.ToTestPresenterHidden();
        presenterHidden.Unload();
    }

    #endregion

}
