namespace GPM.Product.Data.Entities;

[Table("TD_CUBE")]
[PrimaryKey(nameof(Id))]
[Index(nameof(Id), IsUnique = true)]
public sealed class CubeEntity
{

    #region properties

    [Column("TDCE_DEPTH", Order = 6, TypeName = "real")]
    public required float Depth { get; set; }

    [Column("TDCE_HEIGHT", Order = 5, TypeName = "real")]
    public required float Height { get; set; }

    [Column("TDCE_ID", Order = 0, TypeName = "varchar(20)")]
    public required string Id { get; set; }

    [Column("TDCE_WIDTH", Order = 4, TypeName = "real")]
    public required float Width { get; set; }

    [Column("TDCE_X", Order = 1, TypeName = "real")]
    public required float X { get; set; }

    [Column("TDCE_Y", Order = 2, TypeName = "real")]
    public required float Y { get; set; }

    [Column("TDCE_Z", Order = 3, TypeName = "real")]
    public required float Z { get; set; }

    #endregion

}
