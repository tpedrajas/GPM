namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class PresenterProcessorBehavior : Behavior, IPresenterProcessorBehavior
{

    #region constructors / deconstructors / destructors

    public PresenterProcessorBehavior(IServiceProvider services) : base()
    {
        Services = services;
    }

    #endregion

    #region properties

    private IServiceProvider Services { get; init; }

    #endregion

    #region methods

    public void LoadPresenter<TPresenter>(bool isDialog, bool isMain = false) where TPresenter : IPresenter
    {
        IPresenter presenter = Services.GetRequiredService<TPresenter>();
        presenter.Initialize(isDialog, isMain);
    }

    public void UnloadPresenter(IPresenter presenter)
    {
        presenter.Unload();
    }

    #endregion

}
