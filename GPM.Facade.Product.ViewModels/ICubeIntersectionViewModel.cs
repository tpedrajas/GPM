namespace GPM.Facade.Product.ViewModels;

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
