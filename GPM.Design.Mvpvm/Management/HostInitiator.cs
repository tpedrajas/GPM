namespace GPM.Design.Mvpvm.Management;

public class HostInitiator : IHostInitiator
{

    #region constructors / deconstructors / destructors

    protected HostInitiator()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        ConfigureServices(builder.Services);
        Hosting = builder.Build();

        Services = Hosting.Services;
        Settings = Services.GetRequiredService<ISettingsLoader>();
    }

    #endregion

    #region properties

    protected bool Disposed { get; private set; }

    private IHost Hosting { get; init; }

    protected bool IsRunning { get; private set; }

    public IServiceProvider Services { get; init; }

    public ISettingsLoader Settings { get; init; }

    #endregion

    #region methods

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IPresentator, Presentator>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual async void Dispose(bool disposing)
    {
        if (!Disposed)
        {
            if (disposing)
            {
                await StopAsync().ConfigureAwait(false);
            }

            Disposed = true;
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        if (!IsRunning)
        {
            IsRunning = true;

            await Hosting.StartAsync(cancellationToken).ConfigureAwait(false);
            Services.GetRequiredService<IPresentator>();
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        if (IsRunning)
        {
            IsRunning = false;
            await Hosting.StopAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    #endregion

}
