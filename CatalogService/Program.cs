using Microsoft.EntityFrameworkCore;
using CatalogService.DataBase;
using CatalogService.Repository;
using CatalogService.Services;
using CatalogService.Exception;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.



builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<CatalogService.DTO.CreateProductDto, CatalogService.Models.Product>().ReverseMap();
    cfg.CreateMap<CatalogService.Models.Product, CatalogService.DTO.ProductResponse>().ReverseMap();
    cfg.CreateMap<CatalogService.DTO.CategoryDTO, CatalogService.Models.Category>().ReverseMap();
},typeof(Program).Assembly);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//usar el manejador de excepciones personalizado
app.UseExceptionHandler(_ => { });


// --- Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();
