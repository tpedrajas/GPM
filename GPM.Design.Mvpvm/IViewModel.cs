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
