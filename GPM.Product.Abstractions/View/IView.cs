namespace GPM.Product.Abstractions.View;

public interface IView
{

    #region events

    public event EventHandler Closed;

    #endregion

    #region methods

    public void Show();

    #endregion

}
