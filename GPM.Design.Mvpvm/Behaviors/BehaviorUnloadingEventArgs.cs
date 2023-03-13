namespace GPM.Design.Mvpvm.Behaviors;

public class BehaviorUnloadingEventArgs : EventArgs
{

    #region constructors / deconstructors / destructors

    public BehaviorUnloadingEventArgs() : base()
    {

    }

    #endregion

    #region properties

    public required IPresenter Presenter { get; init; }

    #endregion

}
