namespace GPM.Product.ViewModels;

public interface ILoaderViewModel : IViewModel
{

    #region properties

    double LargeChangeProgressBarValue { get; set; }

    double MaximumProgressBarValue { get; set; }

    double MinimumProgressBarValue { get; set; }

    double ProgressBarValue { get; set; }

    double SmallChangeProgressBarValue { get; set; }

    #endregion

}
