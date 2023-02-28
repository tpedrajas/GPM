namespace GPM.CubeIntersector.WPF.Presenter;

public class AboutPresenter : MvpvmPresenter<IAboutView, IAboutViewModel, IMvpvmServiceManager>, IAboutPresenter
{

    #region constructors / deconstructors / destructors

    public AboutPresenter(IAboutView view, IAboutViewModel viewModel, IMvpvmServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        
    }

    #endregion

}
