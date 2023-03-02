namespace GPM.Design.Mvpvm;

public interface IViewModelBase
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
