namespace GPM.Facade.Design.Mvpvm;

public interface IPresenter
{

    #region events

    event EventHandler Initializing;

    event EventHandler View_Activated;

    event CancelEventHandler View_Closing;

    event EventHandler View_Closed;

    event EventHandler View_Deactivated;

    event RoutedEventHandler View_Loaded;

    event CancelEventHandler ViewModel_Validating;

    #endregion

}
