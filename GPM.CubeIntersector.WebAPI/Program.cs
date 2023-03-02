using GPM.Product.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.AddContext<JsonDomainSerializerContext>();
                });

builder.Services.AddAutoMapper(typeof(DomainProfile));

builder.Services.AddDbContext<ICubeIntersectorDBContext, CubeIntersectorDBContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("CubeIntersectorDatabase"));
                });

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    using ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>();
    
    dbContext.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();