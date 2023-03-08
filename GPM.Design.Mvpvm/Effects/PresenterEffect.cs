namespace GPM.Design.Mvpvm.Effects;

public interface IPresenterEffect : IPresenter
{

    #region events

    event EventHandler Effect_Completed;

    #endregion

}

internal interface IPresenterEffectHidden
{

    #region methods

    void OnVisualEffect_Completed(object? sender, EventArgs e);

    #endregion

}

public class PresenterEffect<V, VM, E> : Presenter<V, VM>, IPresenterEffect, IPresenterEffectHidden where V : IView where VM : IViewModelEffect where E : IEffect
{

    #region constructors / deconstructors / destructors

    protected PresenterEffect(IServiceProvider services) : base(services)
    {
        Effect_Completed += OnEffect_Completed;

        VisualEffect = services.GetRequiredService<E>();
        VisualEffect.ViewModel = ViewModel;
        VisualEffect.Completed += this.OnVisualEffect_Completed;

        switch (VisualEffect.EffectType)
        {
            case EffectType.ShowEffect:
                Presentator.PresenterLoaded += OnPresentator_PresenterEvent;

                break;

            case EffectType.CloseEffect:
                Presentator.PresenterUnloaded += OnPresentator_PresenterEvent;

                break;
        }
    }

    #endregion

    #region events

    public event EventHandler Effect_Completed = delegate { };

    #endregion

    #region properties

    internal E VisualEffect { get; init; }

    #endregion

    #region methods

    void IPresenterEffectHidden.OnVisualEffect_Completed(object? sender, EventArgs e)
    {
        VisualEffect.Completed -= this.OnVisualEffect_Completed;
        Effect_Completed.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnEffect_Completed(object? sender, EventArgs e)
    {
        Effect_Completed -= OnEffect_Completed;
    }

    internal void OnPresentator_PresenterEvent(object? sender, EventArgs e)
    {
        switch (VisualEffect.EffectType)
        {
            case EffectType.ShowEffect:
                Presentator.PresenterLoaded -= OnPresentator_PresenterEvent;

                break;

            case EffectType.CloseEffect:
                Presentator.PresenterUnloaded -= OnPresentator_PresenterEvent;

                break;
        }

        VisualEffect.Process();
    }

    #endregion

}

public class PresenterEffect<V, VM, SE, CE> : Presenter<V, VM>, IPresenterShowEffect, IPresenterShowEffectHidden, IPresenterCloseEffect, IPresenterCloseEffectHidden where V : IView where VM : IViewModelEffect where SE : IShowEffect where CE : ICloseEffect
{

    #region constructors / deconstructors / destructors

    protected PresenterEffect(IServiceProvider services) : base(services)
    {
        CloseEffect_Completed += OnCloseEffect_Completed;
        ShowEffect_Completed += OnShowEffect_Completed;

        CloseEffect = services.GetRequiredService<CE>();
        CloseEffect.ViewModel = ViewModel;
        CloseEffect.Completed += this.OnVisualCloseEffect_Completed;

        ShowEffect = services.GetRequiredService<SE>();
        ShowEffect.ViewModel = ViewModel;
        ShowEffect.Completed += this.OnVisualShowEffect_Completed;

        Presentator.PresenterLoaded += OnPresentator_PresenterLoaded;
        Presentator.PresenterUnloaded += OnPresentator_PresenterUnloaded;
    }

    #endregion

    #region events

    public event EventHandler CloseEffect_Completed = delegate { };

    public event EventHandler ShowEffect_Completed = delegate { };

    #endregion

    #region properties

    internal CE CloseEffect { get; init; }

    internal SE ShowEffect { get; init; }

    #endregion

    #region methods

    void IPresenterCloseEffectHidden.OnVisualCloseEffect_Completed(object? sender, EventArgs e)
    {
        CloseEffect.Completed -= this.OnVisualCloseEffect_Completed;
        CloseEffect_Completed.Invoke(this, EventArgs.Empty);
    }

    void IPresenterShowEffectHidden.OnVisualShowEffect_Completed(object? sender, EventArgs e)
    {
        ShowEffect.Completed -= this.OnVisualShowEffect_Completed;
        ShowEffect_Completed.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnCloseEffect_Completed(object? sender, EventArgs e)
    {
        CloseEffect_Completed -= OnCloseEffect_Completed;
    }

    internal void OnPresentator_PresenterLoaded(object? sender, EventArgs e)
    {
        Presentator.PresenterLoaded -= OnPresentator_PresenterLoaded;
        ShowEffect.Process();
    }

    internal void OnPresentator_PresenterUnloaded(object? sender, EventArgs e)
    {
        Presentator.PresenterUnloaded -= OnPresentator_PresenterUnloaded;
        CloseEffect.Process();
    }

    protected virtual void OnShowEffect_Completed(object? sender, EventArgs e)
    {
        ShowEffect_Completed -= OnShowEffect_Completed;
    }

    #endregion

}