using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MiAlmacencitoDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MiAlmacencitoConnection")));

// Configure CORS for frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Configure controllers with JSON options for circular reference handling
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Ignorar referencias circulares al serializar a JSON
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar los servicios - Administration (Danny)
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();

// Registrar los servicios - Products & Cart (Pablo)
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

// Registrar los servicios - Product Management (Luis)
builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
