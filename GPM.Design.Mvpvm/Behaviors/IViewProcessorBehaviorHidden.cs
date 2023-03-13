namespace GPM.Design.Mvpvm.Behaviors;

internal interface IViewProcessorBehaviorHidden : IBehaviorHidden
{

    #region methods

    void CloseView(IPresenter presenter);

    void ShowView(IPresenter presenter, bool isDialog, bool isMain);

    #endregion

}
