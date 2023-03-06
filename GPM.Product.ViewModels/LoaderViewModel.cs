namespace GPM.Product.ViewModels;

public sealed partial class LoaderViewModel : ViewModel, ILoaderViewModel
{

    #region fields

    [ObservableProperty]
    private double _LargeChangeProgressBarValue;

    [ObservableProperty]
    private double _MaximumProgressBarValue;

    [ObservableProperty]
    private double _MinimumProgressBarValue;

    [ObservableProperty]
    private double _ProgressBarValue;

    [ObservableProperty]
    private double _SmallChangeProgressBarValue;

    #endregion

}
