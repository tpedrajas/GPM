namespace GPM.WPF.ViewModel;

public interface ICubeIntersectionViewModel : IWPFViewModel
{

    #region events

    public event Action AboutButtonClick;

    public event Action CalculateIntersectionButtonClick;

    public event Action<bool> CleanDataButtonClick;

    public event Func<bool> EnableCalculateIntersectionButtonValidating;

    public event Action ExistsIntersectionValidating;

    #endregion

    #region properties

    [MaxLength(10)]
    public string DepthCube1 { get; set; }

    public string DepthCube2 { get; set; }

    public float? DepthIntersection { get; set; }

    public bool EnableCalculateIntersection { get; set; }

    public bool ExistsIntersection { get; set; }

    public string HeightCube1 { get; set; }

    public string HeightCube2 { get; set; }

    public float? HeightIntersection { get; set; }

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

    #endregion

}
