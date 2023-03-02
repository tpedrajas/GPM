namespace GPM.Product.ViewModel;

public interface ICubeIntersectionViewModel : IViewModelBase
{

    #region events

    public event Action AboutButtonClick;

    public event Action CalculateIntersectionButtonClick;

    public event Action CleanDataButtonClick;

    public event Func<bool> EnableCalculateIntersectionButtonValidating;

    public event Func<bool> EnableEnglishMenuValidating;

    public event Func<bool> EnableLoadInformationCube1ButtonValidating;

    public event Func<bool> EnableLoadInformationCube2ButtonValidating;

    public event Func<bool> EnableSaveInformationCube1ButtonValidating;

    public event Func<bool> EnableSaveInformationCube2ButtonValidating;

    public event Func<bool> EnableSpanishMenuValidating;

    public event Action EnglishMenuClick;

    public event Action ExistsIntersectionValidating;

    public event Action LoadInformationCube1Click;

    public event Action LoadInformationCube2Click;

    public event Action SaveInformationCube1Click;

    public event Action SaveInformationCube2Click;

    public event Action SpanishMenuClick;

    #endregion

    #region properties

    [MaxLength(10)]
    public string DepthCube1 { get; set; }

    public string DepthCube2 { get; set; }

    public float? DepthIntersection { get; set; }

    public bool EnglishMenuChecked { get; set; }

    public bool ExistsIntersectionChecked { get; set; }

    public string HeightCube1 { get; set; }

    public string HeightCube2 { get; set; }

    public float? HeightIntersection { get; set; }

    public string IdCube1 { get; set; }

    public string IdCube2 { get; set; }

    public string SelectedLanguage { get; set; }

    public bool SpanishMenuChecked { get; set; }

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

}
