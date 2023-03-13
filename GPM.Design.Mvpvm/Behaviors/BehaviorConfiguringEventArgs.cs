namespace GPM.Design.Mvpvm.Behaviors;

public class BehaviorConfiguringEventArgs : EventArgs
{

    #region constructors / deconstructors / destructors

    public BehaviorConfiguringEventArgs() : base()
    {

    }

    #endregion

    #region properties

    public required IPresenter Presenter { get; init; }

    #endregion

}
