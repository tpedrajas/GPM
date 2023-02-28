namespace GPM.WPF.ViewModel;

public interface ICubeIntersectionViewModel : IWPFViewModel
{

    #region events

    public event Action AboutButtonClick;

    public event Action CalculateIntersectionButtonClick;

    public event Action CleanDataButtonClick;

    public event Func<bool> EnableCalculateIntersectionButtonValidating;

    public event Func<bool> EnableInformationCube1ButtonsValidating;

    public event Func<bool> EnableInformationCube2ButtonsValidating;

    public event Action ExistsIntersectionValidating;

    public event Action LoadInformationCube1Click;

    public event Action LoadInformationCube2Click;

    public event Action SaveInformationCube1Click;

    public event Action SaveInformationCube2Click;

    #endregion

    #region properties

    [MaxLength(10)]
    public string DepthCube1 { get; set; }

    public string DepthCube2 { get; set; }

    public float? DepthIntersection { get; set; }

    public bool EnableCalculateIntersectionButton { get; set; }

    public bool EnableInformationCube1Buttons { get; set; }

    public bool EnableInformationCube2Buttons { get; set; }

    public bool ExistsIntersection { get; set; }

    public string HeightCube1 { get; set; }

    public string HeightCube2 { get; set; }

    public float? HeightIntersection { get; set; }

    public string IdCube1 { get; set; }

    public string IdCube2 { get; set; }

    public string WidthCube1 { get; set; }

    public string WidthCube2 { get; set; }

    public float? WidthIntersection { get; set; }

    public string XPositionCube1 { get; set; }

    public string XPositionCube2 { get; set; }

    public float? XPositionIntersection { get; set; }

    public string YPositionCube1 { get; set; }

    public string YPositionCube2 { get; set; }

    public float? YPositionIntersection { get; set; }

    public string ZPositionCube1 { get; set; }

    public string ZPositionCube2 { get; set; }

    public float? ZPositionIntersection { get; set; }

    #endregion

    #region commands

    public IRelayCommand AboutButtonClickCommand { get; }

    public IRelayCommand CalculateIntersectionButtonClickCommand { get; }

    public IRelayCommand CleanDataButtonClickCommand { get; }

    public IRelayCommand LoadInformationCube1ClickCommand { get; }

    public IRelayCommand LoadInformationCube2ClickCommand { get; }

    public IRelayCommand SaveInformationCube1ClickCommand { get; }

    public IRelayCommand SaveInformationCube2ClickCommand { get; }

    #endregion

}
