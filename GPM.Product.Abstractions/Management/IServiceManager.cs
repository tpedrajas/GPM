namespace GPM.Product.Abstractions.Management;

public interface IServiceManager : IAsyncDisposable
{

    #region properties

    public IHost? Hosting { get; }

    public Dictionary<Type, (int MaxInstances, int NumInstances)> PresenterCollectionInfo { get; init; }

    public IServiceProvider ServiceProvider { get; init; }

    #endregion

    #region methods
    public void Run();

    #endregion

}
