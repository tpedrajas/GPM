namespace GPM.Product.WPF.Presenter;

public class WPFPresenter<VT, VMT, SM> : AbstractPresenter<VT, SM>, IWPFPresenter<VT, VMT, SM> where VT : IWPFView where VMT : IWPFViewModel where SM : IWPFServiceManager
{

    #region constructors / deconstructors / destructors

    protected WPFPresenter(VT view, VMT viewModel, SM serviceManager) : base(view, serviceManager)
    {
        _ViewModel = viewModel;

        _View.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.IetfLanguageTag);
        _View.DataContext = _ViewModel;

        ViewModelLinked += OnViewModelLinked;
        ViewModelLinked.Invoke(this, new EventArgs());
    }

    #endregion

    #region events

    public event EventHandler ViewModelLinked = (object? sender, EventArgs e) => { };

    #endregion

    #region fields

    protected readonly VMT _ViewModel;

    #endregion

    #region methods

    public override void MakeMainView()
    {
        Application.Current.MainWindow = _View.ToWindow();
    }

    protected override void OnViewClosed(object? sender, EventArgs e)
    {
        ViewModelLinked -= OnViewModelLinked;

        IWPFPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IWPFPresentationManager>();
        presentationManager.UnloadPresenter(this);

        base.OnViewClosed(sender, e);
    }

    protected virtual void OnViewModelLinked(object? sender, EventArgs e)
    {

    }

    public override void ShowView(bool isDialog)
    {
        if (isDialog)
        {
            _View.ShowDialog();
        }
        else
        {
            _View.Show();
        }
    }

    #endregion

}
