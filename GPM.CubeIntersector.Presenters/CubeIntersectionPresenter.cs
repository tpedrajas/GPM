namespace GPM.CubeIntersector.Presenters;

public class CubeIntersectionPresenter : Presenter<ICubeIntersectionView, ICubeIntersectionViewModel>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(IServiceProvider services) : base(services)
    {
        Mapper = services.GetRequiredService<IMapper>();
        Settings = services.GetRequiredService<ISettingsLoader>();

        ViewModel.AboutButtonClick += OnAboutButtonClick;
        ViewModel.CalculateIntersectionButtonClick += OnCalculateIntersectionButtonClick;
        ViewModel.CleanDataButtonClick += OnCleanDataButtonClick;
        ViewModel.EnableCalculateIntersectionButtonValidating += OnEnableCalculateIntersectionButtonValidating;
        ViewModel.EnableEnglishMenuValidating += OnEnableEnglishMenuValidating;
        ViewModel.EnableLoadInformationCube1ButtonValidating += OnEnableLoadInformationCube1ButtonValidating;
        ViewModel.EnableLoadInformationCube2ButtonValidating += OnEnableLoadInformationCube2ButtonValidating;
        ViewModel.EnableSaveInformationCube1ButtonValidating += OnEnableSaveInformationCube1ButtonValidating;
        ViewModel.EnableSaveInformationCube2ButtonValidating += OnEnableSaveInformationCube2ButtonValidating;
        ViewModel.EnableSpanishMenuValidating += OnEnableSpanishMenuValidating;
        ViewModel.EnglishMenuClick += OnEnglishMenuClick;
        ViewModel.ExistsIntersectionValidating += OnExistsIntersectionValidating;
        ViewModel.LoadInformationCube1Click += OnLoadInformationCube1Click;
        ViewModel.LoadInformationCube2Click += OnLoadInformationCube2Click;
        ViewModel.SaveInformationCube1Click += OnSaveInformationCube1Click;
        ViewModel.SaveInformationCube2Click += OnSaveInformationCube2Click;
        ViewModel.SpanishMenuClick += OnSpanishMenuClick;
    }

    #endregion

    #region properties

    private bool IsCleaning { get; set; }

    private IMapper Mapper { get; init; }

    private ISettingsLoader Settings { get; init; }

    #endregion

    #region methods

    private void CleanInformation(bool cleanInformationCube1, bool cleanInformationCube2)
    {
        IsCleaning = true;

        if (cleanInformationCube1 || cleanInformationCube2)
        {
            if (cleanInformationCube1)
            {
                ViewModel.XPositionCube1 = string.Empty;
                ViewModel.YPositionCube1 = string.Empty;
                ViewModel.ZPositionCube1 = string.Empty;

                ViewModel.WidthCube1 = string.Empty;
                ViewModel.HeightCube1 = string.Empty;
                ViewModel.DepthCube1 = string.Empty;
            }

            if (cleanInformationCube2)
            {
                ViewModel.XPositionCube2 = string.Empty;
                ViewModel.YPositionCube2 = string.Empty;
                ViewModel.ZPositionCube2 = string.Empty;

                ViewModel.WidthCube2 = string.Empty;
                ViewModel.HeightCube2 = string.Empty;
                ViewModel.DepthCube2 = string.Empty;
            }
        }

        ViewModel.XPositionIntersection = null;
        ViewModel.YPositionIntersection = null;
        ViewModel.ZPositionIntersection = null;

        ViewModel.WidthIntersection = null;
        ViewModel.HeightIntersection = null;
        ViewModel.DepthIntersection = null;

        ViewModel.ExistsIntersectionChecked = false;
        
        IsCleaning = false;
    }

    private Cube GetInformationCube1()
    {
        return new(float.Parse(ViewModel.XPositionCube1), float.Parse(ViewModel.YPositionCube1), float.Parse(ViewModel.ZPositionCube1),
                   float.Parse(ViewModel.WidthCube1), float.Parse(ViewModel.HeightCube1), float.Parse(ViewModel.DepthCube1));
    }

    private Cube GetInformationCube2()
    {
        return new(float.Parse(ViewModel.XPositionCube2), float.Parse(ViewModel.YPositionCube2), float.Parse(ViewModel.ZPositionCube2),
                   float.Parse(ViewModel.WidthCube2), float.Parse(ViewModel.HeightCube2), float.Parse(ViewModel.DepthCube2));
    }

    private async Task<Cube?> LoadInformationCube(string id)
    {
        Cube? result = default;

        try
        {
            using HttpClient client = new() { BaseAddress = new Uri("https://localhost:44390/") };
            
            using Task<HttpResponseMessage> responseTask = client.GetAsync($"Cube/GetCube/{id}");
            using HttpResponseMessage response = await responseTask.ConfigureAwait(false);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    using (Task<CubeDto?> contentTask = response.Content.ReadFromJsonAsync(JsonDomainSerializerContext.Default.CubeDto))
                    {
                        result = Mapper.Map<Cube>(await contentTask.ConfigureAwait(false));
                    }

                    break;
                case HttpStatusCode.NoContent:
                    result = null;

                    break;

                case HttpStatusCode.InternalServerError:

                    break;
            }
        }
        catch
        {
            
        }

        return result;
    }

    private void OnAboutButtonClick()
    {
        Presentator.LoadPresenter<IAboutPresenter>(true, false);
    }

    private void OnCalculateIntersectionButtonClick()
    {
        Cube cube1 = GetInformationCube1();
        Cube cube2 = GetInformationCube2();

        Cube? cubeIntersection = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);

        if (cubeIntersection is null)
        {
            CleanInformation(false, false);
        }
        else
        {
            ViewModel.XPositionIntersection = cubeIntersection.X;
            ViewModel.YPositionIntersection = cubeIntersection.Y;
            ViewModel.ZPositionIntersection = cubeIntersection.Z;
            ViewModel.WidthIntersection = cubeIntersection.Width;
            ViewModel.HeightIntersection = cubeIntersection.Height;
            ViewModel.DepthIntersection = cubeIntersection.Depth;
        }
    }

    private void OnCleanDataButtonClick()
    {
        CleanInformation(true, true);
    }

    private bool OnEnableCalculateIntersectionButtonValidating()
    {
        bool canEnable = false;

        if (!IsCleaning)
        {
            canEnable = !ViewModel.HasErrors;
        }

        return canEnable;
    }

    private bool OnEnableEnglishMenuValidating()
    {
        bool canEnable = ViewModel.SelectedLanguage != Language.English;

        return canEnable;
    }

    private bool OnEnableLoadInformationCube1ButtonValidating()
    {
        bool canEnable = !string.IsNullOrEmpty(ViewModel.IdCube1);

        return canEnable;
    }

    private bool OnEnableLoadInformationCube2ButtonValidating()
    {
        bool canEnable = !string.IsNullOrEmpty(ViewModel.IdCube2);

        return canEnable;
    }

    private bool OnEnableSaveInformationCube1ButtonValidating()
    {
        bool canEnable = false;

        if (!IsCleaning)
        {
            canEnable = !string.IsNullOrEmpty(ViewModel.IdCube1);

            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.XPositionCube1)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.YPositionCube1)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.ZPositionCube1)).Any();

            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.WidthCube1)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.HeightCube1)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.DepthCube1)).Any();
        }

        return canEnable;
    }

    private bool OnEnableSaveInformationCube2ButtonValidating()
    {
        bool canEnable = false;

        if (!IsCleaning)
        {
            canEnable = !string.IsNullOrEmpty(ViewModel.IdCube2);

            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.XPositionCube2)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.YPositionCube2)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.ZPositionCube2)).Any();

            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.WidthCube2)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.HeightCube2)).Any();
            canEnable &= !ViewModel.GetErrors(nameof(ViewModel.DepthCube2)).Any();
        }

        return canEnable;
    }

    private bool OnEnableSpanishMenuValidating()
    {
        bool canEnable = ViewModel.SelectedLanguage != Language.Spanish;

        return canEnable;
    }

    private void OnEnglishMenuClick()
    {
        ViewModel.SelectedLanguage = Language.English;
        SetLanguageMenusChecked();

        Settings.Language = Language.English;
    }

    private void OnExistsIntersectionValidating()
    {
        Cube cube1 = GetInformationCube1();
        Cube cube2 = GetInformationCube2();

        bool existIntersection = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        ViewModel.ExistsIntersectionChecked = existIntersection;
    }

    protected override void OnInitialize(object? sender, EventArgs e)
    {
        ViewModel.Validate();

        ViewModel.SelectedLanguage = Settings.Language;
        SetLanguageMenusChecked();
    }

    private void OnLoadInformationCube1Click()
    {
        using Task<Cube?> loadTask = LoadInformationCube(ViewModel.IdCube1);
        loadTask.Wait();

        Cube? cube = loadTask.Result;

        if (cube is null)
        {
            CleanInformation(true, false);
        }
        else
        {
            ViewModel.XPositionCube1 = Convert.ToString(cube.X);
            ViewModel.YPositionCube1 = Convert.ToString(cube.Y);
            ViewModel.ZPositionCube1 = Convert.ToString(cube.Z);
            ViewModel.WidthCube1 = Convert.ToString(cube.Width);
            ViewModel.HeightCube1 = Convert.ToString(cube.Height);
            ViewModel.DepthCube1 = Convert.ToString(cube.Depth);
        }
    }

    private void OnLoadInformationCube2Click()
    {
        using Task<Cube?> loadTask = LoadInformationCube(ViewModel.IdCube2);
        loadTask.Wait();

        Cube? cube = loadTask.Result;

        if (cube is null)
        {
            CleanInformation(false, true);
        }
        else
        {
            ViewModel.XPositionCube2 = Convert.ToString(cube.X);
            ViewModel.YPositionCube2 = Convert.ToString(cube.Y);
            ViewModel.ZPositionCube2 = Convert.ToString(cube.Z);
            ViewModel.WidthCube2 = Convert.ToString(cube.Width);
            ViewModel.HeightCube2 = Convert.ToString(cube.Height);
            ViewModel.DepthCube2 = Convert.ToString(cube.Depth);
        }
    }

    private void OnSaveInformationCube1Click()
    {
        Cube cube = GetInformationCube1();

        using Task<UpsetOperation> saveTask = SaveInformationCube(ViewModel.IdCube1, cube);
        saveTask.Wait();
    }

    private void OnSaveInformationCube2Click()
    {
        Cube cube = GetInformationCube2();

        using Task<UpsetOperation> saveTask = SaveInformationCube(ViewModel.IdCube2, cube);
        saveTask.Wait();
    }

    private void OnSpanishMenuClick()
    {
        ViewModel.SelectedLanguage = Language.Spanish;
        SetLanguageMenusChecked();

        Settings.Language = Language.Spanish;
    }

    protected override void OnViewClosed(object? sender, EventArgs e)
    {
        ViewModel.AboutButtonClick -= OnAboutButtonClick;
        ViewModel.CalculateIntersectionButtonClick -= OnCalculateIntersectionButtonClick;
        ViewModel.CleanDataButtonClick -= OnCleanDataButtonClick;
        ViewModel.EnableCalculateIntersectionButtonValidating -= OnEnableCalculateIntersectionButtonValidating;
        ViewModel.EnableEnglishMenuValidating -= OnEnableEnglishMenuValidating;
        ViewModel.EnableLoadInformationCube1ButtonValidating -= OnEnableLoadInformationCube1ButtonValidating;
        ViewModel.EnableLoadInformationCube2ButtonValidating -= OnEnableLoadInformationCube2ButtonValidating;
        ViewModel.EnableSaveInformationCube1ButtonValidating -= OnEnableSaveInformationCube1ButtonValidating;
        ViewModel.EnableSaveInformationCube2ButtonValidating -= OnEnableSaveInformationCube2ButtonValidating;
        ViewModel.EnableSpanishMenuValidating -= OnEnableSpanishMenuValidating;
        ViewModel.EnglishMenuClick -= OnEnglishMenuClick;
        ViewModel.ExistsIntersectionValidating -= OnExistsIntersectionValidating;
        ViewModel.LoadInformationCube1Click -= OnLoadInformationCube1Click;
        ViewModel.LoadInformationCube2Click -= OnLoadInformationCube2Click;
        ViewModel.SaveInformationCube1Click -= OnSaveInformationCube1Click;
        ViewModel.SaveInformationCube2Click -= OnSaveInformationCube2Click;
        ViewModel.SpanishMenuClick -= OnSpanishMenuClick;

        base.OnViewClosed(sender, e);
    }

    private async Task<UpsetOperation> SaveInformationCube(string id, Cube cube)
    {
        UpsetOperation result = UpsetOperation.Error;

        try
        {
            using HttpClient client = new() { BaseAddress = new Uri("https://localhost:44390/") };

            CubeDto content = Mapper.Map<CubeDto>(cube);

            using Task<HttpResponseMessage> responseTask = client.PostAsJsonAsync($"Cube/SetCube/{id}", content, JsonDomainSerializerContext.Default.CubeDto);
            using HttpResponseMessage response = await responseTask.ConfigureAwait(false);


            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    using (Task<UpsetOperation> contentTask = response.Content.ReadFromJsonAsync(JsonDomainSerializerContext.Default.UpsetOperation))
                    {
                        result = await contentTask.ConfigureAwait(false);
                    }
                    
                    break;

                case HttpStatusCode.InternalServerError:

                    break;
            }
        }
        catch
        {

        }

        return result;
    }

    private void SetLanguageMenusChecked()
    {
        ViewModel.SpanishMenuChecked = ViewModel.SelectedLanguage == Language.Spanish;
        ViewModel.EnglishMenuChecked = ViewModel.SelectedLanguage == Language.English;
    }

    #endregion

}
