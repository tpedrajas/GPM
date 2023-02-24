namespace GPM.CubeIntersector.WPF.Presenter;

internal sealed class AppMainPresenter : CubeIntersectionPresenter, IWPFMainPresenter
{

    #region constructors / deconstructors / destructors

    public AppMainPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IWPFServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {

    }

    #endregion

}
