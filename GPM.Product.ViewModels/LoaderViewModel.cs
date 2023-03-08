namespace GPM.Product.ViewModels;

public interface ILoaderViewModel : IViewModelOpacityEffect
{

    #region properties

    Visibility LoadingLabel_Visibility { get; set; }

    double LoadingProgressBar_LargeChange { get; set; }

    double LoadingProgressBar_Maximum { get; set; }

    double LoadingProgressBar_Minimum { get; set; }

    double LoadingProgressBar_SmallChange { get; set; }

    double LoadingProgressBar_Value { get; set; }

    #endregion

}

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
