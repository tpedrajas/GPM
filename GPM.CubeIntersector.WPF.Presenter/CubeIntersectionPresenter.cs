namespace GPM.CubeIntersector.WPF.Presenter;

public class CubeIntersectionPresenter : WPFPresenter<ICubeIntersectionView, ICubeIntersectionViewModel, IWPFServiceManager>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IWPFServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        _ViewModel.AboutButtonClick += OnAboutButtonClick;
        _ViewModel.CalculateIntersectionButtonClick += OnCalculateIntersectionButtonClick;
        _ViewModel.CleanDataButtonClick += OnCleanDataButtonClick;
        _ViewModel.EnableCalculateIntersectionButtonValidating += OnEnableCalculateIntersectionButtonValidating;
        _ViewModel.ExistsIntersectionValidating += OnExistsIntersectionValidating;
    }

    #endregion

    #region fields


    private bool _IsCleaning;

    #endregion

    #region methods

    private void OnAboutButtonClick()
    {
        IWPFPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IWPFPresentationManager>();
        presentationManager.LoadPresenter<IAboutPresenter>(true, false);
    }

    private void OnCalculateIntersectionButtonClick()
    {
        Cube cube1 = new(Array.ConvertAll(new string[] { _ViewModel.XPositionCube1, _ViewModel.YPositionCube1, _ViewModel.ZPositionCube1 }, float.Parse),
                         Array.ConvertAll(new string[] { _ViewModel.WidthCube1, _ViewModel.HeightCube1, _ViewModel.DepthCube1 }, float.Parse));
        Cube cube2 = new(Array.ConvertAll(new string[] { _ViewModel.XPositionCube2, _ViewModel.YPositionCube2, _ViewModel.ZPositionCube2 }, float.Parse),
                         Array.ConvertAll(new string[] { _ViewModel.WidthCube2, _ViewModel.HeightCube2, _ViewModel.DepthCube2 }, float.Parse));

        Cube? cubeIntersection = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);

        if (cubeIntersection is not null)
        {
            _ViewModel.XPositionIntersection = cubeIntersection.Position.X;
            _ViewModel.YPositionIntersection = cubeIntersection.Position.Y;
            _ViewModel.ZPositionIntersection = cubeIntersection.Position.Z;
            _ViewModel.WidthIntersection = cubeIntersection.Size.X;
            _ViewModel.HeightIntersection = cubeIntersection.Size.Y;
            _ViewModel.DepthIntersection = cubeIntersection.Size.Z;
        }
    }

    private void OnCleanDataButtonClick(bool init)
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

    private bool OnEnableCalculateIntersectionButtonValidating()
    {
        bool canEnable = false;

        if (!_IsCleaning)
        {
            canEnable = true;

            canEnable &= Numeric.AreFloat(_ViewModel.XPositionCube1, _ViewModel.YPositionCube1, _ViewModel.ZPositionCube1);
            canEnable &= Numeric.AreFloat(_ViewModel.WidthCube1, _ViewModel.HeightCube1, _ViewModel.DepthCube1);
            canEnable &= Numeric.AreFloat(_ViewModel.XPositionCube2, _ViewModel.YPositionCube2, _ViewModel.ZPositionCube2);
            canEnable &= Numeric.AreFloat(_ViewModel.WidthCube2, _ViewModel.HeightCube2, _ViewModel.DepthCube2);

            _ViewModel.EnableCalculateIntersection = canEnable;
        }

        return canEnable;
    }

    private void OnExistsIntersectionValidating()
    {
        Cube cube1 = new(Array.ConvertAll(new string[] { _ViewModel.XPositionCube1, _ViewModel.YPositionCube1, _ViewModel.ZPositionCube1 }, float.Parse),
                         Array.ConvertAll(new string[] { _ViewModel.WidthCube1, _ViewModel.HeightCube1, _ViewModel.DepthCube1 }, float.Parse));
        Cube cube2 = new(Array.ConvertAll(new string[] { _ViewModel.XPositionCube2, _ViewModel.YPositionCube2, _ViewModel.ZPositionCube2 }, float.Parse),
                         Array.ConvertAll(new string[] { _ViewModel.WidthCube2, _ViewModel.HeightCube2, _ViewModel.DepthCube2 }, float.Parse));

        bool existIntersection = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        _ViewModel.ExistsIntersection = existIntersection;
    }

    protected override void OnViewClosed(object? sender, EventArgs e)
    {
        _ViewModel.AboutButtonClick -= OnAboutButtonClick;
        _ViewModel.CalculateIntersectionButtonClick -= OnCalculateIntersectionButtonClick;
        _ViewModel.CleanDataButtonClick -= OnCleanDataButtonClick;
        _ViewModel.EnableCalculateIntersectionButtonValidating -= OnEnableCalculateIntersectionButtonValidating;
        _ViewModel.ExistsIntersectionValidating -= OnExistsIntersectionValidating;

        base.OnViewClosed(sender, e);
    }

    protected override void OnViewModelLinked(object? sender, EventArgs e)
    {
        _ViewModel.Validate();
    }

    #endregion

}
