namespace GPM.Design.Mvpvm;

public interface IViewModel
{

    #region events

    public event CancelEventHandler Validating;

    #endregion

    #region properties

    public bool HasErrors { get; }

    #endregion

    #region methods

    public IEnumerable<ValidationResult> GetErrors(string? propertyName = null);

    public void Validate();

    #endregion

}

public class ViewModel : ObservableValidator, IViewModel
{

    #region events

    public event CancelEventHandler Validating = (object? sender, CancelEventArgs e) => { };

    #endregion

    #region methods

    public void Validate()
    {
        CancelEventArgs cancelEvent = new();

        Validating.Invoke(this, cancelEvent);

        if (!cancelEvent.Cancel)
        {
            ValidateAllProperties();
        }
    }

    #endregion

}
