namespace GPM.Product.Data.Persistence;

public class CubeIntersectorDBContext : DbContext, ICubeIntersectorDBContext
{

    #region constructors / deconstructors / destructors

    public CubeIntersectorDBContext(DbContextOptions<CubeIntersectorDBContext> options) : base(options)
    {

    }

    #endregion

    #region properties

    public DbSet<CubeEntity> CubeEntities { get; set; }

    #endregion

    #region methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedCubeIntersector();
    }

    #endregion

}