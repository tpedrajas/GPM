namespace GPM.Design.Mvpvm.Effects;

public interface IEffect
{

    #region events

    event EventHandler Completed;

    #endregion

    #region properties

    double ChangeValue { get; set; }

    int Duration { get; set; }

    EffectType EffectType { get; set; }

    double Maximum { get; set; }

    double Minimum { get; set; }

    double Value { get; set; }

    IViewModelEffect ViewModel { get; set; }

    #endregion

    #region methods

    public void Process();

    #endregion

}

public abstract class AbstractEffect<EVM> : IEffect where EVM : IViewModelEffect
{

    #region constructors / deconstructors / destructors

    protected AbstractEffect()
    {
        
    }

    #endregion

    #region events

    public event EventHandler Completed = delegate { };

    #endregion

    #region properties

    public double ChangeValue { get; set; }

    public int Duration { get; set; }

    public EffectType EffectType { get; set; }

    public double Maximum { get; set; }

    public double Minimum { get; set; }

    public double Value { get; set; }

    public required EVM ViewModel { get; set; }

    IViewModelEffect IEffect.ViewModel
    {
        get
        {
            return ViewModel;
        }
        set
        {
            ViewModel = (EVM)value;
        }
    }

    #endregion

    #region methods

    protected abstract void OnBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e);

    protected abstract void OnBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e);

    private void OnBackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        using BackgroundWorker backgroundWorker = (BackgroundWorker)sender!;

        backgroundWorker.DoWork -= OnBackgroundWorker_DoWork;
        backgroundWorker.ProgressChanged -= OnBackgroundWorker_ProgressChanged;
        backgroundWorker.RunWorkerCompleted -= OnBackgroundWorker_RunWorkerCompleted;

        Completed.Invoke(this, EventArgs.Empty);
    }

    public void Process()
    {
        BackgroundWorker BackgroundWorker = new() { WorkerReportsProgress = true };

        BackgroundWorker.DoWork += OnBackgroundWorker_DoWork;
        BackgroundWorker.ProgressChanged += OnBackgroundWorker_ProgressChanged;
        BackgroundWorker.RunWorkerCompleted += OnBackgroundWorker_RunWorkerCompleted;

        BackgroundWorker.RunWorkerAsync();
    }

    #endregion

}
