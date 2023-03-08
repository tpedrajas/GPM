namespace GPM.Design.Mvpvm.Effects;

public interface IPresenterShowEffect : IPresenter
{

    #region events

    event EventHandler ShowEffect_Finalized;

    #endregion

    #region methods

    void OnShowEffect_Finalized(object? sender, EventArgs e);

    #endregion

}
