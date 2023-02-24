namespace GPM.Product.Abstractions.Management;

public interface IPresentationManager<PT> where PT : IPresenter
{

    #region methods

    public void LoadPresenter<LPT>(bool isDialog, bool isMain = false) where LPT : PT;

    public void UnloadPresenter(IPresenter presenter);

    #endregion

}
