using GPM.Design.Mvpvm.Extensions;

namespace GPM.Design.Mvpvm.Management;

public interface IPresentator
{

    #region events

    event EventHandler PresenterLoaded;

    event EventHandler PresenterUnloaded;

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

    public event EventHandler PresenterLoaded = delegate { };

    public event EventHandler PresenterUnloaded = delegate { };

    #endregion

    #region properties

    private IServiceProvider Services { get; init; }

    #endregion

    #region methods

    public void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenter
    {
        IPresenter presenter = Services.GetRequiredService<PT>();

        presenter.Initialize();
        Visualizator.ShowView(presenter.GetView(), isDialog, isMain);

        PresenterLoaded.Invoke(this, EventArgs.Empty);
    }

    public void UnloadPresenter(IPresenter presenter)
    {
        PresenterUnloaded.Invoke(this, EventArgs.Empty);
    }

    #endregion

}
