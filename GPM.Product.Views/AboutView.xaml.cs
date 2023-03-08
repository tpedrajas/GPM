namespace GPM.Product.Views;

public interface IAboutView : IView
{

}

/// <summary>
/// Lógica de interacción para AboutView.xaml
/// </summary>
public sealed partial class AboutView : Window, IAboutView
{

    #region constructors / deconstructors / destructors

    public AboutView()
    {
        InitializeComponent();
    }

    #endregion

}
