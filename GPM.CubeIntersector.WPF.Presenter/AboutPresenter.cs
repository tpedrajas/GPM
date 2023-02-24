namespace GPM.CubeIntersector.WPF.Presenter;

public class AboutPresenter : WPFPresenter<IAboutView, IAboutViewModel, IWPFServiceManager>, IAboutPresenter
{

    #region constructors / deconstructors / destructors

    static AboutPresenter()
    {
        
    }

    public AboutPresenter(IAboutView view, IAboutViewModel viewModel, IWPFServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        
    }

    #endregion

}
