namespace GPM.Design.Mvpvm.Management;

public class ServiceManager : IServiceManager
{

    #region constructors / deconstructors / destructors

    protected ServiceManager()
    {
        Hosting = Host.CreateDefaultBuilder()
                      .ConfigureServices(ConfigureServices)
                      .Build();

        ServiceProvider = Hosting.Services;
    }

    #endregion

    #region fields

    protected bool _Disposed;

    #endregion

    #region properties

    public IHost? Hosting { get; private set; }

    public IServiceProvider ServiceProvider { get; }

    public Dictionary<string, string> Settings { get; } = new();

    #endregion

    #region methods

    protected virtual void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IServiceManager>(this);
        services.AddSingleton<IPresentationManager, PresentationManager>();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (!_Disposed)
        {
            if (Hosting is not null)
            {
                using (Hosting)
                {
                    await Hosting.StopAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                }

                Hosting = null;
            }

            _Disposed = true;
        }
    }

    public async ValueTask Run()
    {
        if (Hosting is not null)
        {
            await Hosting.StartAsync().ConfigureAwait(false);
        }

        ServiceProvider.GetRequiredService<IPresentationManager>();
    }

    #endregion

}
