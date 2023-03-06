namespace GPM.Design.Mvpvm.Management;

internal sealed class Presentator : IPresentator
{

    #region constructors / deconstructors / destructors

    public Presentator(IServiceProvider services)
    {
        Services = services;

        LoadPresenter<IMainPresenter>(false, true);
    }

    #endregion

    #region properties

    IServiceProvider Services { get; init; }

    #endregion

    #region methods

    public void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenter
    {
        IPresenter presenter = Services.GetRequiredService<PT>();

        Visualizator.InitializeView(presenter.GetView(), isDialog, isMain);
        presenter.Init();
    }

    #endregion

}
