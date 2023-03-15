namespace GPM.Facade.Design.Mvpvm.Management;

public interface IHostKeeper : IDisposable
{

    #region properties

    IConfigurator Configurator { get; }

    #endregion

    #region methods

    Task StartAsync(CancellationToken cancellationToken = default);

    Task StopAsync(CancellationToken cancellationToken = default);

    #endregion

}
