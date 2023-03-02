namespace GPM.Product.Data;

public static class ModelBuilderExtensions
{

    #region methods

    public static void SeedCubeIntersector(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CubeSet>().HasData(
            new CubeSet() { Id = "test1", X = 0, Y = 1, Z = 2, Width = 3, Height = 4, Depth = 5 },
            new CubeSet() { Id = "test2", X = 1, Y = 2, Z = 3, Width = 4, Height = 5, Depth = 6 },
            new CubeSet() { Id = "test3", X = 2, Y = 3, Z = 4, Width = 5, Height = 6, Depth = 7 },
            new CubeSet() { Id = "test4", X = 3, Y = 4, Z = 5, Width = 6, Height = 7, Depth = 8 },
            new CubeSet() { Id = "test5", X = 4, Y = 5, Z = 6, Width = 7, Height = 8, Depth = 8 }
        );
    }

    #endregion

}
