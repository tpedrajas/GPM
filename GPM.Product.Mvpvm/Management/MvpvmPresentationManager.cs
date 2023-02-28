namespace GPM.Product.Mvpvm.Management;

public sealed class MvpvmPresentationManager : AbstractMvpPresentationManager<IMvpvmPresenter>, IMvpvmPresentationManager
{

    #region constructors / deconstructors / destructors

    public MvpvmPresentationManager(IMvpvmServiceManager serviceManager) : base(serviceManager)
    {
        LoadPresenter<IMvpvmMainPresenter>(false, true);
    }

    #endregion

    #region methods

    private static void InitializePresenter(IMvpvmPresenter presenter, bool isDialog, bool isMain)
    {
        if (isMain)
        {
            presenter.MakeMainView();
        }

        presenter.ShowView(isDialog);
    }

    public override void LoadPresenter<PT>(bool isDialog, bool isMain = false)
    {
        TryLoadPresenter(out PT? presenter);
        ExceptionHelper.ThrowIfNull<InvalidOperationException>(presenter);

        InitializePresenter(presenter!, isDialog, isMain);
    }

    #endregion

}
