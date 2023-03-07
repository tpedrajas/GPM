namespace GPM.Product.ViewModels;

public interface ICubeIntersectionViewModel : IViewModel
{

    #region events

    event Action AboutButton_Click;

    event Func<bool> CalculateIntersectionButton_CanExecuteValidating;

    event Action CalculateIntersectionButton_Click;

    event Action CleanDataButton_Click;

    event Func<bool> EnglishMenuItem_CanExecuteValidating;

    event Action EnglishMenuItem_Click;

    event Func<bool> LoadInformationCube1Button_CanExecuteValidating;

    event Action LoadInformationCube1Button_Click;

    event Func<bool> LoadInformationCube2Button_CanExecuteValidating;

    event Action LoadInformationCube2Button_Click;

    event Func<bool> SaveInformationCube1Button_CanExecuteValidating;

    event Action SaveInformationCube1Button_Click;

    event Func<bool> SaveInformationCube2Button_CanExecuteValidating;

    event Action SaveInformationCube2Button_Click;

    event Func<bool> SpanishMenuItem_CanExecuteValidating;

    event Action SpanishMenuItem_Click;

    #endregion

    #region properties

    [MaxLength(10)]
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
