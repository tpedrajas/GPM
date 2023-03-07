namespace GPM.Design.Mvpvm;

public interface IView
{

    #region events

    event EventHandler Activated;

    event CancelEventHandler Closing;

    event EventHandler Closed;

    event EventHandler Deactivated;

    event RoutedEventHandler Loaded;

    #endregion

    #region properties

    object DataContext { get; set; }

    #endregion

    #region methods

    void Show();

    bool? ShowDialog();

    #endregion

}
