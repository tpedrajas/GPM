namespace GPM.Design.Mvpvm;

public class ViewModel : ObservableValidator, IViewModel
{

    #region events

    public event CancelEventHandler Validating = delegate { };

    #endregion

    #region methods

    public void Validate()
    {
        CancelEventArgs cancelEventArgs = new();

        Validating.Invoke(this, cancelEventArgs);

        if (!cancelEventArgs.Cancel)
        {
            ValidateAllProperties();
        }
    }

    #endregion

}
