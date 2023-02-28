namespace GPM.WPF.ViewModel;

public partial class CubeIntersectionViewModel : WPFViewModel, ICubeIntersectionViewModel
{

    #region delegates

    public event Action AboutButtonClick = () => { };

    public event Action CalculateIntersectionButtonClick = () => { };

    public event Action CleanDataButtonClick = () => { };

    public event Func<bool> EnableCalculateIntersectionButtonValidating = () => { return true; };

    public event Func<bool> EnableInformationCube1ButtonsValidating = () => { return true; };

    public event Func<bool> EnableInformationCube2ButtonsValidating = () => { return true; };

    public event Action ExistsIntersectionValidating = () => { };

    public event Action LoadInformationCube1Click = () => { };

    public event Action LoadInformationCube2Click = () => { };

    public event Action SaveInformationCube1Click = () => { };

    public event Action SaveInformationCube2Click = () => { };

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
    private bool _EnableCalculateIntersectionButton;

    [ObservableProperty]
    private bool _EnableInformationCube1Buttons;

    [ObservableProperty]
    private bool _EnableInformationCube2Buttons;

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
    [NumberCulturedFormatted(2)]
    private string _HeightCube2 = string.Empty;

    [ObservableProperty]
    private float? _HeightIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInformationCube1ClickCommand))]
    private string _IdCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInformationCube2ClickCommand))]
    private string _IdCube2 = string.Empty;

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

    private bool IsEnabledCalculateIntersectionButton()
    {
        return EnableCalculateIntersectionButtonValidating.Invoke();
    }

    private bool IsEnabledInformationCube1Buttons()
    {
        return EnableInformationCube1ButtonsValidating.Invoke();
    }

    private bool IsEnabledInformationCube2Buttons()
    {
        return EnableInformationCube2ButtonsValidating.Invoke();
    }

    [RelayCommand]
    private void OnAboutButtonClick()
    {
        AboutButtonClick.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledCalculateIntersectionButton))]
    private void OnCalculateIntersectionButtonClick()
    {
        ExistsIntersectionValidating.Invoke();
        CalculateIntersectionButtonClick.Invoke();
    }

    [RelayCommand]
    private void OnCleanDataButtonClick()
    {
        CleanDataButtonClick.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledInformationCube1Buttons))]
    private void OnLoadInformationCube1Click()
    {
        LoadInformationCube1Click.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledInformationCube2Buttons))]
    private void OnLoadInformationCube2Click()
    {
        LoadInformationCube2Click.Invoke();
    }

    [RelayCommand]
    private void OnSaveInformationCube1Click()
    {
        SaveInformationCube1Click.Invoke();
    }

    [RelayCommand]
    private void OnSaveInformationCube2Click()
    {
        SaveInformationCube2Click.Invoke();
    }

    #endregion

}
