using ModularApi.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ModuleManager manager = new(builder.Services, builder.Configuration);

#if DEBUG
manager.BuildDevModules();
#endif

manager.LoadModuleAssemblies();
manager.LoadModuleControllers();
// manager.LoadControllers();
manager.RegisterModuleServices();
manager.ValidateModules();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

