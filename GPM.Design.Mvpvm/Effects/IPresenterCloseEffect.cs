namespace GPM.Design.Mvpvm.Effects;

public interface IPresenterCloseEffect : IPresenter
{

    #region events

    event EventHandler CloseEffect_Completed;

    #endregion

}

internal interface IPresenterCloseEffectHidden : IPresenterHidden
{

    #region methods

    void OnVisualCloseEffect_Completed(object? sender, EventArgs e);

    #endregion

}
