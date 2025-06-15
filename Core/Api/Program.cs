using Core.IRepositories;
using Core.IRepository;
using Core.IService;
using Core.IServices;
using Core.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.DataRepository;
using Service;
using Service.DataService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()    
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductInStockRepository, ProductInStockRepository>();
builder.Services.AddScoped<IProductInStockService, ProductInStockService>();

builder.Services.AddDbContext<ProjectContext>(options =>
options.UseSqlServer("Server=חיהלה-055676283;Database=HomeAccessories;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);

builder.Services.AddTransient<EmailService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseCors("AllowAll"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
