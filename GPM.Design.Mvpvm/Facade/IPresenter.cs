namespace GPM.Design.Mvpvm;

public interface IPresenter
{

    #region events

    event EventHandler Initialized;

    #endregion

    #region methods

    IView GetView();

    IViewModel GetViewModel();

    void Init();

    #endregion

}

public interface IPresenter<V, VM> : IPresenter where V : IView where VM : IViewModel
{

}
