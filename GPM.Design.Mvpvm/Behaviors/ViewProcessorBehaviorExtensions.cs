namespace GPM.Design.Mvpvm.Behaviors;

internal static class ViewProcessorBehaviorExtensions
{

    #region extension methods

    internal static void CloseView(this IViewProcessorBehavior viewProcessor)
    {
        IViewProcessorBehaviorHidden viewProcessorHidden = viewProcessor.ToViewProcessorBehaviorHidden();
        viewProcessorHidden.CloseView();
    }

    internal static void ShowView(this IViewProcessorBehavior viewProcessor, bool isDialog, bool isMain)
    {
        IViewProcessorBehaviorHidden viewProcessorHidden = viewProcessor.ToViewProcessorBehaviorHidden();
        viewProcessorHidden.ShowView(isDialog, isMain);
    }

    private static IViewProcessorBehaviorHidden ToViewProcessorBehaviorHidden(this IViewProcessorBehavior viewProcessor)
    {
        return (IViewProcessorBehaviorHidden)viewProcessor;
    }

    #endregion

}
