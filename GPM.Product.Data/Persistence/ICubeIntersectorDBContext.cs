namespace GPM.Product.Data.Persistence;

public interface ICubeIntersectorDBContext : IDisposable, IAsyncDisposable
{

    #region properties

    public DbSet<CubeEntity> CubeEntities { get; set; }

    DatabaseFacade Database { get; }

    #endregion

    #region methods

    public int SaveChanges();

    public int SaveChanges(bool AcceptAllChangesOnSuccess);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task<int> SaveChangesAsync(bool AcceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    #endregion

}
