namespace GPM.Product.Mvpvm.Management;

public class MvpvmServiceManager : MvpServiceManager, IMvpvmServiceManager
{

    #region constructors / deconstructors / destructors

    protected MvpvmServiceManager() : base()
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IMvpvmServiceManager>(this);
        services.AddSingleton<IMvpvmPresentationManager, MvpvmPresentationManager>();

        base.ConfigureServices(context, services);
    }

    public override void Run()
    {
        base.Run();
        ServiceProvider.GetRequiredService<IMvpvmPresentationManager>();
    }

    #endregion

}
