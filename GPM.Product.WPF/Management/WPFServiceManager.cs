namespace GPM.Product.WPF.Management;

public class WPFServiceManager : ServiceManager, IWPFServiceManager
{

    #region constructors / deconstructors / destructors

    protected WPFServiceManager() : base()
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IWPFServiceManager>(this);
        services.AddSingleton<IWPFPresentationManager, WPFPresentationManager>();

        base.ConfigureServices(context, services);
    }

    public override void Run()
    {
        base.Run();
        ServiceProvider.GetRequiredService<IWPFPresentationManager>();
    }

    #endregion

}
