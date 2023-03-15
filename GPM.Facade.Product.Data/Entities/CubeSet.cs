namespace GPM.Facade.Product.Data.Entities;

[Table("TD_CUBE")]
[PrimaryKey(nameof(Id))]
[Index(nameof(Id), IsUnique = true)]
public sealed class CubeSet
{

    #region properties

    [Column("TDCE_DEPTH", Order = 6, TypeName = "real")]
    public float Depth { get; set; }

    [Column("TDCE_HEIGHT", Order = 5, TypeName = "real")]
    public float Height { get; set; }

    [Column("TDCE_ID", Order = 0, TypeName = "varchar(20)")]
    public required string Id { get; set; }

    [Column("TDCE_WIDTH", Order = 4, TypeName = "real")]
    public float Width { get; set; }

    [Column("TDCE_X", Order = 1, TypeName = "real")]
    public float X { get; set; }

    [Column("TDCE_Y", Order = 2, TypeName = "real")]
    public float Y { get; set; }

    [Column("TDCE_Z", Order = 3, TypeName = "real")]
    public float Z { get; set; }

    #endregion

}
