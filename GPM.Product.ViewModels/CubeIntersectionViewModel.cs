namespace GPM.Product.ViewModels;

public sealed partial class CubeIntersectionViewModel : ViewModel, ICubeIntersectionViewModel
{

    #region events

    public event Action AboutButtonClick = delegate { };

    public event Action CalculateIntersectionButtonClick = delegate { };

    public event Action CleanDataButtonClick = delegate { };

    public event Func<bool> EnableCalculateIntersectionButtonValidating = delegate { return true; };

    public event Func<bool> EnableEnglishMenuValidating = delegate { return true; };

    public event Func<bool> EnableLoadInformationCube1ButtonValidating = delegate { return true; };

    public event Func<bool> EnableLoadInformationCube2ButtonValidating = delegate { return true; };

    public event Func<bool> EnableSaveInformationCube1ButtonValidating = delegate { return true; };

    public event Func<bool> EnableSaveInformationCube2ButtonValidating = delegate { return true; };

    public event Func<bool> EnableSpanishMenuValidating = delegate { return true; };

    public event Action EnglishMenuClick = delegate { };

    public event Action ExistsIntersectionValidating = delegate { };

    public event Action LoadInformationCube1Click = delegate { };

    public event Action LoadInformationCube2Click = delegate { };

    public event Action SaveInformationCube1Click = delegate { };

    public event Action SaveInformationCube2Click = delegate { };

    public event Action SpanishMenuClick = delegate { };

    #endregion

    #region fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string _DepthCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string _DepthCube2 = string.Empty;

    [ObservableProperty]
    private float? _DepthIntersection;

    [ObservableProperty]
    private bool _EnglishMenuChecked;

    [ObservableProperty]
    private bool _ExistsIntersectionChecked;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string _HeightCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string _HeightCube2 = string.Empty;

    [ObservableProperty]
    private float? _HeightIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    private string _IdCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    private string _IdCube2 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SpanishMenuClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(EnglishMenuClickCommand))]
    private string _SelectedLanguage = string.Empty;

    [ObservableProperty]
    private bool _SpanishMenuChecked;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string _WidthCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string _WidthCube2 = string.Empty;

    [ObservableProperty]
    private float? _WidthIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _XPositionCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _XPositionCube2 = string.Empty;

    [ObservableProperty]
    private float? _XPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _YPositionCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _YPositionCube2 = string.Empty;

    [ObservableProperty]
    private float? _YPositionIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _ZPositionCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
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

    private bool IsEnabledEnglishMenu()
    {
        return EnableEnglishMenuValidating.Invoke();
    }

    private bool IsEnabledLoadInformationCube1Button()
    {
        return EnableLoadInformationCube1ButtonValidating.Invoke();
    }

    private bool IsEnabledLoadInformationCube2Button()
    {
        return EnableLoadInformationCube2ButtonValidating.Invoke();
    }

    private bool IsEnabledSaveInformationCube1Button()
    {
        return EnableSaveInformationCube1ButtonValidating.Invoke();
    }

    private bool IsEnabledSaveInformationCube2Button()
    {
        return EnableSaveInformationCube2ButtonValidating.Invoke();
    }

    private bool IsEnabledSpanishMenu()
    {
        return EnableSpanishMenuValidating.Invoke();
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

    [RelayCommand(CanExecute = nameof(IsEnabledEnglishMenu))]
    private void OnEnglishMenuClick()
    {
        EnglishMenuClick.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledLoadInformationCube1Button))]
    private void OnLoadInformationCube1Click()
    {
        LoadInformationCube1Click.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledLoadInformationCube2Button))]
    private void OnLoadInformationCube2Click()
    {
        LoadInformationCube2Click.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledSaveInformationCube1Button))]
    private void OnSaveInformationCube1Click()
    {
        SaveInformationCube1Click.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledSaveInformationCube2Button))]
    private void OnSaveInformationCube2Click()
    {
        SaveInformationCube2Click.Invoke();
    }

    [RelayCommand(CanExecute = nameof(IsEnabledSpanishMenu))]
    private void OnSpanishMenuClick()
    {
        SpanishMenuClick.Invoke();
    }

    #endregion

}
