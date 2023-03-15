namespace GPM.Design.Mvpvm.Effects;

public abstract class AbstractEffectBehavior<TViewModel> : ObserverBehavior, IEffectBehavior where TViewModel : IViewModelEffect
{

    #region constructors / deconstructors / destructors

    protected AbstractEffectBehavior()
    {
        Processed += OnProcessed;
    }

    #endregion

    #region events

    public event EventHandler Processed = delegate { };

    #endregion

    #region properties

    public double ChangeValue { get; set; }

    public int Duration { get; set; }

    public double Maximum { get; set; }

    public double Minimum { get; set; }

    public double Value { get; set; }

    public required TViewModel ViewModel { get; set; }

    #endregion

    #region methods

    public override IParameterizedService Fill(object parameter, params object[] parameters)
    {
        ViewModel = (TViewModel)parameters[1];

        return base.Fill(parameter, parameters);
    }

    protected abstract void OnBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e);

    protected abstract void OnBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e);

    private void OnBackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        using BackgroundWorker backgroundWorker = (BackgroundWorker)sender!;

        backgroundWorker.DoWork -= OnBackgroundWorker_DoWork;
        backgroundWorker.ProgressChanged -= OnBackgroundWorker_ProgressChanged;
        backgroundWorker.RunWorkerCompleted -= OnBackgroundWorker_RunWorkerCompleted;

        Processed.Invoke(this, EventArgs.Empty);
    }

    public override void OnNext(IChannelNotificatorBehavior notificator)
    {
        base.OnNext(notificator);

        Process();
    }

    public void Process()
    {
        BackgroundWorker BackgroundWorker = new() { WorkerReportsProgress = true };

        BackgroundWorker.DoWork += OnBackgroundWorker_DoWork;
        BackgroundWorker.ProgressChanged += OnBackgroundWorker_ProgressChanged;
        BackgroundWorker.RunWorkerCompleted += OnBackgroundWorker_RunWorkerCompleted;

        BackgroundWorker.RunWorkerAsync();
    }

    protected void OnProcessed(object? sender, EventArgs e)
    {
        
    }

    #endregion

}
