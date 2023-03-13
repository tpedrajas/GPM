namespace GPM.Design.Mvpvm.Behaviors;

internal static class IViewProcessorBehaviorExtensions
{

    #region extension methods

    internal static void CloseView(this IViewProcessorBehavior viewProcessor, IPresenter presenter)
    {
        IViewProcessorBehaviorHidden viewProcessorHidden = viewProcessor.ToViewProcessorBehaviorHidden();
        viewProcessorHidden.CloseView(presenter);
    }

    internal static void ShowView(this IViewProcessorBehavior viewProcessor, IPresenter presenter, bool isDialog, bool isMain)
    {
        IViewProcessorBehaviorHidden viewProcessorHidden = viewProcessor.ToViewProcessorBehaviorHidden();
        viewProcessorHidden.ShowView(presenter, isDialog, isMain);
    }

    private static IViewProcessorBehaviorHidden ToViewProcessorBehaviorHidden(this IViewProcessorBehavior viewProcessor)
    {
        return (IViewProcessorBehaviorHidden)viewProcessor;
    }

    #endregion

}
