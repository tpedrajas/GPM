namespace GPM.Product.WPF.View;

public interface IWPFView : IView
{

    #region properties

    public object DataContext { get; set; }

    public XmlLanguage Language { get; set; }

    #endregion

    #region methods

    public bool? ShowDialog();

    #endregion

}
