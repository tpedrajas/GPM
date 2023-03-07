namespace GPM.Design.Mvpvm;

public class Presenter<V, VM> : IPresenter<V, VM> where V : IView where VM : IViewModel
{

    #region constructors / deconstructors / destructors

    protected Presenter(IServiceProvider services)
    {
        Initialized += OnInitialized;
    
        Presentator = services.GetRequiredService<IPresentator>();
        View = services.GetRequiredService<V>();
        ViewModel = services.GetRequiredService<VM>();

        View.Activated += OnView_Activated;
        View.Closing += OnView_Closing;
        View.Closed += OnView_Closed;
        View.Deactivated += OnView_Deactivated;
        View.Loaded += OnView_Loaded;

        View.DataContext = ViewModel;
    }

    #endregion

    #region events

    public event EventHandler Initialized = delegate { };

    #endregion

    #region properties

    protected IPresentator Presentator { get; init; }

    protected V View { get; init; }

    protected VM ViewModel { get; init; }

    #endregion

    #region methods

    IView IPresenter.GetView()
    {
        return View;
    }

    IViewModel IPresenter.GetViewModel()
    {
        return ViewModel;
    }

    void IPresenter.Init()
    {
        Initialized.Invoke(this, new EventArgs());
    }

    protected virtual void OnInitialized(object? sender, EventArgs e)
    {
        Initialized -= OnInitialized;
    }

    protected virtual void OnView_Activated(object? sender, EventArgs e)
    {

    }

    protected virtual void OnView_Closing(object? sender, CancelEventArgs e)
    {
        View.Closing -= OnView_Closing;
    }

    protected virtual void OnView_Closed(object? sender, EventArgs e)
    {
        View.Activated -= OnView_Activated;
        View.Closed -= OnView_Closed;
        View.Deactivated -= OnView_Deactivated;

        Presentator.UnloadPresenter(this);
    }

    protected virtual void OnView_Deactivated(object? sender, EventArgs e)
    {
        
    }

    protected virtual void OnView_Loaded(object? sender, RoutedEventArgs e)
    {
        View.Loaded -= OnView_Loaded;
    }

    #endregion

}
