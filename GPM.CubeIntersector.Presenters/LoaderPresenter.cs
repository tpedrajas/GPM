namespace GPM.CubeIntersector.Presenters;

public class LoaderPresenter : Presenter<ILoaderView, ILoaderViewModel>, ILoaderPresenter
{

    #region constructors / deconstructors / destructors

    public LoaderPresenter(IServiceProvider services) : base(services)
    {
        
    }

    #endregion

    #region methods

    private void OnProgressWorker_DoWork(object? sender, DoWorkEventArgs e)
    {
        double increment = ViewModel.LargeChangeProgressBarValue;

        for (double i = ViewModel.MinimumProgressBarValue; i <= ViewModel.MaximumProgressBarValue; i += 10)
        {
            (sender as BackgroundWorker)!.ReportProgress((int)i);
            Thread.Sleep(150);
        }
    }

    private void OnProgressWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        ViewModel.ProgressBarValue = e.ProgressPercentage;
    }

    private void OnProgressWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        using BackgroundWorker progressWorker = (BackgroundWorker)sender!;

        progressWorker.DoWork -= OnProgressWorker_DoWork;
        progressWorker.ProgressChanged -= OnProgressWorker_ProgressChanged;
        progressWorker.RunWorkerCompleted -= OnProgressWorker_RunWorkerCompleted;

        Presentator.LoadPresenter<ICubeIntersectionPresenter>(false, true);
    }

    protected override void OnView_Loaded(object? sender, RoutedEventArgs e)
    {
        BackgroundWorker progressWorker = new()
        {
            WorkerReportsProgress = true
        };

        progressWorker.DoWork += OnProgressWorker_DoWork;
        progressWorker.ProgressChanged += OnProgressWorker_ProgressChanged;
        progressWorker.RunWorkerCompleted += OnProgressWorker_RunWorkerCompleted;

        progressWorker.RunWorkerAsync();
    }

    #endregion

}
