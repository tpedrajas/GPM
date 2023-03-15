namespace GPM.Facade.Design.Mvpvm;

public interface IView
{

    #region events

    event EventHandler Activated;

    event CancelEventHandler Closing;

    event EventHandler Closed;

    event EventHandler Deactivated;

    event RoutedEventHandler Loaded;

    #endregion

}
