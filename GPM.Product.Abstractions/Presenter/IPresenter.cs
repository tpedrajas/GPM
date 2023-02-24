namespace GPM.Product.Abstractions.Presenter;

public interface IPresenter
{

    #region properties

    public int MaxInstances { get; }

    #endregion

    #region methods

    public void MakeMainView();

    public void ShowView(bool isDialog);

    #endregion

}

public interface IPresenter<VT, SM> : IPresenter where VT : IView where SM : IServiceManager
{

}
