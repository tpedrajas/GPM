namespace GPM.Facade.Product.Models;

public interface ICube : IModel, IParameterizedService
{

    #region  properties

    float Depth { get; set; }

    float Height { get; set; }

    float Width { get; set; }

    float X { get; set; }

    float Y { get; set; }

    float Z { get; set; }

    #endregion

}
