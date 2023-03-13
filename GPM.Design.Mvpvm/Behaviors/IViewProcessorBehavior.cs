namespace GPM.Design.Mvpvm.Behaviors;

public interface IViewProcessorBehavior : IBehavior
{

    #region constants

    const string VIEW_ACTIVATED_EVENT = nameof(View_Activated);

    const string VIEW_CLOSED_EVENT = nameof(View_Closed);

    const string VIEW_CLOSING_EVENT = nameof(View_Closing);

    const string VIEW_DEACTIVATED_EVENT = nameof(View_Deactivated);

    const string VIEW_LOADED_EVENT = nameof(View_Loaded);

    #endregion

    #region events

    event EventHandler View_Activated;

    event EventHandler View_Closed;

    event CancelEventHandler View_Closing;

    event EventHandler View_Deactivated;

    event RoutedEventHandler View_Loaded;

    #endregion

}
