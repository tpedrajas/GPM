namespace GPM.Product.Mvp.View;

public interface IMvpView : IViewBase
{

    #region events

    public event EventHandler Closed;

    #endregion

    #region methods

    public void Show();

    #endregion

}
