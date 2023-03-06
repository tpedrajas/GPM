namespace GPM.Design.Mvpvm.Management;

public interface IPresentator
{

    #region methods

    void LoadPresenter<PT>(bool isDialog, bool isMain = false) where PT : IPresenter;

    #endregion;

}
