namespace GPM.CubeIntersector.Presenters;

public interface ILoaderPresenter : IPresenterShowEffect, IPresenterCloseEffect
{

}

public class LoaderPresenter : PresenterEffect<ILoaderView, ILoaderViewModel, IFadeIn, IFadeOut>, ILoaderPresenter
{

    #region constructors / deconstructors / destructors

    public LoaderPresenter(IServiceProvider services) : base(services)
    {
        
    }

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

        Presentator.LoadPresenter<ICubeIntersectionPresenter>(false, true);
    }

    #endregion

    #region presenter methods

    protected override void OnInitialized(object? sender, EventArgs e)
    {
        ViewModel.LoadingLabel_Visibility = Visibility.Hidden;
        ViewModel.LoadingProgressBar_LargeChange = 1;
        ViewModel.LoadingProgressBar_Maximum = 100;
        ViewModel.LoadingProgressBar_SmallChange = 0.1;

        base.OnInitialized(sender, e);
    }

    #endregion

    #region presenter effect methods

    protected override void OnCloseEffect_Completed(object? sender, EventArgs e)
    {

    }

    protected override void OnShowEffect_Completed(object? sender, EventArgs e)
    {
        BackgroundWorker loadingProgressBar_BackgroundWorker = new() { WorkerReportsProgress = true };

        loadingProgressBar_BackgroundWorker.DoWork += OnLoadingProgressBar_BackgroundWorker_DoWork;
        loadingProgressBar_BackgroundWorker.ProgressChanged += OnLoadingProgressBar_BackgroundWorker_ProgressChanged;
        loadingProgressBar_BackgroundWorker.RunWorkerCompleted += OnLoadingProgressBar_BackgroundWorker_RunWorkerCompleted;

        ViewModel.LoadingLabel_Visibility = Visibility.Visible;

        loadingProgressBar_BackgroundWorker.RunWorkerAsync();
    }

    #endregion

    #region view methods

    protected override void OnView_Loaded(object? sender, RoutedEventArgs e)
    {

    }

    #endregion

    #region viewmodel methods

    #endregion

}
