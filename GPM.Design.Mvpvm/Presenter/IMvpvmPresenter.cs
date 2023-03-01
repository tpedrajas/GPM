namespace GPM.Design.Mvpvm.Presenter;

public interface IMvpvmPresenter : IMvpPresenter
{

}

public interface IMvpvmPresenter<VT, VMT, SM> : IMvpvmPresenter, IMvpPresenter<VT, SM> where VT : IMvpvmView where VMT : IMvpvmViewModel where SM : IMvpvmServiceManager
{

    #region events

    public event EventHandler ViewModelLinked; 

    #endregion

}
