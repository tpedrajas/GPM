namespace GPM.WPF.ViewModel;

public partial class CubeIntersectionViewModel : WPFViewModel, ICubeIntersectionViewModel
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionViewModel()
    {

    }

    #endregion

    #region delegates

    public event Func<bool>? IsEnableCalculateIntersectionDelegate;

    public event Action? OnAboutDelegate;

    public event Action? OnCalculateIntersectionDelegate;

    public event Action? OnCleanDataDelegate;

    public event Action? OnExistsIntersectionDelegate;

    #endregion

    #region fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _DepthCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _DepthCube2;

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
    private string? _HeightCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _HeightCube2;

    [ObservableProperty]
    private float? _HeightIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _WidthCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _WidthCube2;

    [ObservableProperty]
    private float? _WidthIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _XPositionCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _XPositionCube2;

    [ObservableProperty]
    private float? _XPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _YPositionCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _YPositionCube2;

    [ObservableProperty]
    private float? _YPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _ZPositionCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _ZPositionCube2;

    [ObservableProperty]
    private float? _ZPositionIntersection;

    #endregion

    #region methods

    private bool IsEnableCalculateIntersection()
    {
        return IsEnableCalculateIntersectionDelegate!.Invoke();
    }

    [RelayCommand]
    private void OnAboutButtonClick()
    {
        OnAboutDelegate!.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnableCalculateIntersection))]
    private void OnCalculateIntersectionButtonClick()
    {
        OnExistsIntersectionDelegate!.Invoke();
        OnCalculateIntersectionDelegate!.Invoke();
    }

    [RelayCommand]
    private void OnCleanDataButtonClick()
    {
        OnCleanDataDelegate!.Invoke();
    }

    #endregion

}
