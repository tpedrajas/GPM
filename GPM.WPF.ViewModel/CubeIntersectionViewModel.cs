namespace GPM.WPF.ViewModel;

public partial class CubeIntersectionViewModel : WPFViewModel, ICubeIntersectionViewModel
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionViewModel()
    {
        OnAboutDelegate = delegate { };
        OnCalculateIntersectionDelegate = delegate { };
        OnExistsIntersectionDelegate = delegate { };

        EnableCalculateIntersection = true;
    }

    #endregion

    #region delegates

    public event EventHandler OnAboutDelegate;

    public event EventHandler OnCalculateIntersectionDelegate;

    public event EventHandler OnExistsIntersectionDelegate;

    #endregion

    #region fields

    [ObservableProperty]
    private float? _DepthCube1;

    [ObservableProperty]
    private float? _DepthCube2;

    [ObservableProperty]
    private float? _DepthIntersection;

    [ObservableProperty]
    private bool _EnableCalculateIntersection;

    [ObservableProperty]
    private bool _ExistsIntersection;

    [ObservableProperty]
    private float? _HeightCube1;

    [ObservableProperty]
    private float? _HeightCube2;

    [ObservableProperty]
    private float? _HeightIntersection;

    [ObservableProperty]
    private float? _WidthCube1;

    [ObservableProperty]
    private float? _WidthCube2;

    [ObservableProperty]
    private float? _WidthIntersection;

    [ObservableProperty]
    private float? _XPositionCube1;

    [ObservableProperty]
    private float? _XPositionCube2;

    [ObservableProperty]
    private float? _XPositionIntersection;

    [ObservableProperty]
    private float? _YPositionCube1;

    [ObservableProperty]
    private float? _YPositionCube2;

    [ObservableProperty]
    private float? _YPositionIntersection;

    [ObservableProperty]
    private float? _ZPositionCube1;

    [ObservableProperty]
    private float? _ZPositionCube2;

    [ObservableProperty]
    private float? _ZPositionIntersection;

    #endregion

    #region methods

    [RelayCommand]
    private void OnAboutButtonClick()
    {
        OnAboutDelegate.DynamicInvoke(this, new EventArgs());
    }

    [RelayCommand]
    private void OnCalculateIntersectionButtonClick()
    {
        OnExistsIntersectionDelegate.DynamicInvoke(this, new EventArgs());
        OnCalculateIntersectionDelegate.DynamicInvoke(this, new EventArgs());
    }

    [RelayCommand]
    private void OnCleanDataButtonClick()
    {
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
    }

    #endregion

}
