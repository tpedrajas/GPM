namespace GPM.Product.Mvp.Presenter;

public abstract class AbstractMvpPresenter<VT, SM> : IMvpPresenter<VT, SM> where VT : IMvpView where SM : IMvpServiceManager
{

    #region constructors / deconstructors / destructors

    protected AbstractMvpPresenter(VT view, SM serviceManager)
    {
        _ServiceManager = serviceManager;
        _View = view;

        MaxInstances = 1;

        view.Closed += OnViewClosed;
    }

    #endregion

    #region fields

    protected readonly SM _ServiceManager;

    protected readonly VT _View;

    #endregion

    #region properties

    public int MaxInstances { get; protected set; }

    #endregion

    #region methods

    public abstract void MakeMainView();

    protected virtual void OnViewClosed(object? sender, EventArgs args)
    {
        _View.Closed -= OnViewClosed;
    }

    public abstract void ShowView(bool isDialog);

    #endregion

}
