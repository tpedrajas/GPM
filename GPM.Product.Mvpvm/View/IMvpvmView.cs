namespace GPM.Product.Mvpvm.View;

public interface IMvpvmView : IMvpView
{

    #region properties

    public object DataContext { get; set; }

    public XmlLanguage Language { get; set; }

    #endregion

    #region methods

    public bool? ShowDialog();

    #endregion

}
