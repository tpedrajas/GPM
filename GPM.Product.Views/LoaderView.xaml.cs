namespace GPM.Product.Views;

public interface ILoaderView : IView
{

}

/// <summary>
/// Lógica de interacción para LoaderView.xaml
/// </summary>
public sealed partial class LoaderView : Window, ILoaderView
{

    #region constructors / deconstructors / destructors

    public LoaderView()
    {
        InitializeComponent();
    }

    #endregion

}
