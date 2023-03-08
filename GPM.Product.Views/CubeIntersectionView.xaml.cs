namespace GPM.Product.Views;

public interface ICubeIntersectionView : IView
{

}

/// <summary>
/// Interaction logic for CubeIntersectionView.xaml
/// </summary>
public sealed partial class CubeIntersectionView : Window, ICubeIntersectionView
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionView()
    {
        InitializeComponent();
    }

    #endregion

}
