namespace GPM.Product.WPF.Presenter;

public class WPFPresenter<VT, VMT, SM> : AbstractPresenter<VT, SM>, IWPFPresenter<VT, VMT, SM> where VT : IWPFView where VMT : IWPFViewModel where SM : IWPFServiceManager
{

    #region constructors / deconstructors / destructors

    protected WPFPresenter(VT view, VMT viewModel, SM serviceManager) : base(view, serviceManager)
    {
        view.DataContext = viewModel;
        view.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.IetfLanguageTag);

        _ViewModel = viewModel;
    }

    #endregion

    #region fields

    protected VMT _ViewModel { get; init; }

    #endregion

    #region methods

    public override void MakeMainView()
    {
        Application.Current.MainWindow = _View.ToWindow();
    }

    protected override void OnViewClosed(object? sender, EventArgs args)
    {
        base.OnViewClosed(sender, args);

        IWPFPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IWPFPresentationManager>();
        presentationManager.UnloadPresenter(this);
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
