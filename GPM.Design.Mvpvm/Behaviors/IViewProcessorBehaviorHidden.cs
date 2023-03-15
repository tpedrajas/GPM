namespace GPM.Design.Mvpvm.Behaviors;

internal interface IViewProcessorBehaviorHidden : IBehaviorHidden
{

    #region methods

    void CloseView();

    void ShowView(bool isDialog, bool isMain);

    #endregion

}
