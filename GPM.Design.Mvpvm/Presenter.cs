namespace GPM.Design.Mvpvm;

public interface IPresenter
{

    #region events

    event EventHandler Presenter_Initialized;

    #endregion

    #region properties

    IView View { get; }

    IViewModel ViewModel { get; }

    #endregion

    #region methods

    void InitializePresenter();

    #endregion

}

public class Presenter<V, VM> : IPresenter where V : IView where VM : IViewModel
{

    #region constructors / deconstructors / destructors

    protected Presenter(IServiceProvider services)
    {
        Presenter_Initialized += OnPresenter_Initialized;
    
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

    public event EventHandler Presenter_Initialized = delegate { };

    #endregion

    #region properties

    protected IPresentator Presentator { get; init; }

    protected V View { get; init; }

    IView IPresenter.View
    {
        get
        {
            return View;
        }
    }

    protected VM ViewModel { get; set; }

    IViewModel IPresenter.ViewModel
    {
        get
        {
            return ViewModel;
        }
    }

    #endregion

    #region methods

    void IPresenter.InitializePresenter()
    {
        Presenter_Initialized.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnPresenter_Initialized(object? sender, EventArgs e)
    {
        Presenter_Initialized -= OnPresenter_Initialized;
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
