namespace GPM.Design.Mvpvm.Effects;

public sealed class FadeOutEffectBehavior : AbstractEffectBehavior<IViewModelOpacityEffect>, IFadeOutEffectBehavior
{

    #region constructors / deconstructors / destructors

    public FadeOutEffectBehavior() : base()
    {
        ChangeValue = 1;
        Duration = 5000;
        Maximum = 100;
        Minimum = 0;
    }

    #endregion

    #region methods

    protected override void OnBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
    {
        BackgroundWorker backgroundWorker = (BackgroundWorker)sender!;

        int changeValue = (int)ChangeValue;
        int maximum = (int)(Maximum - Minimum);
        int minimum = 0;

        int iterationDuration = Duration * changeValue / (maximum - minimum);

        Stopwatch stopWatch = new();
        stopWatch.Start();

        for (int i = minimum + 1; i <= maximum; i += changeValue)
        {
            backgroundWorker.ReportProgress(maximum - i);

            Thread.Sleep((iterationDuration * i) - (int)stopWatch.ElapsedMilliseconds);
        }

        stopWatch.Stop();
    }

    protected override void OnBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        ViewModel.Opacity = e.ProgressPercentage / 100d;
    }

    #endregion

}
