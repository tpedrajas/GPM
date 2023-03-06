namespace GPM.Design.Mvpvm.Management;

public interface IHostInitiator : IDisposable
{

    #region properties

    ISettingsLoader Settings { get; }

    #endregion

    #region methods

    Task StartAsync(CancellationToken cancellationToken = default);

    Task StopAsync(CancellationToken cancellationToken = default);

    #endregion

}
