namespace GPM.Product.ViewModels;

public interface ICubeIntersectionViewModel : IViewModel
{

    #region events

    event Action AboutButtonClick;

    event Action CalculateIntersectionButtonClick;

    event Action CleanDataButtonClick;

    event Func<bool> EnableCalculateIntersectionButtonValidating;

    event Func<bool> EnableEnglishMenuValidating;

    event Func<bool> EnableLoadInformationCube1ButtonValidating;

    event Func<bool> EnableLoadInformationCube2ButtonValidating;

    event Func<bool> EnableSaveInformationCube1ButtonValidating;

    event Func<bool> EnableSaveInformationCube2ButtonValidating;

    event Func<bool> EnableSpanishMenuValidating;

    event Action EnglishMenuClick;

    event Action ExistsIntersectionValidating;

    event Action LoadInformationCube1Click;

    event Action LoadInformationCube2Click;

    event Action SaveInformationCube1Click;

    event Action SaveInformationCube2Click;

    event Action SpanishMenuClick;

    #endregion

    #region properties

    [MaxLength(10)]
    string DepthCube1 { get; set; }

    string DepthCube2 { get; set; }

    float? DepthIntersection { get; set; }

    bool EnglishMenuChecked { get; set; }

    bool ExistsIntersectionChecked { get; set; }

    string HeightCube1 { get; set; }

    string HeightCube2 { get; set; }

    float? HeightIntersection { get; set; }

    string IdCube1 { get; set; }

    string IdCube2 { get; set; }

    string SelectedLanguage { get; set; }

    bool SpanishMenuChecked { get; set; }

    string WidthCube1 { get; set; }

    string WidthCube2 { get; set; }

    float? WidthIntersection { get; set; }

    string XPositionCube1 { get; set; }

    string XPositionCube2 { get; set; }

    float? XPositionIntersection { get; set; }

    string YPositionCube1 { get; set; }

    string YPositionCube2 { get; set; }

    float? YPositionIntersection { get; set; }

    string ZPositionCube1 { get; set; }

    string ZPositionCube2 { get; set; }

    float? ZPositionIntersection { get; set; }

    #endregion

}
