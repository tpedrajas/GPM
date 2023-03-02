namespace GPM.CubeIntersector.Desktop;

internal class AppServiceManager : ServiceManager
{

    #region constructors / deconstructors / destructors

    public AppServiceManager() : base()
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainProfile));

        services.AddSingleton<ICubeIntersectionViewModel, CubeIntersectionViewModel>();
        services.AddSingleton<ICubeIntersectionView, CubeIntersectionView>();
        services.AddSingleton<IMainPresenter, AppMainPresenter>();

        services.AddTransient<IAboutViewModel, AboutViewModel>();
        services.AddTransient<IAboutView, AboutView>();
        services.AddTransient<IAboutPresenter, AboutPresenter>();

        base.ConfigureServices(context, services);
    }

    #endregion

}
