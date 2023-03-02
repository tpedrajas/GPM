namespace GPM.CubeIntersector.Desktop;

internal sealed class AppMainPresenter : CubeIntersectionPresenter, IMainPresenter
{

    #region constructors / deconstructors / destructors

    public AppMainPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {

    }

    #endregion

}
