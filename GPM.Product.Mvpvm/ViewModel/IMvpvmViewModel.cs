namespace GPM.Product.Mvpvm.ViewModel;

public interface IMvpvmViewModel
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
