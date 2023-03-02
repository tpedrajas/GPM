namespace GPM.Design.Mvpvm;

public interface IPresenterBase
{

    #region properties

    public int MaxInstances { get; }

    #endregion

    #region methods

    public void MakeMainView();

    public void ShowView(bool isDialog);

    #endregion

}

public interface IMvpvmPresenter<VT, VMT, SM> : IPresenterBase where VT : IViewBase where VMT : IViewModelBase where SM : IServiceManager
{

    #region events

    public event EventHandler ViewModelLinked;

    #endregion

}
