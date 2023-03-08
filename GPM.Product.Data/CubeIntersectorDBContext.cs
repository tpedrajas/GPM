namespace GPM.Product.Data;

public interface ICubeIntersectorDBContext : IDisposable, IAsyncDisposable
{

    #region properties

    public DbSet<CubeSet> CubeEntities { get; set; }

    DatabaseFacade Database { get; }

    #endregion

    #region methods

    public int SaveChanges();

    public int SaveChanges(bool AcceptAllChangesOnSuccess);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task<int> SaveChangesAsync(bool AcceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    #endregion

}

public class CubeIntersectorDBContext : DbContext, ICubeIntersectorDBContext
{

    #region constructors / deconstructors / destructors

    public CubeIntersectorDBContext(DbContextOptions<CubeIntersectorDBContext> options) : base(options)
    {

    }

    #endregion

    #region properties

    public DbSet<CubeSet> CubeEntities { get; set; }

    #endregion

    #region methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedCubeIntersector();
    }

    #endregion

}