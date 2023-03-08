namespace GPM.CubeIntersector.Presenters;

public interface IAboutPresenter : IPresenter
{

}

public class AboutPresenter : Presenter<IAboutView, IAboutViewModel>, IAboutPresenter
{

    #region constructors / deconstructors / destructors

    public AboutPresenter(IServiceProvider services) : base(services)
    {
        
    }

    #endregion

}
