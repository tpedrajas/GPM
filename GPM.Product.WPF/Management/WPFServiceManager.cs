namespace GPM.Product.WPF.Management;

public class WPFServiceManager : AbstractServiceManager, IWPFServiceManager
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
    }

    public override void Run()
    {
        base.Run();
        ServiceProvider.GetRequiredService<IWPFPresentationManager>();
    }

    #endregion

}
