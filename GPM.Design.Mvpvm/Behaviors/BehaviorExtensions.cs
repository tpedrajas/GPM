namespace GPM.Design.Mvpvm.Behaviors;

internal static class BehaviorExtensions
{

    #region extension methods

    internal static void Configure(this IBehavior behavior, IPresenter presenter)
    {
        IBehaviorHidden behaviorHidden = behavior.ToBehabiorHidden();
        behaviorHidden.Configure(presenter);
    }

    private static IBehaviorHidden ToBehabiorHidden(this IBehavior behavior)
    {
        return (IBehaviorHidden)behavior;
    }

    internal static void Unload(this IBehavior behavior, IPresenter presenter)
    {
        IBehaviorHidden behaviorHidden = behavior.ToBehabiorHidden();
        behaviorHidden.Unload(presenter);
    }

    #endregion

}
