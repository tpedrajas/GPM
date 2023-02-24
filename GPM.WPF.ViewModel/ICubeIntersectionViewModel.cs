namespace GPM.WPF.ViewModel;

public interface ICubeIntersectionViewModel : IWPFViewModel
{

    #region events

    public event EventHandler OnAboutDelegate;

    public event EventHandler OnCalculateIntersectionDelegate;

    public event EventHandler OnExistsIntersectionDelegate;

    #endregion

    #region

    public float? DepthCube1 { get; set; }

    public float? DepthCube2 { get; set; }

    public float? DepthIntersection { get; set; }

    public bool EnableCalculateIntersection { get; set; }

    public bool ExistsIntersection { get; set; }

    public float? HeightCube1 { get; set; }

    public float? HeightCube2 { get; set; }

    public float? HeightIntersection { get; set; }

    public float? WidthCube1 { get; set; }

    public float? WidthCube2 { get; set; }

    public float? WidthIntersection { get; set; }

    public float? XPositionCube1 { get; set; }

    public float? XPositionCube2 { get; set; }

    public float? XPositionIntersection { get; set; }

    public float? YPositionCube1 { get; set; }

    public float? YPositionCube2 { get; set; }

    public float? YPositionIntersection { get; set; }

    public float? ZPositionCube1 { get; set; }

    public float? ZPositionCube2 { get; set; }

    public float? ZPositionIntersection { get; set; }

    #endregion

    #region commands

    public IRelayCommand AboutButtonClickCommand { get; }

    public IRelayCommand CalculateIntersectionButtonClickCommand { get; }

    public IRelayCommand CleanDataButtonClickCommand { get; }

    #endregion


}
