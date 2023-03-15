namespace GPM.Design.Mvpvm.Behaviors;

internal static class BehaviorExtensions
{

    #region extension methods

    internal static void Configure(this IBehavior behavior)
    {
        IBehaviorHidden behaviorHidden = behavior.ToBehabiorHidden();
        behaviorHidden.Configure();
    }

    private static IBehaviorHidden ToBehabiorHidden(this IBehavior behavior)
    {
        return (IBehaviorHidden)behavior;
    }

    internal static void Unload(this IBehavior behavior)
    {
        IBehaviorHidden behaviorHidden = behavior.ToBehabiorHidden();
        behaviorHidden.Unload();
    }

    #endregion

}
