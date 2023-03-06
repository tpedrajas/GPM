namespace GPM.Design.Mvpvm;

public class Presenter<V, VM> : IPresenter<V, VM> where V : IView where VM : IViewModel
{

    #region constructors / deconstructors / destructors

    protected Presenter(IServiceProvider services)
    {
        Initialize += OnInitialize;

        Services = services;
        View = services.GetRequiredService<V>();
        ViewModel = services.GetRequiredService<VM>();

        View.Closed += OnViewClosed;

        View.DataContext = ViewModel;
    }

    #endregion

    #region events

    public event EventHandler Initialize = delegate { };

    #endregion

    #region fields

    private int _MaxInstances = 1;

    #endregion

    #region properties

    public int MaxInstances
    {
        get
        {
            return _MaxInstances;
        }
        protected init
        {
            ExceptionHelper.ThrowIfTrue<OverflowException>(value <= 0);
            _MaxInstances = value;
        }
    }

    protected IPresentator Presentator
    {
        get
        {
            return Services.GetRequiredService<IPresentator>();
        }
    }

    private IServiceProvider Services { get; init; }

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
        Initialize.Invoke(this, new EventArgs());
    }

    protected virtual void OnInitialize(object? sender, EventArgs e)
    {
        
    }

    protected virtual void OnViewClosed(object? sender, EventArgs e)
    {
        Initialize -= OnInitialize;

        View.Closed -= OnViewClosed;
    }

    #endregion

}
