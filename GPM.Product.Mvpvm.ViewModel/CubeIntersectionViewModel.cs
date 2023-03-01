namespace GPM.Product.Mvpvm.ViewModel;

public partial class CubeIntersectionViewModel : MvpvmViewModel, ICubeIntersectionViewModel
{

    #region delegates

    public event Action AboutButtonClick = () => { };

    public event Action CalculateIntersectionButtonClick = () => { };

    public event Action CleanDataButtonClick = () => { };

    public event Func<bool> EnableCalculateIntersectionButtonValidating = () => { return true; };

    public event Func<bool> EnableLoadInformationCube1ButtonValidating = () => { return true; };

    public event Func<bool> EnableLoadInformationCube2ButtonValidating = () => { return true; };

    public event Func<bool> EnableSaveInformationCube1ButtonValidating = () => { return true; };

    public event Func<bool> EnableSaveInformationCube2ButtonValidating = () => { return true; };

    public event Action ExistsIntersectionValidating = () => { };

    public event Action LoadInformationCube1Click = () => { };

    public event Action LoadInformationCube2Click = () => { };

    public event Action SaveInformationCube1Click = () => { };

    public event Action SaveInformationCube2Click = () => { };

    #endregion

    #region fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _DepthCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _DepthCube2 = string.Empty;

    [ObservableProperty]
    private float? _DepthIntersection;

    [ObservableProperty]
    private bool _EnableCalculateIntersectionButton;

    [ObservableProperty]
    private bool _EnableLoadInformationCube1Button;

    [ObservableProperty]
    private bool _EnableLoadInformationCube2Button;

    [ObservableProperty]
    private bool _EnableSaveInformationCube1Button;

    [ObservableProperty]
    private bool _EnableSaveInformationCube2Button;

    [ObservableProperty]
    private bool _ExistsIntersection;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _HeightCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
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
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string _WidthCube1 = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButtonClickCommand))]
    [NotifyDataErrorInfo]
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

    #endregion

}
