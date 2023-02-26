namespace GPM.WPF.ViewModel;

public partial class CubeIntersectionViewModel : WPFViewModel, ICubeIntersectionViewModel
{

    #region delegates

    public event Action AboutButtonClick = () => { };

    public event Action CalculateIntersectionButtonClick = () => { };

    public event Action<bool> CleanDataButtonClick = (bool init) => { };

    public event Func<bool> EnableCalculateIntersectionButtonValidating = () => { return true; };

    public event Action ExistsIntersectionValidating = () => { };

    #endregion

    #region fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _DepthCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _DepthCube2 = string.Empty;

    [ObservableProperty]
    private float? _DepthIntersection;

    [ObservableProperty]
    private bool _EnableCalculateIntersection;

    [ObservableProperty]
    private bool _ExistsIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _HeightCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string _HeightCube2 = string.Empty;

    [ObservableProperty]
    private float? _HeightIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _WidthCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _WidthCube2 = string.Empty;

    [ObservableProperty]
    private float? _WidthIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _XPositionCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _XPositionCube2 = string.Empty;

    [ObservableProperty]
    private float? _XPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _YPositionCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _YPositionCube2 = string.Empty;

    [ObservableProperty]
    private float? _YPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _ZPositionCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _ZPositionCube2 = string.Empty;

    [ObservableProperty]
    private float? _ZPositionIntersection;

    #endregion

    #region methods

    private bool IsEnableCalculateIntersectionButton()
    {
        return EnableCalculateIntersectionButtonValidating.Invoke();
    }

    [RelayCommand]
    private void OnAboutButtonClick()
    {
        AboutButtonClick!.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnableCalculateIntersectionButton))]
    private void OnCalculateIntersectionButtonClick()
    {
        ExistsIntersectionValidating!.Invoke();
        CalculateIntersectionButtonClick.Invoke();
    }

    [RelayCommand]
    private void OnCleanDataButtonClick()
    {
        CleanDataButtonClick!.Invoke(false);
    }

    #endregion

}
