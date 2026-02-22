using WebAplicacion.Clients;
using WebAplicacion.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClients (APIs externas)
builder.Services.AddHttpClient<CountryClient>();
builder.Services.AddHttpClient<IAClient>();

// Servicios de negocio
builder.Services.AddScoped<RiskAnalysisService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();


app.UseDefaultFiles();   
app.UseStaticFiles();    

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();