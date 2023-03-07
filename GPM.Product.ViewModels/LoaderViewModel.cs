namespace GPM.Product.ViewModels;

public sealed partial class LoaderViewModel : ViewModel, ILoaderViewModel
{

    #region fields

    [ObservableProperty]
    private double _LargeChangeProgressBarValue = 1;

    [ObservableProperty]
    private double _MaximumProgressBarValue = 100;

    [ObservableProperty]
    private double _MinimumProgressBarValue = 0;

    [ObservableProperty]
    private double _ProgressBarValue = 0;

    [ObservableProperty]
    private double _SmallChangeProgressBarValue = 0.1;

    #endregion

}
