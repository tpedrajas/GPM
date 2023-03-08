namespace GPM.Design.Mvpvm.Effects;

public interface IPresenterEffect : IPresenter
{

    #region events

    event EventHandler Effect_Finalized;

    #endregion

    #region methods

    void OnEffect_Finalized(object? sender, EventArgs e);

    #endregion

}

public class PresenterEffect<V, VM, E> : Presenter<V, VM>, IPresenterEffect where V : IView where VM : IViewModelEffect where E : IEffect
{

    #region constructors / deconstructors / destructors

    protected PresenterEffect(IServiceProvider services) : base(services)
    {
        Effect_Finalized += OnEffect_Finalized;

        Effect = services.GetRequiredService<E>();
        Effect.ViewModel = ViewModel;
        Effect.Effect_Finalized += (this as IPresenterEffect).OnEffect_Finalized;

        switch (Effect.EffectType)
        {
            case EffectType.ShowEffect:
                Presentator.Presentator_PresenterLoaded += OnPresentator_PresenterEvent;

                break;

            case EffectType.CloseEffect:
                Presentator.Presentator_PresenterUnloaded += OnPresentator_PresenterEvent;

                break;
        }
    }

    #endregion

    #region events

    public event EventHandler Effect_Finalized = delegate { };

    #endregion

    #region properties

    internal E Effect { get; init; }

    #endregion

    #region methods

    void IPresenterEffect.OnEffect_Finalized(object? sender, EventArgs e)
    {
        Effect.Effect_Finalized -= (this as IPresenterEffect).OnEffect_Finalized;
        Effect_Finalized.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnEffect_Finalized(object? sender, EventArgs e)
    {
        Effect_Finalized -= OnEffect_Finalized;
    }

    internal void OnPresentator_PresenterEvent(object? sender, EventArgs e)
    {
        switch (Effect.EffectType)
        {
            case EffectType.ShowEffect:
                Presentator.Presentator_PresenterLoaded -= OnPresentator_PresenterEvent;

                break;

            case EffectType.CloseEffect:
                Presentator.Presentator_PresenterUnloaded -= OnPresentator_PresenterEvent;

                break;
        }

        Effect.Process();
    }

    #endregion

}

public class PresenterEffect<V, VM, SE, CE> : Presenter<V, VM>, IPresenterShowEffect, IPresenterCloseEffect where V : IView where VM : IViewModelEffect where SE : IShowEffect where CE : ICloseEffect
{

    #region constructors / deconstructors / destructors

    protected PresenterEffect(IServiceProvider services) : base(services)
    {
        CloseEffect_Finalized += OnCloseEffect_Finalized;
        ShowEffect_Finalized += OnShowEffect_Finalized;

        CloseEffect = services.GetRequiredService<CE>();
        CloseEffect.ViewModel = ViewModel;
        CloseEffect.Effect_Finalized += (this as IPresenterCloseEffect).OnCloseEffect_Finalized;

        ShowEffect = services.GetRequiredService<SE>();
        ShowEffect.ViewModel = ViewModel;
        ShowEffect.Effect_Finalized += (this as IPresenterShowEffect).OnShowEffect_Finalized;

        Presentator.Presentator_PresenterLoaded += OnPresentator_PresenterLoaded;
        Presentator.Presentator_PresenterUnloaded += OnPresentator_PresenterUnloaded;
    }

    #endregion

    #region events

    public event EventHandler CloseEffect_Finalized = delegate { };

    public event EventHandler ShowEffect_Finalized = delegate { };

    #endregion

    #region properties

    internal CE CloseEffect { get; init; }

    internal SE ShowEffect { get; init; }

    #endregion

    #region methods

    void IPresenterCloseEffect.OnCloseEffect_Finalized(object? sender, EventArgs e)
    {
        CloseEffect.Effect_Finalized -= (this as IPresenterCloseEffect).OnCloseEffect_Finalized;
        CloseEffect_Finalized.Invoke(this, EventArgs.Empty);
    }

    void IPresenterShowEffect.OnShowEffect_Finalized(object? sender, EventArgs e)
    {
        ShowEffect.Effect_Finalized -= (this as IPresenterShowEffect).OnShowEffect_Finalized;
        ShowEffect_Finalized.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnCloseEffect_Finalized(object? sender, EventArgs e)
    {
        CloseEffect_Finalized -= OnCloseEffect_Finalized;
    }

    internal void OnPresentator_PresenterLoaded(object? sender, EventArgs e)
    {
        Presentator.Presentator_PresenterLoaded -= OnPresentator_PresenterLoaded;
        ShowEffect.Process();
    }

    internal void OnPresentator_PresenterUnloaded(object? sender, EventArgs e)
    {
        Presentator.Presentator_PresenterUnloaded -= OnPresentator_PresenterUnloaded;
        CloseEffect.Process();
    }

    protected virtual void OnShowEffect_Finalized(object? sender, EventArgs e)
    {
        ShowEffect_Finalized -= OnShowEffect_Finalized;
    }

    #endregion

}