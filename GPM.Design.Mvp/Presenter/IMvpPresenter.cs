namespace GPM.Design.Mvp.Presenter;

public interface IMvpPresenter
{

    #region properties

    public int MaxInstances { get; }

    #endregion

    #region methods

    public void MakeMainView();

    public void ShowView(bool isDialog);

    #endregion

}

public interface IMvpPresenter<VT, SM> : IMvpPresenter where VT : IMvpView where SM : IMvpServiceManager
{

}
