using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// cargar la configuracion de Ocelot desde el archivo ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
// Agregar Ocelot
builder.Services.AddOcelot(builder.Configuration);
// Agregar SwaggerForOcelot
builder.Services.AddSwaggerForOcelot(builder.Configuration);
var app = builder.Build();

app.UseRouting();

// Configurar SwaggerForOcelot
app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});
// Usar Ocelot
await app.UseOcelot();

app.Run();
