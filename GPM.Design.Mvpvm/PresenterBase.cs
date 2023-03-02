namespace GPM.Design.Mvpvm;

public class PresenterBase<VT, VMT, SM> : IMvpvmPresenter<VT, VMT, SM> where VT : IViewBase where VMT : IViewModelBase where SM : IServiceManager
{

    #region constructors / deconstructors / destructors

    protected PresenterBase(VT view, VMT viewModel, SM serviceManager)
    {
        _ServiceManager = serviceManager;
        _ViewModel = viewModel;
        _View = view;

        _View.DataContext = _ViewModel;

        _View.Closed += OnViewClosed;
        ViewModelLinked += OnViewModelLinked;
        ViewModelLinked.Invoke(this, new EventArgs());
    }

    #endregion

    #region events

    public event EventHandler ViewModelLinked = delegate { };

    #endregion

    #region fields

    protected readonly SM _ServiceManager;

    protected readonly VT _View;

    protected readonly VMT _ViewModel;

    #endregion

    #region properties

    public int MaxInstances { get; protected set; } = 1;

    #endregion

    #region methods

    public void MakeMainView()
    {
        Application.Current.MainWindow = _View.ToWindow();
    }

    protected virtual void OnViewClosed(object? sender, EventArgs e)
    {
        ViewModelLinked -= OnViewModelLinked;
        _View.Closed -= OnViewClosed;

        IPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IPresentationManager>();
        presentationManager.UnloadPresenter(this);
    }

    protected virtual void OnViewModelLinked(object? sender, EventArgs e)
    {

    }

    public void ShowView(bool isDialog)
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
