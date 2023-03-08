namespace GPM.CubeIntersector.Presenters;

public interface ICubeIntersectionPresenter : IPresenter
{

}

public class CubeIntersectionPresenter : Presenter<ICubeIntersectionView, ICubeIntersectionViewModel>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(IServiceProvider services) : base(services)
    {
        Mapper = services.GetRequiredService<IMapper>();
        Configurator = services.GetRequiredService<IConfigurator>();

        ViewModel.AboutButton_Click += OnViewModel_AboutButton_Click;
        ViewModel.CalculateIntersectionButton_CanExecuteValidating += OnViewModel_CalculateIntersectionButton_CanExecuteValidating;
        ViewModel.CalculateIntersectionButton_Click += OnViewModel_CalculateIntersectionButton_Click;
        ViewModel.CleanDataButton_Click += OnViewModel_CleanDataButton_Click;
        ViewModel.EnglishMenuItem_CanExecuteValidating += OnViewModel_EnglishMenuItem_CanExecuteValidating;
        ViewModel.EnglishMenuItem_Click += OnViewModel_EnglishMenuItem_Click;
        ViewModel.LoadInformationCube1Button_CanExecuteValidating += OnViewModel_LoadInformationCube1Button_CanExecuteValidating;
        ViewModel.LoadInformationCube1Button_Click += OnViewModel_LoadInformationCube1Button_Click;
        ViewModel.LoadInformationCube2Button_CanExecuteValidating += OnViewModel_LoadInformationCube2Button_CanExecuteValidating;
        ViewModel.LoadInformationCube2Button_Click += OnViewModel_LoadInformationCube2Button_Click;
        ViewModel.SaveInformationCube1Button_CanExecuteValidating += OnViewModel_SaveInformationCube1Button_CanExecuteValidating;
        ViewModel.SaveInformationCube1Button_Click += OnViewModel_SaveInformationCube1Button_Click;
        ViewModel.SaveInformationCube2Button_CanExecuteValidating += OnViewModel_SaveInformationCube2Button_CanExecuteValidating;
        ViewModel.SaveInformationCube2Button_Click += OnViewModel_SaveInformationCube2Button_Click;
        ViewModel.SpanishMenuItem_CanExecuteValidating += OnViewModel_SpanishMenuItem_CanExecuteValidating;
        ViewModel.SpanishMenuItem_Click += OnViewModel_SpanishMenuItem_Click;
    }

    #endregion

    #region properties

    private bool IsCleaning { get; set; }

    private IMapper Mapper { get; init; }

    private IConfigurator Configurator { get; init; }

    #endregion

    #region private methods

    private void CleanInformation(bool cleanInformationCube1, bool cleanInformationCube2)
    {
        IsCleaning = true;

        if (cleanInformationCube1 || cleanInformationCube2)
        {
            if (cleanInformationCube1)
            {
                ViewModel.XPositionCube1TextBox_Text = string.Empty;
                ViewModel.YPositionCube1TextBox_Text = string.Empty;
                ViewModel.ZPositionCube1TextBox_Text = string.Empty;

                ViewModel.WidthCube1TextBox_Text = string.Empty;
                ViewModel.HeightCube1TextBox_Text = string.Empty;
                ViewModel.DepthCube1TextBox_Text = string.Empty;
            }

            if (cleanInformationCube2)
            {
                ViewModel.XPositionCube2TextBox_Text = string.Empty;
                ViewModel.YPositionCube2TextBox_Text = string.Empty;
                ViewModel.ZPositionCube2TextBox_Text = string.Empty;

                ViewModel.WidthCube2TextBox_Text = string.Empty;
                ViewModel.HeightCube2TextBox_Text = string.Empty;
                ViewModel.DepthCube2TextBox_Text = string.Empty;
            }
        }

        ViewModel.XPositionIntersectionTextBox_Text = null;
        ViewModel.YPositionIntersectionTextBox_Text = null;
        ViewModel.ZPositionIntersectionTextBox_Text = null;

        ViewModel.WidthIntersectionTextBox_Text = null;
        ViewModel.HeightIntersectionTextBox_Text = null;
        ViewModel.DepthIntersectionTextBox_Text = null;

        ViewModel.ExistsIntersectionCheckBox_IsChecked = false;

        IsCleaning = false;
    }

    private Cube GetInformationCube1()
    {
        return new(float.Parse(ViewModel.XPositionCube1TextBox_Text), float.Parse(ViewModel.YPositionCube1TextBox_Text), float.Parse(ViewModel.ZPositionCube1TextBox_Text),
                   float.Parse(ViewModel.WidthCube1TextBox_Text), float.Parse(ViewModel.HeightCube1TextBox_Text), float.Parse(ViewModel.DepthCube1TextBox_Text));
    }

    private Cube GetInformationCube2()
    {
        return new(float.Parse(ViewModel.XPositionCube2TextBox_Text), float.Parse(ViewModel.YPositionCube2TextBox_Text), float.Parse(ViewModel.ZPositionCube2TextBox_Text),
                   float.Parse(ViewModel.WidthCube2TextBox_Text), float.Parse(ViewModel.HeightCube2TextBox_Text), float.Parse(ViewModel.DepthCube2TextBox_Text));
    }

    private async Task<Cube?> LoadInformationCubeAsync(string id)
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

    private async Task<UpsetOperation> SaveInformationCubeAsync(string id, Cube cube)
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

    private void UpdateLanguageMenuItems()
    {
        ViewModel.SpanishMenuItem_IsChecked = ViewModel.SelectedLanguage == Language.Spanish;
        ViewModel.EnglishMenuItem_IsChecked = ViewModel.SelectedLanguage == Language.English;
    }

    #endregion

    #region presenter methods

    protected override void OnInitialized(object? sender, EventArgs e)
    {
        ViewModel.Validate();

        ViewModel.SelectedLanguage = Configurator.Language;
        UpdateLanguageMenuItems();

        base.OnInitialized(sender, e);
    }

    #endregion

    #region view methods

    protected override void OnView_Closed(object? sender, EventArgs e)
    {
        ViewModel.AboutButton_Click -= OnViewModel_AboutButton_Click;
        ViewModel.CalculateIntersectionButton_CanExecuteValidating -= OnViewModel_CalculateIntersectionButton_CanExecuteValidating;
        ViewModel.CalculateIntersectionButton_Click -= OnViewModel_CalculateIntersectionButton_Click;
        ViewModel.CleanDataButton_Click -= OnViewModel_CleanDataButton_Click;
        ViewModel.EnglishMenuItem_CanExecuteValidating -= OnViewModel_EnglishMenuItem_CanExecuteValidating;
        ViewModel.EnglishMenuItem_Click -= OnViewModel_EnglishMenuItem_Click;
        ViewModel.LoadInformationCube1Button_CanExecuteValidating -= OnViewModel_LoadInformationCube1Button_CanExecuteValidating;
        ViewModel.LoadInformationCube1Button_Click -= OnViewModel_LoadInformationCube1Button_Click;
        ViewModel.LoadInformationCube2Button_CanExecuteValidating -= OnViewModel_LoadInformationCube2Button_CanExecuteValidating;
        ViewModel.LoadInformationCube2Button_Click -= OnViewModel_LoadInformationCube2Button_Click;
        ViewModel.SaveInformationCube1Button_CanExecuteValidating -= OnViewModel_SaveInformationCube1Button_CanExecuteValidating;
        ViewModel.SaveInformationCube1Button_Click -= OnViewModel_SaveInformationCube1Button_Click;
        ViewModel.SaveInformationCube2Button_CanExecuteValidating -= OnViewModel_SaveInformationCube2Button_CanExecuteValidating;
        ViewModel.SaveInformationCube2Button_Click -= OnViewModel_SaveInformationCube2Button_Click;
        ViewModel.SpanishMenuItem_CanExecuteValidating -= OnViewModel_SpanishMenuItem_CanExecuteValidating;
        ViewModel.SpanishMenuItem_Click -= OnViewModel_SpanishMenuItem_Click;

        base.OnView_Closed(sender, e);
    }

    #endregion

    #region viewmodel methods

    private void OnViewModel_AboutButton_Click(object? sender, EventArgs e)
    {
        Presentator.LoadPresenter<IAboutPresenter>(true, false);
    }

    private bool OnViewModel_CalculateIntersectionButton_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = false;

        if (!IsCleaning)
        {
            canExecute = !ViewModel.HasErrors;
        }

        return canExecute;
    }

    private void OnViewModel_CalculateIntersectionButton_Click(object? sender, EventArgs e)
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
            ViewModel.XPositionIntersectionTextBox_Text = cubeIntersection.X;
            ViewModel.YPositionIntersectionTextBox_Text = cubeIntersection.Y;
            ViewModel.ZPositionIntersectionTextBox_Text = cubeIntersection.Z;
            ViewModel.WidthIntersectionTextBox_Text = cubeIntersection.Width;
            ViewModel.HeightIntersectionTextBox_Text = cubeIntersection.Height;
            ViewModel.DepthIntersectionTextBox_Text = cubeIntersection.Depth;

            ViewModel.ExistsIntersectionCheckBox_IsChecked = true;
        }
    }

    private void OnViewModel_CleanDataButton_Click(object? sender, EventArgs e)
    {
        CleanInformation(true, true);
    }

    private bool OnViewModel_EnglishMenuItem_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = ViewModel.SelectedLanguage != Language.English;

        return canExecute;
    }

    private void OnViewModel_EnglishMenuItem_Click(object? sender, EventArgs e)
    {
        ViewModel.SelectedLanguage = Language.English;
        UpdateLanguageMenuItems();

        Configurator.Language = Language.English;
    }

    private bool OnViewModel_LoadInformationCube1Button_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = !string.IsNullOrEmpty(ViewModel.IdCube1TextBox_Text);

        return canExecute;
    }

    private void OnViewModel_LoadInformationCube1Button_Click(object? sender, EventArgs e)
    {
        using Task<Cube?> loadTask = LoadInformationCubeAsync(ViewModel.IdCube1TextBox_Text);
        loadTask.Wait();

        Cube? cube = loadTask.Result;

        if (cube is null)
        {
            CleanInformation(true, false);
        }
        else
        {
            ViewModel.XPositionCube1TextBox_Text = Convert.ToString(cube.X);
            ViewModel.YPositionCube1TextBox_Text = Convert.ToString(cube.Y);
            ViewModel.ZPositionCube1TextBox_Text = Convert.ToString(cube.Z);
            ViewModel.WidthCube1TextBox_Text = Convert.ToString(cube.Width);
            ViewModel.HeightCube1TextBox_Text = Convert.ToString(cube.Height);
            ViewModel.DepthCube1TextBox_Text = Convert.ToString(cube.Depth);
        }
    }

    private bool OnViewModel_LoadInformationCube2Button_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = !string.IsNullOrEmpty(ViewModel.IdCube2TextBox_Text);

        return canExecute;
    }

    private void OnViewModel_LoadInformationCube2Button_Click(object? sender, EventArgs e)
    {
        using Task<Cube?> loadTask = LoadInformationCubeAsync(ViewModel.IdCube2TextBox_Text);
        loadTask.Wait();

        Cube? cube = loadTask.Result;

        if (cube is null)
        {
            CleanInformation(false, true);
        }
        else
        {
            ViewModel.XPositionCube2TextBox_Text = Convert.ToString(cube.X);
            ViewModel.YPositionCube2TextBox_Text = Convert.ToString(cube.Y);
            ViewModel.ZPositionCube2TextBox_Text = Convert.ToString(cube.Z);
            ViewModel.WidthCube2TextBox_Text = Convert.ToString(cube.Width);
            ViewModel.HeightCube2TextBox_Text = Convert.ToString(cube.Height);
            ViewModel.DepthCube2TextBox_Text = Convert.ToString(cube.Depth);
        }
    }

    private bool OnViewModel_SaveInformationCube1Button_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = false;

        if (!IsCleaning)
        {
            canExecute = !string.IsNullOrEmpty(ViewModel.IdCube1TextBox_Text);

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.XPositionCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.YPositionCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.ZPositionCube1TextBox_Text)).Any();

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.WidthCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.HeightCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.DepthCube1TextBox_Text)).Any();
        }

        return canExecute;
    }

    private void OnViewModel_SaveInformationCube1Button_Click(object? sender, EventArgs e)
    {
        Cube cube = GetInformationCube1();

        using Task<UpsetOperation> saveTask = SaveInformationCubeAsync(ViewModel.IdCube1TextBox_Text, cube);
        saveTask.Wait();
    }

    private bool OnViewModel_SaveInformationCube2Button_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = false;

        if (!IsCleaning)
        {
            canExecute = !string.IsNullOrEmpty(ViewModel.IdCube2TextBox_Text);

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.XPositionCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.YPositionCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.ZPositionCube2TextBox_Text)).Any();

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.WidthCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.HeightCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.DepthCube2TextBox_Text)).Any();
        }

        return canExecute;
    }

    private void OnViewModel_SaveInformationCube2Button_Click(object? sender, EventArgs e)
    {
        Cube cube = GetInformationCube2();

        using Task<UpsetOperation> saveTask = SaveInformationCubeAsync(ViewModel.IdCube2TextBox_Text, cube);
        saveTask.Wait();
    }

    private bool OnViewModel_SpanishMenuItem_CanExecuteValidating(object? sender, EventArgs e)
    {
        bool canExecute = ViewModel.SelectedLanguage != Language.Spanish;

        return canExecute;
    }

    private void OnViewModel_SpanishMenuItem_Click(object? sender, EventArgs e)
    {
        ViewModel.SelectedLanguage = Language.Spanish;
        UpdateLanguageMenuItems();

        Configurator.Language = Language.Spanish;
    }

    #endregion

}
