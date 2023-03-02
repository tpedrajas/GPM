namespace GPM.Design.Mvpvm.Management;

public interface IPresentationManager
{

    #region methods

    public void LoadPresenter<LPT>(bool isDialog, bool isMain = false) where LPT : IPresenterBase;

    public void UnloadPresenter(IPresenterBase presenter);

    #endregion

}
