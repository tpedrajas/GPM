namespace GPM.Product.Data;

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