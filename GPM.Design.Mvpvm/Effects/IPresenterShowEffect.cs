namespace GPM.Design.Mvpvm.Effects;

public interface IPresenterShowEffect : IPresenter
{

    #region events

    event EventHandler ShowEffect_Completed;

    #endregion

}

internal interface IPresenterShowEffectHidden : IPresenterHidden
{

    #region methods

    void OnVisualShowEffect_Completed(object? sender, EventArgs e);

    #endregion

}
