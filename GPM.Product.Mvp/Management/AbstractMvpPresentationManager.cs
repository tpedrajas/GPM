namespace GPM.Product.Mvp.Management;

public abstract class AbstractMvpPresentationManager<PT> : IMvpPresentationManager<PT> where PT : IMvpPresenter
{

    #region constructors / deconstructors / destructors

    public AbstractMvpPresentationManager(IMvpServiceManager serviceManager)
    {
        _ServiceManager = serviceManager;
    }

    #endregion

    #region fields

    private readonly Dictionary<Type, (int MaxInstances, int NumInstances)> _PresenterCollectionInfo = new();

    private readonly IMvpServiceManager _ServiceManager;

    #endregion

    #region methods

    #region fields

    

    #endregion

    public abstract void LoadPresenter<LPT>(bool isDialog, bool isMain = false) where LPT : PT;

    protected bool TryLoadPresenter<LPT>(out LPT? presenter) where LPT : PT
    {
        bool canLoad = true;
        
        presenter = _ServiceManager.ServiceProvider.GetRequiredService<LPT>();
        Type presenterType = presenter.GetType();

        if ((!_PresenterCollectionInfo.TryGetValue(presenterType, out (int MaxInstances, int NumInstances) pair) && presenter.MaxInstances > 0) || pair.NumInstances < pair.MaxInstances)
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

    public void UnloadPresenter(IMvpPresenter presenter)
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
