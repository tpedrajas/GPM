namespace GPM.Design.Mvpvm.Management;

internal sealed class Presentator : IPresentator
{

    #region constructors / deconstructors / destructors

    public Presentator(IServiceProvider services)
    {
        Services = services;
    }

    #endregion

    #region properties

    private IServiceProvider Services { get; init; }

    #endregion

    #region methods

    public void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenter
    {
        IPresenter presenter = Services.GetRequiredService<PT>();

        presenter.Init();
        Visualizator.ShowView(presenter.GetView(), isDialog, isMain);
    }

    public void UnloadPresenter(IPresenter presenter)
    {
        
    }

    #endregion

}
