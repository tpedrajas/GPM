namespace GPM.Design.Mvpvm;

public interface IView
{

    #region events

    public event EventHandler Closed;

    #endregion

    #region properties

    public object DataContext { get; set; }

    public XmlLanguage Language { get; set; }

    #endregion

    #region methods

    public void Show();

    public bool? ShowDialog();

    #endregion

}
