namespace GPM.Design.Mvpvm.Behaviors;

internal interface IBehaviorHidden
{

    #region methods

    void Configure(IPresenter presenter);

    void Unload(IPresenter presenter);

    #endregion

}
