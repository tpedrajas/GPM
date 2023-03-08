namespace GPM.Design.Mvpvm.Effects;

public interface IPresenterCloseEffect : IPresenter
{

    #region events

    event EventHandler CloseEffect_Finalized;

    #endregion

    #region methods

    void OnCloseEffect_Finalized(object? sender, EventArgs e);

    #endregion

}
