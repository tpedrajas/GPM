namespace GPM.Design.Mvpvm.Management;

public interface IPresentator
{

    #region events

    event EventHandler Presentator_PresenterLoaded;

    event EventHandler Presentator_PresenterUnloaded;

    #endregion

    #region methods

    void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenter;

    void UnloadPresenter(IPresenter presenter);

    #endregion;

}

internal sealed class Presentator : IPresentator
{

    #region constructors / deconstructors / destructors

    public Presentator(IServiceProvider services)
    {
        Services = services;
    }

    #endregion

    #region events

    public event EventHandler Presentator_PresenterLoaded = delegate { };

    public event EventHandler Presentator_PresenterUnloaded = delegate { };

    #endregion

    #region properties

    private IServiceProvider Services { get; init; }

    #endregion

    #region methods

    public void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenter
    {
        IPresenter presenter = Services.GetRequiredService<PT>();

        presenter.InitializePresenter();
        Visualizator.ShowView(presenter.View, isDialog, isMain);

        Presentator_PresenterLoaded.Invoke(this, EventArgs.Empty);
    }

    public void UnloadPresenter(IPresenter presenter)
    {
        Presentator_PresenterUnloaded.Invoke(this, EventArgs.Empty);
    }

    #endregion

}
