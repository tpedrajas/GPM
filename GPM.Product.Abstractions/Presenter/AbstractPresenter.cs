namespace GPM.Product.Abstractions.Presenter;

public abstract class AbstractPresenter<VT, SM> : IPresenter<VT, SM> where VT : IView where SM : IServiceManager
{

    #region constructors / deconstructors / destructors

    protected AbstractPresenter(VT view, SM serviceManager)
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
