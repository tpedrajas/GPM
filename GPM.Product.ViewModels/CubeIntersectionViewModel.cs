namespace GPM.Product.ViewModels;

public interface ICubeIntersectionViewModel : IViewModel
{

    #region events

    event EventHandler AboutButton_Click;

    event CanExecuteEventHandlerResult CalculateIntersectionButton_CanExecuteValidating;

    event EventHandler CalculateIntersectionButton_Click;

    event EventHandler CleanDataButton_Click;

    event CanExecuteEventHandlerResult EnglishMenuItem_CanExecuteValidating;

    event EventHandler EnglishMenuItem_Click;

    event CanExecuteEventHandlerResult LoadInformationCube1Button_CanExecuteValidating;

    event EventHandler LoadInformationCube1Button_Click;

    event CanExecuteEventHandlerResult LoadInformationCube2Button_CanExecuteValidating;

    event EventHandler LoadInformationCube2Button_Click;

    event CanExecuteEventHandlerResult SaveInformationCube1Button_CanExecuteValidating;

    event EventHandler SaveInformationCube1Button_Click;

    event CanExecuteEventHandlerResult SaveInformationCube2Button_CanExecuteValidating;

    event EventHandler SaveInformationCube2Button_Click;

    event CanExecuteEventHandlerResult SpanishMenuItem_CanExecuteValidating;

    event EventHandler SpanishMenuItem_Click;

    #endregion

    #region properties

    string DepthCube1TextBox_Text { get; set; }

    string DepthCube2TextBox_Text { get; set; }

    float? DepthIntersectionTextBox_Text { get; set; }

    bool EnglishMenuItem_IsChecked { get; set; }

    bool ExistsIntersectionCheckBox_IsChecked { get; set; }

    string HeightCube1TextBox_Text { get; set; }

    string HeightCube2TextBox_Text { get; set; }

    float? HeightIntersectionTextBox_Text { get; set; }

    string IdCube1TextBox_Text { get; set; }

    string IdCube2TextBox_Text { get; set; }

    string SelectedLanguage { get; set; }

    bool SpanishMenuItem_IsChecked { get; set; }

    string WidthCube1TextBox_Text { get; set; }

    string WidthCube2TextBox_Text { get; set; }

    float? WidthIntersectionTextBox_Text { get; set; }

    string XPositionCube1TextBox_Text { get; set; }

    string XPositionCube2TextBox_Text { get; set; }

    float? XPositionIntersectionTextBox_Text { get; set; }

    string YPositionCube1TextBox_Text { get; set; }

    string YPositionCube2TextBox_Text { get; set; }

    float? YPositionIntersectionTextBox_Text { get; set; }

    string ZPositionCube1TextBox_Text { get; set; }

    string ZPositionCube2TextBox_Text { get; set; }

    float? ZPositionIntersectionTextBox_Text { get; set; }

    #endregion

}

public sealed partial class CubeIntersectionViewModel : ViewModel, ICubeIntersectionViewModel
{

    #region events

    public event EventHandler AboutButton_Click = delegate { };

    public event CanExecuteEventHandlerResult CalculateIntersectionButton_CanExecuteValidating = delegate { return true; };

    public event EventHandler CalculateIntersectionButton_Click = delegate { };

    public event EventHandler CleanDataButton_Click = delegate { };

    public event CanExecuteEventHandlerResult EnglishMenuItem_CanExecuteValidating = delegate { return true; };

    public event EventHandler EnglishMenuItem_Click = delegate { };

    public event CanExecuteEventHandlerResult LoadInformationCube1Button_CanExecuteValidating = delegate { return true; };

    public event EventHandler LoadInformationCube1Button_Click = delegate { };

    public event CanExecuteEventHandlerResult LoadInformationCube2Button_CanExecuteValidating = delegate { return true; };

    public event EventHandler LoadInformationCube2Button_Click = delegate { };

    public event CanExecuteEventHandlerResult SaveInformationCube1Button_CanExecuteValidating = delegate { return true; };

    public event EventHandler SaveInformationCube1Button_Click = delegate { };

    public event CanExecuteEventHandlerResult SaveInformationCube2Button_CanExecuteValidating = delegate { return true; };

    public event EventHandler SaveInformationCube2Button_Click = delegate { };

    public event CanExecuteEventHandlerResult SpanishMenuItem_CanExecuteValidating = delegate { return true; };

    public event EventHandler SpanishMenuItem_Click = delegate { };

    #endregion

    #region fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string? _DepthCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string? _DepthCube2TextBox_Text;

    [ObservableProperty]
    private float? _DepthIntersectionTextBox_Text;

    [ObservableProperty]
    private bool _EnglishMenuItem_IsChecked;

    [ObservableProperty]
    private bool _ExistsIntersectionCheckBox_IsChecked;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string? _HeightCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string? _HeightCube2TextBox_Text;

    [ObservableProperty]
    private float? _HeightIntersectionTextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    private string? _IdCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    private string? _IdCube2TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SpanishMenuItem_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(EnglishMenuItem_ClickCommand))]
    private string? _SelectedLanguage;

    [ObservableProperty]
    private bool _SpanishMenuItem_IsChecked;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string? _WidthCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [Range(0, float.MaxValue)]
    [NumberCulturedFormatted(2)]
    private string? _WidthCube2TextBox_Text;

    [ObservableProperty]
    private float? _WidthIntersectionTextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _XPositionCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _XPositionCube2TextBox_Text;

    [ObservableProperty]
    private float? _XPositionIntersectionTextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _YPositionCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _YPositionCube2TextBox_Text;

    [ObservableProperty]
    private float? _YPositionIntersectionTextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube1Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _ZPositionCube1TextBox_Text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveInformationCube2Button_ClickCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateIntersectionButton_ClickCommand))]
    [NotifyDataErrorInfo]
    [NumberCulturedFormatted(2)]
    private string? _ZPositionCube2TextBox_Text;

    [ObservableProperty]
    private float? _ZPositionIntersectionTextBox_Text;

    #endregion

    #region methods

    private bool OnCalculateIntersectionButton_CanExecuteValidating()
    {
        return CalculateIntersectionButton_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    private bool OnEnglishMenuItem_CanExecuteValidating()
    {
        return EnglishMenuItem_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    private bool OnLoadInformationCube1Button_CanExecuteValidating()
    {
        return LoadInformationCube1Button_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    private bool OnLoadInformationCube2Button_CanExecuteValidating()
    {
        return LoadInformationCube2Button_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    private bool OnSaveInformationCube1Button_CanExecuteValidating()
    {
        return SaveInformationCube1Button_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    private bool OnSaveInformationCube2Button_CanExecuteValidating()
    {
        return SaveInformationCube2Button_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    private bool OnSpanishMenuItem_CanExecuteValidating()
    {
        return SpanishMenuItem_CanExecuteValidating.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void OnAboutButton_Click()
    {
        AboutButton_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnCalculateIntersectionButton_CanExecuteValidating))]
    private void OnCalculateIntersectionButton_Click()
    {
        CalculateIntersectionButton_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void OnCleanDataButton_Click()
    {
        CleanDataButton_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnEnglishMenuItem_CanExecuteValidating))]
    private void OnEnglishMenuItem_Click()
    {
        EnglishMenuItem_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnLoadInformationCube1Button_CanExecuteValidating))]
    private void OnLoadInformationCube1Button_Click()
    {
        LoadInformationCube1Button_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnLoadInformationCube2Button_CanExecuteValidating))]
    private void OnLoadInformationCube2Button_Click()
    {
        LoadInformationCube2Button_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnSaveInformationCube1Button_CanExecuteValidating))]
    private void OnSaveInformationCube1Button_Click()
    {
        SaveInformationCube1Button_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnSaveInformationCube2Button_CanExecuteValidating))]
    private void OnSaveInformationCube2Button_Click()
    {
        SaveInformationCube2Button_Click.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand(CanExecute = nameof(OnSpanishMenuItem_CanExecuteValidating))]
    private void OnSpanishMenuItem_Click()
    {
        SpanishMenuItem_Click.Invoke(this, EventArgs.Empty);
    }

    #endregion

}
