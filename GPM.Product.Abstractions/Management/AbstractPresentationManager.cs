namespace GPM.Product.Abstractions.Management;

public abstract class AbstractPresentationManager<PT> : IPresentationManager<PT> where PT : IPresenter
{

    #region constructors / deconstructors / destructors

    public AbstractPresentationManager(IServiceManager serviceManager)
    {
        _ServiceManager = serviceManager;
    }

    #endregion

    #region fields

    private readonly IServiceManager _ServiceManager;

    #endregion

    #region methods

    public abstract void LoadPresenter<LPT>(bool isDialog, bool isMain = false) where LPT : PT;

    protected bool TryLoadPresenter<LPT>(out LPT? presenter) where LPT : PT
    {
        bool canLoad = true;
        
        presenter = _ServiceManager.ServiceProvider.GetRequiredService<LPT>();
        Type presenterType = presenter.GetType();

        if ((!_ServiceManager.PresenterCollectionInfo.TryGetValue(presenterType, out (int MaxInstances, int NumInstances) pair) && presenter.MaxInstances > 0) || pair.NumInstances < pair.MaxInstances)
        {
            if (pair.NumInstances is 0)
            {
                _ServiceManager.PresenterCollectionInfo.Add(presenterType, (presenter.MaxInstances, 1));
            }
            else
            {
                _ServiceManager.PresenterCollectionInfo[presenterType] = (presenter.MaxInstances, pair.NumInstances + 1);
            }
        }
        else
        {
            presenter = default;
            canLoad = false;
        }

        return canLoad;
    }

    public void UnloadPresenter(IPresenter presenter)
    {
        Type presenterType = presenter.GetType();

        if (_ServiceManager.PresenterCollectionInfo.TryGetValue(presenterType, out (int MaxInstances, int NumInstances) pair))
        {
            if (pair.NumInstances <= 1)
            {
                _ServiceManager.PresenterCollectionInfo.Remove(presenterType);
            }
            else
            {
                _ServiceManager.PresenterCollectionInfo[presenterType] = (pair.MaxInstances, pair.NumInstances - 1);
            }
        }
    }

    #endregion

}
