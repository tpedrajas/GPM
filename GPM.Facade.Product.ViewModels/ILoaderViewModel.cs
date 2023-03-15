namespace GPM.Facade.Product.ViewModels;

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
