namespace GPM.Product.ViewModels;

public sealed partial class LoaderViewModel : ViewModel, ILoaderViewModel
{

    #region fields

    [ObservableProperty]
    private Visibility _LoadingLabel_Visibility;

    [ObservableProperty]
    private double _LoadingProgressBar_LargeChange;

    [ObservableProperty]
    private double _LoadingProgressBar_Maximum;

    [ObservableProperty]
    private double _LoadingProgressBar_Minimum;

    [ObservableProperty]
    private double _LoadingProgressBar_SmallChange;

    [ObservableProperty]
    private double _LoadingProgressBar_Value;

    [ObservableProperty]
    private double _Opacity;

    #endregion

}
