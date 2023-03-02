namespace GPM.Design.Mvpvm.Management;

public sealed class PresentationManager : IPresentationManager
{

    #region constructors / deconstructors / destructors

    public PresentationManager(IServiceManager serviceManager)
    {
        _ServiceManager = serviceManager;

        LoadPresenter<IMainPresenter>(false, true);
    }

    #endregion

    #region fields

    private readonly Dictionary<Type, (int MaxInstances, int NumInstances)> _PresenterCollectionInfo = new();

    private readonly IServiceManager _ServiceManager;

    #endregion

    #region methods

    private static void InitializePresenter(IPresenterBase presenter, bool isDialog, bool isMain)
    {
        if (isMain)
        {
            presenter.MakeMainView();
        }

        presenter.ShowView(isDialog);
    }

    public void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenterBase
    {
        TryLoadPresenter(out PT? presenter);
        ExceptionHelper.ThrowIfNull<InvalidOperationException>(presenter);

        InitializePresenter(presenter!, isDialog, isMain);
    }

    private bool TryLoadPresenter<PT>(out PT? presenter) where PT : IPresenterBase
    {
        bool canLoad = true;

        presenter = _ServiceManager.ServiceProvider.GetRequiredService<PT>();
        Type presenterType = presenter.GetType();

        if (!_PresenterCollectionInfo.TryGetValue(presenterType, out (int MaxInstances, int NumInstances) pair) && presenter.MaxInstances > 0 || pair.NumInstances < pair.MaxInstances)
        {
            if (pair.NumInstances is 0)
            {
                _PresenterCollectionInfo.Add(presenterType, (presenter.MaxInstances, 1));
            }
            else
            {
                _PresenterCollectionInfo[presenterType] = (presenter.MaxInstances, pair.NumInstances + 1);
            }
        }
        else
        {
            presenter = default;
            canLoad = false;
        }

        return canLoad;
    }

    public void UnloadPresenter(IPresenterBase presenter)
    {
        Type presenterType = presenter.GetType();

        if (_PresenterCollectionInfo.TryGetValue(presenterType, out (int MaxInstances, int NumInstances) pair))
        {
            if (pair.NumInstances <= 1)
            {
                _PresenterCollectionInfo.Remove(presenterType);
            }
            else
            {
                _PresenterCollectionInfo[presenterType] = (pair.MaxInstances, pair.NumInstances - 1);
            }
        }
    }

    #endregion

}
