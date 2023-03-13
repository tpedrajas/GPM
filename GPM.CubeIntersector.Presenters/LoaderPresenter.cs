namespace GPM.CubeIntersector.Presenters;

public interface ILoaderPresenter : IPresenter
{

}

public class LoaderPresenter : Presenter<ILoaderView, ILoaderViewModel>, ILoaderPresenter
{

    #region constructors / deconstructors / destructors

    public LoaderPresenter(IServiceProvider services) : base(services)
    {
        FadeInEffectBehavior = services.GetRequiredService<IFadeInEffectBehavior>();
        FadeInEffectBehavior.WaitToComplete = true;
        FadeInEffectBehavior.Processed += OnShowEffect_Processed;

        FadeInEffectBehavior.TryAddSubscribedChannel((nameof(IViewProcessorBehavior), IViewProcessorBehavior.VIEW_LOADED_EVENT));
        TryAddBehavior(FadeInEffectBehavior);
    }

    #endregion

    #region properties

    IFadeInEffectBehavior FadeInEffectBehavior { get; init; }

    #endregion

    #region private methods

    private void OnLoadingProgressBar_BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
    {
        int increment = (int)ViewModel.LoadingProgressBar_LargeChange;
        int minimum = (int)ViewModel.LoadingProgressBar_Minimum;
        int maximum = (int)ViewModel.LoadingProgressBar_Maximum;

        BackgroundWorker loadingProgressBar_BackgroundWorker = (BackgroundWorker)sender!;

        for (int i = minimum; i <= maximum; i += increment)
        {
            loadingProgressBar_BackgroundWorker.ReportProgress(i);
            Thread.Sleep(50);
        }
    }

    private void OnLoadingProgressBar_BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        ViewModel.LoadingProgressBar_Value = e.ProgressPercentage;
    }

    private void OnLoadingProgressBar_BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        using BackgroundWorker loadingProgressBar_BackgroundWorker = (BackgroundWorker)sender!;

        loadingProgressBar_BackgroundWorker.DoWork -= OnLoadingProgressBar_BackgroundWorker_DoWork;
        loadingProgressBar_BackgroundWorker.ProgressChanged -= OnLoadingProgressBar_BackgroundWorker_ProgressChanged;
        loadingProgressBar_BackgroundWorker.RunWorkerCompleted -= OnLoadingProgressBar_BackgroundWorker_RunWorkerCompleted;

        PresenterProcessor.LoadPresenter<ICubeIntersectionPresenter>(false, true);
    }

    #endregion

    #region presenter methods

    protected override void OnInitializing(object? sender, EventArgs e)
    {
        ViewModel.LoadingLabel_Visibility = Visibility.Hidden;
        ViewModel.LoadingProgressBar_LargeChange = 1;
        ViewModel.LoadingProgressBar_Maximum = 100;
        ViewModel.LoadingProgressBar_SmallChange = 0.1;

        base.OnInitializing(sender, e);
    }

    #endregion

    #region effect methods

    private void OnCloseEffect_Processed(object? sender, EventArgs e)
    {

    }

    private void OnShowEffect_Processed(object? sender, EventArgs e)
    {
        BackgroundWorker loadingProgressBar_BackgroundWorker = new() { WorkerReportsProgress = true };

        loadingProgressBar_BackgroundWorker.DoWork += OnLoadingProgressBar_BackgroundWorker_DoWork;
        loadingProgressBar_BackgroundWorker.ProgressChanged += OnLoadingProgressBar_BackgroundWorker_ProgressChanged;
        loadingProgressBar_BackgroundWorker.RunWorkerCompleted += OnLoadingProgressBar_BackgroundWorker_RunWorkerCompleted;

        ViewModel.LoadingLabel_Visibility = Visibility.Visible;

        loadingProgressBar_BackgroundWorker.RunWorkerAsync();
    }

    #endregion

}
