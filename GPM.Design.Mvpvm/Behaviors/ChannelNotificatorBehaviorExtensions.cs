namespace GPM.Design.Mvpvm.Behaviors;

internal static class ChannelNotificatorBehaviorExtensions
{

    #region extension methods

    internal static void SetData(this IChannelNotificatorBehavior notificator, object[] data)
    {
        IChannelNotificatorBehaviorHidden notificatorHidden = notificator.ToChannelNotificatorBehaviorHidden();
        notificatorHidden.SetData(data);
    }

    private static IChannelNotificatorBehaviorHidden ToChannelNotificatorBehaviorHidden(this IChannelNotificatorBehavior notificator)
    {
        return (IChannelNotificatorBehaviorHidden)notificator;
    }

    #endregion

}
