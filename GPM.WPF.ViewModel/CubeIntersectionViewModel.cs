namespace GPM.WPF.ViewModel;

public partial class CubeIntersectionViewModel : WPFViewModel, ICubeIntersectionViewModel
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionViewModel()
    {
        OnAboutDelegate = delegate { };
        OnCalculateIntersectionDelegate = delegate { };
        OnExistsIntersectionDelegate = delegate { };
    }

    #endregion

    #region delegates

    public event EventHandler OnAboutDelegate;

    public event EventHandler OnCalculateIntersectionDelegate;

    public event EventHandler OnExistsIntersectionDelegate;

    #endregion

    #region fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _DepthCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
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
    [NumberCulturedFormatted]
    private string? _HeightCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _HeightCube2;

    [ObservableProperty]
    private float? _HeightIntersection;

    private bool _IsCleaning;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _WidthCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _WidthCube2;

    [ObservableProperty]
    private float? _WidthIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _XPositionCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _XPositionCube2;

    [ObservableProperty]
    private float? _XPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _YPositionCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _YPositionCube2;

    [ObservableProperty]
    private float? _YPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _ZPositionCube1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted]
    private string? _ZPositionCube2;

    [ObservableProperty]
    private float? _ZPositionIntersection;

    #endregion

    #region methods

    private bool IsEnableCalculateIntersection()
    {
        bool canEnable = false;

        if (!_IsCleaning)
        {
            canEnable = true;

            canEnable &= float.TryParse(XPositionCube1, out _) && float.TryParse(YPositionCube1, out _) && float.TryParse(ZPositionCube1, out _);
            canEnable &= float.TryParse(WidthCube1, out _) && float.TryParse(HeightCube1, out _) && float.TryParse(DepthCube1, out _);
            canEnable &= float.TryParse(XPositionCube2, out _) && float.TryParse(YPositionCube2, out _) && float.TryParse(ZPositionCube2, out _);
            canEnable &= float.TryParse(WidthCube2, out _) && float.TryParse(HeightCube2, out _) && float.TryParse(DepthCube2, out _);

            EnableCalculateIntersection = canEnable;
        }

        return canEnable;
    }

    [RelayCommand]
    private void OnAboutButtonClick()
    {
        OnAboutDelegate.DynamicInvoke(this, new EventArgs());
    }

    [RelayCommand(CanExecute = nameof(IsEnableCalculateIntersection))]
    private void OnCalculateIntersectionButtonClick()
    {
        OnExistsIntersectionDelegate.DynamicInvoke(this, new EventArgs());
        OnCalculateIntersectionDelegate.DynamicInvoke(this, new EventArgs());
    }

    [RelayCommand]
    private void OnCleanDataButtonClick()
    {
        _IsCleaning = true;

        XPositionCube1 = null;
        XPositionCube2 = null;
        XPositionIntersection = null;

        YPositionCube1 = null;
        YPositionCube2 = null;
        YPositionIntersection = null;

        ZPositionCube1 = null;
        ZPositionCube2 = null;
        ZPositionIntersection = null;

        WidthCube1 = null;
        WidthCube2 = null;
        WidthIntersection = null;

        HeightCube1 = null;
        HeightCube2 = null;
        HeightIntersection = null;

        DepthCube1 = null;
        DepthCube2 = null;
        DepthIntersection = null;

        ExistsIntersection = false;
        EnableCalculateIntersection = false;

        _IsCleaning = false;
    }

    #endregion

}
