namespace GPM.Product.WPF.Management;

public sealed class WPFPresentationManager : AbstractPresentationManager<IWPFPresenter>, IWPFPresentationManager
{

    #region constructors / deconstructors / destructors

    public WPFPresentationManager(IWPFServiceManager serviceManager) : base(serviceManager)
    {
        LoadPresenter<IWPFMainPresenter>(false, true);
    }

    #endregion

    #region methods

    private static void InitializePresenter(IWPFPresenter presenter, bool isDialog, bool isMain)
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
        ExceptionManager.ThrowIfNull<InvalidOperationException>(presenter, "Test");

        InitializePresenter(presenter!, isDialog, isMain);
    }

    #endregion

}
