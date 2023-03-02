namespace GPM.CubeIntersector.Presenter;

public class AboutPresenter : PresenterBase<IAboutView, IAboutViewModel, IServiceManager>, IAboutPresenter
{

    #region constructors / deconstructors / destructors

    public AboutPresenter(IAboutView view, IAboutViewModel viewModel, IServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        
    }

    #endregion

}
