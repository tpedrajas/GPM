namespace GPM.Design.Mvpvm.Extensions;

internal static class PresenterEffectExtensions
{

    internal static void OnVisualCloseEffect_Completed(this IPresenterCloseEffect presenter, object? sender, EventArgs e)
    {
        IPresenterCloseEffectHidden presenterCloseEffectHidden = presenter.ToPresenterCloseEffectHidden();
        presenterCloseEffectHidden.OnVisualCloseEffect_Completed(sender, e);
    }

    internal static void OnVisualEffect_Completed(this IPresenterEffect presenter, object? sender, EventArgs e)
    {
        IPresenterEffectHidden presenterEffectHidden = presenter.ToPresenterEffectHidden();
        presenterEffectHidden.OnVisualEffect_Completed(sender, e);
    }

    internal static void OnVisualShowEffect_Completed(this IPresenterShowEffect presenter, object? sender, EventArgs e)
    {
        IPresenterShowEffectHidden presenterShowEffectHidden = presenter.ToPresenterShowEffectHidden();
        presenterShowEffectHidden.OnVisualShowEffect_Completed(sender, e);
    }

    internal static IPresenterCloseEffectHidden ToPresenterCloseEffectHidden(this IPresenterCloseEffect presenter)
    {
        return (IPresenterCloseEffectHidden)presenter;
    }

    internal static IPresenterEffectHidden ToPresenterEffectHidden(this IPresenterEffect presenter)
    {
        return (IPresenterEffectHidden)presenter;
    }

    internal static IPresenterShowEffectHidden ToPresenterShowEffectHidden(this IPresenterShowEffect presenter)
    {
        return (IPresenterShowEffectHidden)presenter;
    }

}
