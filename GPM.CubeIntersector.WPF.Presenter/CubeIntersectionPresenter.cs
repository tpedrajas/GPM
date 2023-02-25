using GPM.Product.Common.Validation;

namespace GPM.CubeIntersector.WPF.Presenter;

public class CubeIntersectionPresenter : WPFPresenter<ICubeIntersectionView, ICubeIntersectionViewModel, IWPFServiceManager>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IWPFServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        viewModel.IsEnableCalculateIntersectionDelegate += IsEnableCalculateIntersection;
        viewModel.OnAboutDelegate += OnAbout;
        viewModel.OnCalculateIntersectionDelegate += OnCalculateIntersection;
        viewModel.OnCleanDataDelegate += OnCleanData;
        viewModel.OnExistsIntersectionDelegate += OnExistsIntersection;

        viewModel.CleanDataButtonClickCommand.Execute(true);
    }

    #endregion

    #region fields


    private bool _IsCleaning;

    #endregion

    #region methods

    private bool IsEnableCalculateIntersection()
    {
        bool canEnable = false;

        if (!_IsCleaning)
        {
            canEnable = true;

            canEnable &= Numeric.AreFloat(new string?[] { _ViewModel.XPositionCube1, _ViewModel.YPositionCube1, _ViewModel.ZPositionCube1 });
            canEnable &= Numeric.AreFloat(new string?[] { _ViewModel.WidthCube1, _ViewModel.HeightCube1, _ViewModel.DepthCube1 });
            canEnable &= Numeric.AreFloat(new string?[] { _ViewModel.XPositionCube2, _ViewModel.YPositionCube2, _ViewModel.ZPositionCube2 });
            canEnable &= Numeric.AreFloat(new string?[] { _ViewModel.WidthCube2, _ViewModel.HeightCube2, _ViewModel.DepthCube2 });

            _ViewModel.EnableCalculateIntersection = canEnable;
        }

        return canEnable;
    }

    private void OnAbout()
    {
        IWPFPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IWPFPresentationManager>();
        presentationManager.LoadPresenter<IAboutPresenter>(true, false);
    }

    private void OnCalculateIntersection()
    {
        Cube cube1 = new(float.Parse(_ViewModel.XPositionCube1!), float.Parse(_ViewModel.YPositionCube1!), float.Parse(_ViewModel.ZPositionCube1!),
                         float.Parse(_ViewModel.WidthCube1!), float.Parse(_ViewModel.HeightCube1!), float.Parse(_ViewModel.DepthCube1!));
        Cube cube2 = new(float.Parse(_ViewModel.XPositionCube2!), float.Parse(_ViewModel.YPositionCube2!), float.Parse(_ViewModel.ZPositionCube2!),
                         float.Parse(_ViewModel.WidthCube2!), float.Parse(_ViewModel.HeightCube2!), float.Parse(_ViewModel.DepthCube2!));

        Cube? cubeIntersection = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);

        if (cubeIntersection is not null)
        {
            _ViewModel.XPositionIntersection = cubeIntersection.Position.X;
            _ViewModel.YPositionIntersection = cubeIntersection.Position.Y;
            _ViewModel.ZPositionIntersection = cubeIntersection.Position.Z;
            _ViewModel.WidthIntersection = cubeIntersection.Dimension.X;
            _ViewModel.HeightIntersection = cubeIntersection.Dimension.Y;
            _ViewModel.DepthIntersection = cubeIntersection.Dimension.Z;
        }
    }

    private void OnCleanData(bool init)
    {
        _IsCleaning = true;

        _ViewModel.XPositionCube1 = string.Empty;
        _ViewModel.YPositionCube1 = string.Empty;
        _ViewModel.ZPositionCube1 = string.Empty;
        _ViewModel.WidthCube1 = string.Empty;
        _ViewModel.HeightCube1 = string.Empty;
        _ViewModel.DepthCube1 = string.Empty;

        _ViewModel.XPositionCube2 = string.Empty;
        _ViewModel.YPositionCube2 = string.Empty;
        _ViewModel.ZPositionCube2 = string.Empty;
        _ViewModel.WidthCube2 = string.Empty;
        _ViewModel.HeightCube2 = string.Empty;
        _ViewModel.DepthCube2 = string.Empty;

        if (!init)
        {
            _ViewModel.XPositionIntersection = null;
            _ViewModel.YPositionIntersection = null;
            _ViewModel.ZPositionIntersection = null;
            _ViewModel.WidthIntersection = null;
            _ViewModel.HeightIntersection = null;
            _ViewModel.DepthIntersection = null;

            _ViewModel.ExistsIntersection = false;
            _ViewModel.EnableCalculateIntersection = false;
        }

        _IsCleaning = false;
    }

    private void OnExistsIntersection()
    {
        Cube cube1 = new(float.Parse(_ViewModel.XPositionCube1!), float.Parse(_ViewModel.YPositionCube1!), float.Parse(_ViewModel.ZPositionCube1!),
                         float.Parse(_ViewModel.WidthCube1!), float.Parse(_ViewModel.HeightCube1!), float.Parse(_ViewModel.DepthCube1!));
        Cube cube2 = new(float.Parse(_ViewModel.XPositionCube2!), float.Parse(_ViewModel.YPositionCube2!), float.Parse(_ViewModel.ZPositionCube2!),
                         float.Parse(_ViewModel.WidthCube2!), float.Parse(_ViewModel.HeightCube2!), float.Parse(_ViewModel.DepthCube2!));

        bool existIntersection = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        _ViewModel.ExistsIntersection = existIntersection;
    }

    protected override void OnViewClosed(object? sender, EventArgs args)
    {
        _ViewModel.IsEnableCalculateIntersectionDelegate -= IsEnableCalculateIntersection;
        _ViewModel.OnAboutDelegate -= OnAbout;
        _ViewModel.OnCalculateIntersectionDelegate -= OnCalculateIntersection;
        _ViewModel.OnCleanDataDelegate -= OnCleanData;
        _ViewModel.OnExistsIntersectionDelegate -= OnExistsIntersection;

        base.OnViewClosed(sender, args);
    }

    #endregion

}
