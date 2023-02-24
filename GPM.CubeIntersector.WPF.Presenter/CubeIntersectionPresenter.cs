namespace GPM.CubeIntersector.WPF.Presenter;

public class CubeIntersectionPresenter : WPFPresenter<ICubeIntersectionView, ICubeIntersectionViewModel, IWPFServiceManager>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    static CubeIntersectionPresenter()
    {
        
    }

    public CubeIntersectionPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IWPFServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        viewModel.OnAboutDelegate += OnAbout;
        viewModel.OnCalculateIntersectionDelegate += OnCalculateIntersection;
        viewModel.OnExistsIntersectionDelegate += OnExistsIntersection;
    }

    #endregion

    #region methods

    private void OnAbout(object? sender, EventArgs args)
    {
        IWPFPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IWPFPresentationManager>();
        presentationManager.LoadPresenter<IAboutPresenter>(true, false);
    }

    private void OnCalculateIntersection(object? sender, EventArgs args)
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

    private void OnExistsIntersection(object? sender, EventArgs args)
    {
        Cube cube1 = new(float.Parse(_ViewModel.XPositionCube1!), float.Parse(_ViewModel.YPositionCube1!), float.Parse(_ViewModel.ZPositionCube1!),
                         float.Parse(_ViewModel.WidthCube1!), float.Parse(_ViewModel.HeightCube1!), float.Parse(_ViewModel.DepthCube1!));
        Cube cube2 = new(float.Parse(_ViewModel.XPositionCube2!), float.Parse(_ViewModel.YPositionCube2!), float.Parse(_ViewModel.ZPositionCube2!),
                         float.Parse(_ViewModel.WidthCube2!), float.Parse(_ViewModel.HeightCube2!), float.Parse(_ViewModel.DepthCube2!));

        bool existIntersection = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        _ViewModel.ExistsIntersection = existIntersection;
    }

    #endregion

}
