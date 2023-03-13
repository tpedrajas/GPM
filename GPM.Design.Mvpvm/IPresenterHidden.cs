namespace GPM.Design.Mvpvm;

internal interface IPresenterHidden
{

    #region methods

    Dictionary<Type, IBehavior> GetBehaviors();

    IView GetView();

    IViewModel GetViewModel();

    void Initialize(bool isDialog, bool isMain);

    void Unload();

    #endregion

}
