namespace GPM.Design.Mvpvm;

public interface IViewModel
{

    #region events

    event CancelEventHandler Validating;

    #endregion

    #region properties

    bool HasErrors { get; }

    #endregion

    #region methods

    IEnumerable<ValidationResult> GetErrors(string? propertyName = null);

    void Validate();

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
        CancelEventArgs cancelEventArgs = new();

        Validating.Invoke(this, cancelEventArgs);

        if (!cancelEventArgs.Cancel)
        {
            ValidateAllProperties();
        }
    }

    #endregion

}
