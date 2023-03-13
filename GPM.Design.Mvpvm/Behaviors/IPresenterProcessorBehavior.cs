namespace GPM.Design.Mvpvm.Behaviors;

public interface IPresenterProcessorBehavior : IBehavior
{

    #region methods

    void LoadPresenter<TPresenter>(bool isDialog, bool isMain = false) where TPresenter : IPresenter;

    void UnloadPresenter(IPresenter presenter);

    #endregion

}
