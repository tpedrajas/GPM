namespace GPM.CubeIntersector.Desktop.Management;

internal class AppHostKeeper : HostKeeper
{

    #region constructors / deconstructors / destructors

    public AppHostKeeper(ShutdownMode shutdownMode) : base(shutdownMode)
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainProfile));

        services.AddSingleton<IConfigurator, AppConfigurator>();
        services.AddSingleton<IMainPresenter, AppMainPresenter>();

        services.AddSingleton<ILoaderViewModel, LoaderViewModel>();
        services.AddSingleton<ILoaderView, LoaderView>();
        services.AddSingleton<ILoaderPresenter, LoaderPresenter>();

        services.AddSingleton<ICubeIntersectionViewModel, CubeIntersectionViewModel>();
        services.AddSingleton<ICubeIntersectionView, CubeIntersectionView>();
        services.AddSingleton<ICubeIntersectionPresenter, CubeIntersectionPresenter>();

        services.AddTransient<IAboutViewModel, AboutViewModel>();
        services.AddTransient<IAboutView, AboutView>();
        services.AddTransient<IAboutPresenter, AboutPresenter>();
        
        base.ConfigureServices(services);
    }

    #endregion

}
