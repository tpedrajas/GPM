namespace GPM.Product.Mvp.Management;

public interface IMvpPresentationManager<PT> where PT : IMvpPresenter
{

    #region methods

    public void LoadPresenter<LPT>(bool isDialog, bool isMain = false) where LPT : PT;

    public void UnloadPresenter(IMvpPresenter presenter);

    #endregion

}
