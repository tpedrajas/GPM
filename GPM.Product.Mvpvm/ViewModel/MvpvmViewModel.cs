namespace GPM.Product.Mvpvm.ViewModel;

public class MvpvmViewModel : ObservableValidator, IMvpvmViewModel
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
