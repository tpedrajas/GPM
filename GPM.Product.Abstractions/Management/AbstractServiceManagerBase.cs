namespace GPM.Product.Abstractions.Management;

public abstract class AbstractServiceManagerBase : IServiceManagerBase
{

    #region constructors / deconstructors / destructors

    protected AbstractServiceManagerBase()
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

    public IServiceProvider ServiceProvider { get; init; }

    #endregion

    #region methods

    protected abstract void ConfigureServices(HostBuilderContext context, IServiceCollection services);

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

    public virtual async void Run()
    {
        if (Hosting is not null)
        {
            await Hosting.StartAsync().ConfigureAwait(false);
        }
    }

    #endregion

}
